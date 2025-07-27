using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ToDos.Domains;

namespace ToDos
{
    public partial class PersonForm : Form
    {
        AppDbContext db = new AppDbContext();
        public PersonForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadData();
        }
        private void ConfigureDataGridView()
        {
            // Configure appearance and behavior
            dgvPersons.AutoGenerateColumns = false;
            dgvPersons.AllowUserToAddRows = true;
            dgvPersons.AllowUserToDeleteRows = true;
            dgvPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersons.MultiSelect = false;
            dgvPersons.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            // Add columns
            var c = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "شناسه",
                ReadOnly = true,
                Width = 50
            };
            dgvPersons.Columns.Add(c);

            dgvPersons.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "نام",
                Width = 200
            });
            string imagePath = Path.Combine(Application.StartupPath, "Images", "delete.png");
            // Add delete button column
            var deleteButton = new DataGridViewImageColumn
            {
                Image = Image.FromFile(imagePath),
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60,
            };
            dgvPersons.Columns.Add(deleteButton);

            // Handle events
            dgvPersons.CellEndEdit += DgvPersons_CellEndEdit;
            dgvPersons.UserDeletingRow += DgvPersons_UserDeletingRow;
            dgvPersons.CellContentClick += DgvPersons_CellContentClick;
            dgvPersons.CellFormatting += DgvPersons_CellFormatting;
        }

        private void LoadData()
        {
            db.People.Load();
            dgvPersons.DataSource = db.People.Local.ToBindingList();
            // Handle default values for new rows
            dgvPersons.DefaultValuesNeeded += (s, e) =>
            {
                string imagePath = Path.Combine(Application.StartupPath, "Images", "delete.png");
                e.Row.Cells[2].Value = Image.FromFile(imagePath);
            };
        }

        // Handle inline editing
        private void DgvPersons_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                db.SaveChanges();
                LoadData();
                dgvPersons.Refresh();
                string imagePath = Path.Combine(Application.StartupPath, "Images", "delete.png");
                dgvPersons.Rows[dgvPersons.Rows.Count - 1].Cells[2].Value = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ذخیره تغییرات به مشکل خورد: {ex.Message}");
                LoadData(); // Refresh to undo invalid changes
            }
        }

        // Handle row deletion with Delete key
        private void DgvPersons_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var person = e.Row.DataBoundItem as Person;
            if (person != null && MessageBox.Show($"حذف {person.Name}?", "آیا از این تغییر مطمئن هستید؟",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.People.Remove(person);
                db.SaveChanges();
            }
            else
            {
                e.Cancel = true;
            }
        }

        // Handle delete button click
        private void DgvPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Delete button column
            {
                var person = (Person)dgvPersons.Rows[e.RowIndex].DataBoundItem;
                if (person != null && MessageBox.Show($"حذف {person.Name}?", "آیا از این تغییر مطمئن هستید؟",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.People.Remove(person);
                    db.SaveChanges();
                    LoadData(); // Refresh to show changes
                }
            }
        }

        private void DgvPersons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if this is the delete-button column (index 2) 
            // and the special "add new row" (NewRowIndex)
            if (e.ColumnIndex == 2 && e.RowIndex == dgvPersons.NewRowIndex)
            {
                // Suppress the icon by setting no value
                e.Value = null;
                e.FormattingApplied = true;
                e.CellStyle.NullValue = null; // Set the cell style to null
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db.Dispose();
            base.OnFormClosing(e);
        }
    }
}
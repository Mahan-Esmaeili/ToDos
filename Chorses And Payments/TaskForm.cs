using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ToDos.Domains;

namespace ToDos
{
    public partial class TaskForm : Form
    {
        AppDbContext db = new AppDbContext();

        public TaskForm()
        {
            InitializeComponent();
            LoadPersons();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Configure appearance and behavior
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.AllowUserToAddRows = true;
            dgvTasks.AllowUserToDeleteRows = true;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.MultiSelect = false;
            dgvTasks.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            // Add columns
            var c = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "شناسه",
                ReadOnly = true,
                Width = 50
            };
            dgvTasks.Columns.Add(c);

            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "عنوان",
                Width = 200
            });

            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ApplicationDate",
                HeaderText = "تاریخ اجرا",
                Width = 200
            });

            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TaskStatus",
                HeaderText = "وضعیت تسک",
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
            dgvTasks.Columns.Add(deleteButton);

            // Handle events
            /*dgvTasks.CellEndEdit += DgvPersons_CellEndEdit;
            dgvTasks.UserDeletingRow += DgvPersons_UserDeletingRow;
            dgvTasks.CellContentClick += DgvPersons_CellContentClick;
            dgvTasks.CellFormatting += DgvPersons_CellFormatting;*/
        }

        private void LoadPersons()
        {
            var people = db.People.ToList();
            cbxPersons.DataSource = people;
            cbxPersons.DisplayMember = "Name"; // The column to display
            cbxPersons.ValueMember = "Id";   // The underlying value
            //var selectedPersonId = Convert.ToInt32(cbxPersons.SelectedValue.Id);
            var selectedPerson = people.FirstOrDefault();
            LoadData(selectedPerson.Id);
        }
        private void LoadData(int personId)
        {
            var filteredTasks = db.Tasks.Where(p => p.Person.Id == personId).ToList();

            dgvTasks.DataSource = new BindingList<ToDo>(filteredTasks);

            //db.Tasks.Where(p => p.Person.Id == personId).Load();
            //dgvTasks.DataSource = null;
            //dgvTasks.Refresh();
            //dgvTasks.DataSource = db.Tasks.Local.ToBindingList().Where(p => p.Person.Id == personId).ToList();
            // Handle default values for new rows
            //dgvTasks.DefaultValuesNeeded += (s, e) =>
            //{
            //    string imagePath = Path.Combine(Application.StartupPath, "Images", "delete.png");
            //    e.Row.Cells[4].Value = Image.FromFile(imagePath);
            //};
        }

        private void cbxPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selectedPersonId = Convert.ToInt32((cbxPersons.SelectedValue as Person).Id);
            //var selectedPersonId = Convert.ToInt32(cbxPersons.SelectedValue);
            //var selectedPersonId = cbxPersons.SelectedValue;
            var selectedPersonId = 0;
            if (cbxPersons.SelectedValue.GetType() == typeof(int))
            {
                selectedPersonId = Convert.ToInt32(cbxPersons.SelectedValue);
            }
            else
            {
                selectedPersonId = Convert.ToInt32((cbxPersons.SelectedValue as Person).Id);
            }
            LoadData(selectedPersonId);
        }
    }
}

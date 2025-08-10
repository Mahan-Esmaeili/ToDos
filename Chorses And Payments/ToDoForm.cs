using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ToDos.Domains;

namespace ToDos
{
    public partial class ToDoForm : Form
    {
        public ToDoForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadPerson();
            LoadData();
        }

        private void ConfigureDataGridView()
        {
            // Configure appearance and behavior
            dgvToDo.AutoGenerateColumns = false;
            dgvToDo.AllowUserToDeleteRows = true;
            dgvToDo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvToDo.MultiSelect = false;
            dgvToDo.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            // Add columns
            dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "شناسه",
                ReadOnly = true,
                Width = 50
            });

            dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "عنوان",
                Width = 200
            });

            //dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "ApplicationDate",
            //    HeaderText = "تاریخ اجرا",
            //    Width = 200
            //});


            //toDos: باید به چای استارتد یا نات استارتد از آیکون های تیک و ضربدر استفاده کنیم
            dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TaskStatus",
                HeaderText = "وضعیت تسک",
                Width = 200
            });

            // Add delete button column
            dgvToDo.Columns.Add(new DataGridViewImageColumn
            {
                Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "delete.png")),
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60,
                ToolTipText = "حذف"
            });

            // Add edit button column
            dgvToDo.Columns.Add(new DataGridViewImageColumn
            {
                Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "edit.png")),
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60,
                ToolTipText = "ویرایش"
            });

            // Handle events
            /*dgvToDo.CellEndEdit += DgvPersons_CellEndEdit;
            dgvToDo.UserDeletingRow += DgvPersons_UserDeletingRow;
            dgvToDo.CellContentClick += DgvPersons_CellContentClick;
            dgvToDo.CellFormatting += DgvPersons_CellFormatting;*/
        }

        private void LoadData()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                dgvToDo.DataSource = appDbContext.Tasks.ToList();
            }
        }

        private void LoadPerson()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                ddlPerson.DataSource = appDbContext.People.Select(p => new { p.Id, p.Name }).ToList();
                ddlPerson.DisplayMember = "Name";
                ddlPerson.ValueMember = "Id";
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            bool status = rdbDone.Checked;
            string price = txtPrize.Text.Trim();

            if (title.Length == 0 || price.Length == 0)
            {
                lblError.Text = "لطفا تمامی فیلد ها را پر کنید";
                return;
            }

            else
            {
                int prize = Convert.ToInt32(price);
                int personId = Convert.ToInt32(ddlPerson.SelectedValue.ToString()); 
                ToDo toDo = new ToDo()
                {
                    Title = title,
                    TaskStatus = status ? TaskStatus.Completed : TaskStatus.NotCompleted,
                    Payment = prize,
                    ApplicationDate = DateTime.Now

                };

                using(AppDbContext appDbContext = new AppDbContext())
                {
                    appDbContext.People.Where(p => p.Id == personId).FirstOrDefault();
                }
            }
        }
    }
}

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
        }
        public int taskId = -1;
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
                Width = 50,
                Name = "Id"
            });

            dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                ReadOnly = true,
                HeaderText = "عنوان",
                Width = 200
            });

            //dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "ApplicationDate",
            //    HeaderText = "تاریخ اجرا",
            //    Width = 200
            //});

            dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Payment",
                HeaderText = "پاداش",
                ReadOnly = true,
                Width = 100,
                Name = "Payment"
            });
            //toDos: باید به چای استارتد یا نات استارتد از آیکون های تیک و ضربدر استفاده کنیم
            dgvToDo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TaskStatus",
                ReadOnly = true,
                HeaderText = "وضعیت تسک",
                Width = 200
            });

            // Add delete button column
            dgvToDo.Columns.Add(new DataGridViewImageColumn
            {
                Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "delete.png")),
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60,
                ToolTipText = "حذف",
                Name = "Delete"
            });

            // Add edit button column
            dgvToDo.Columns.Add(new DataGridViewImageColumn
            {
                Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "edit.png")),
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60,
                ToolTipText = "ویرایش",
                Name = "Edit"
            });

            // Handle events
            /*dgvToDo.CellEndEdit += DgvPersons_CellEndEdit;
            dgvToDo.UserDeletingRow += DgvPersons_UserDeletingRow;
            dgvToDo.CellContentClick += DgvPersons_CellContentClick;
            dgvToDo.CellFormatting += DgvPersons_CellFormatting;*/
        }

        private void LoadData(int personId)
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                //var a = ddlPerson.SelectedValue;
                //int selectedPersonId = Convert.ToInt32(ddlPerson.SelectedValue);
                dgvToDo.DataSource = appDbContext.Tasks.Where(p => p.Person.Id == personId).ToList();
            }
        }
        public class Test
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        private void LoadPerson()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                ddlPerson.DataSource = appDbContext.People.ToList();
                ddlPerson.DisplayMember = "Name";
                ddlPerson.ValueMember = "Id";
                ddlEditPerson.DataSource = appDbContext.People.ToList();
                ddlEditPerson.DisplayMember = "Name";
                ddlEditPerson.ValueMember = "Id";

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
                int personId = Convert.ToInt32(ddlEditPerson.SelectedValue.ToString());
                using (AppDbContext appDbContext = new AppDbContext())
                {
                    if (taskId != -1)
                    {

                        ToDo task = appDbContext.Tasks.Where(t => t.Id == taskId).FirstOrDefault();
                        task.Title = title;
                        task.TaskStatus = status ? TaskStatus.Completed : TaskStatus.NotCompleted;
                        task.Payment = prize;
                        task.ApplicationDate = DateTime.Now;
                        Person person = appDbContext.People.Where(p => p.Id == personId).FirstOrDefault();
                        task.Person = person;
                        appDbContext.SaveChanges();
                        lblError.Text = "با موفقیت انجام شد";
                        taskId = -1;
                    }

                    else
                    {
                        ToDo toDo = new ToDo()
                        {
                            Title = title,
                            TaskStatus = status ? TaskStatus.Completed : TaskStatus.NotCompleted,
                            Payment = prize,
                            ApplicationDate = DateTime.Now

                        };
                        Person person = appDbContext.People.Where(p => p.Id == personId).FirstOrDefault();
                        toDo.Person = person;

                        appDbContext.Tasks.Add(toDo);
                        appDbContext.SaveChanges();
                        lblError.Text = "با موفقیت انجام شد";
                    }
                }
                var selectedPersonId = 0;
                if (ddlPerson.SelectedValue.GetType() == typeof(int))
                {
                    selectedPersonId = Convert.ToInt32(ddlPerson.SelectedValue);
                }
                else
                {
                    selectedPersonId = Convert.ToInt32((ddlPerson.SelectedValue as Person).Id);
                }
                LoadData(selectedPersonId);

            }
        }

        private void dgvToDo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                if (dgvToDo.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult permission = MessageBox.Show(
                    "آیا از انجام این کار اطمینان دارید؟",
                     "تایید حذف",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning
                );

                    if (permission == DialogResult.Yes)
                    {
                        int taskId = Convert.ToInt32(dgvToDo.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                        ToDo toDo = appDbContext.Tasks.FirstOrDefault(p => p.Id == taskId);
                        appDbContext.Tasks.Remove(toDo);
                        appDbContext.SaveChanges();
                        var selectedPersonId = 0;
                        if (ddlPerson.SelectedValue.GetType() == typeof(int))
                        {
                            selectedPersonId = Convert.ToInt32(ddlPerson.SelectedValue);
                        }
                        else
                        {
                            selectedPersonId = Convert.ToInt32((ddlPerson.SelectedValue as Person).Id);
                        }
                        LoadData(selectedPersonId);
                    }
                }

                else if (dgvToDo.Columns[e.ColumnIndex].Name == "Edit")
                {
                    taskId = Convert.ToInt32(dgvToDo.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    ToDo toDo = appDbContext.Tasks.Include("Person").FirstOrDefault(p => p.Id == taskId);
                    txtTitle.Text = toDo.Title;
                    txtPrize.Text = toDo.Payment.ToString();
                    if (toDo.TaskStatus == TaskStatus.Completed)
                    {
                        rdbDone.Checked = true;
                        rdbNotDone.Checked = false;
                    }
                    else if (toDo.TaskStatus == TaskStatus.NotCompleted)
                    {
                        rdbDone.Checked = false;
                        rdbNotDone.Checked = true;
                    }
                    ddlEditPerson.SelectedItem = toDo.Person;
                    ddlEditPerson.SelectedValue = toDo.Person.Id;
                    var selectedIndex = ddlEditPerson.Items.Cast<Person>().Where(p => p.Id == toDo.Person.Id).FirstOrDefault();
                    ddlEditPerson.SelectedIndex = ddlEditPerson.Items.IndexOf(selectedIndex);

                }
            }
        }

        private void ddlPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPersonId = 0;
            if (ddlPerson.SelectedValue.GetType() == typeof(int))
            {
                selectedPersonId = Convert.ToInt32(ddlPerson.SelectedValue);
            }
            else
            {
                selectedPersonId = Convert.ToInt32((ddlPerson.SelectedValue as Person).Id);
            }
            LoadData(selectedPersonId);

        }
    }
}

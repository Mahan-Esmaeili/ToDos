using System;
using System.Windows.Forms;

namespace ToDos
{
    public partial class MainForm : Form
    {
        PersonForm personForm = new PersonForm();
        ToDoForm toDoForm = new ToDoForm();
        //TaskForm taskForm = new TaskForm();
        TabPage tpPersons = new TabPage("اشخاص");
        //TabPage tptask = new TabPage("کارها");
        TabPage tpToDo = new TabPage("کارها");
        public MainForm()
        {
            InitializeComponent();
            //LoadFormsInTabControl("اشخاص", "persons", personForm);
            //LoadFormsInTabControl("کارها", "tasks", taskForm);
            tpPersons.Name = "Persons";
            tpToDo.Name = "task";
            LoadFormsInTabControl(tpPersons, personForm);
            LoadFormsInTabControl(tpToDo, toDoForm);
        }

        private void LoadFormsInTabControl(TabPage tp, Form form)
        {

            //TabPage tp = new TabPage(tabTitle);
            //tp.Name = tabName;
            if (!tcMain.TabPages.Contains(tp))
            { tcMain.TabPages.Add(tp); }
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tp.Controls.Clear();
            foreach (Control ctrl in tp.Controls)
            {
                ctrl.Dispose();
            }
            tp.Controls.Add(form);
            form.Show();

        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tcMain.SelectedIndex;
            if (selectedTab == 0)
            {
                LoadFormsInTabControl(tpPersons, personForm);
            }
            else
            {
                LoadFormsInTabControl(tpToDo, toDoForm);
            }
        }
    }
}

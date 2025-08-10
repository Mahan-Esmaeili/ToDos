
namespace ToDos
{
    partial class ToDoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvToDo = new System.Windows.Forms.DataGridView();
            this.txtPrize = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblPerson = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPrize = new System.Windows.Forms.Label();
            this.ddlPerson = new System.Windows.Forms.ComboBox();
            this.rdbNotDone = new System.Windows.Forms.RadioButton();
            this.rdbDone = new System.Windows.Forms.RadioButton();
            this.gpbStatus = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToDo)).BeginInit();
            this.gpbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvToDo
            // 
            this.dgvToDo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToDo.Location = new System.Drawing.Point(5, 3);
            this.dgvToDo.Name = "dgvToDo";
            this.dgvToDo.Size = new System.Drawing.Size(1328, 343);
            this.dgvToDo.TabIndex = 0;
            // 
            // txtPrize
            // 
            this.txtPrize.Location = new System.Drawing.Point(236, 555);
            this.txtPrize.Name = "txtPrize";
            this.txtPrize.Size = new System.Drawing.Size(116, 20);
            this.txtPrize.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(236, 352);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(116, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(162, 355);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(66, 13);
            this.lblTask.TabIndex = 5;
            this.lblTask.Text = "عنوان تسک";
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(188, 414);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(37, 13);
            this.lblPerson.TabIndex = 6;
            this.lblPerson.Text = "شخص";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(153, 477);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "وضعیت تسک";
            // 
            // lblPrize
            // 
            this.lblPrize.AutoSize = true;
            this.lblPrize.Location = new System.Drawing.Point(188, 558);
            this.lblPrize.Name = "lblPrize";
            this.lblPrize.Size = new System.Drawing.Size(37, 13);
            this.lblPrize.TabIndex = 8;
            this.lblPrize.Text = "پاداش";
            // 
            // ddlPerson
            // 
            this.ddlPerson.FormattingEnabled = true;
            this.ddlPerson.Location = new System.Drawing.Point(236, 414);
            this.ddlPerson.Name = "ddlPerson";
            this.ddlPerson.Size = new System.Drawing.Size(116, 21);
            this.ddlPerson.TabIndex = 9;
            // 
            // rdbNotDone
            // 
            this.rdbNotDone.AutoSize = true;
            this.rdbNotDone.Checked = true;
            this.rdbNotDone.Location = new System.Drawing.Point(6, 52);
            this.rdbNotDone.Name = "rdbNotDone";
            this.rdbNotDone.Size = new System.Drawing.Size(79, 17);
            this.rdbNotDone.TabIndex = 10;
            this.rdbNotDone.TabStop = true;
            this.rdbNotDone.Text = "تمام نشده";
            this.rdbNotDone.UseVisualStyleBackColor = true;
            // 
            // rdbDone
            // 
            this.rdbDone.AutoSize = true;
            this.rdbDone.Location = new System.Drawing.Point(6, 29);
            this.rdbDone.Name = "rdbDone";
            this.rdbDone.Size = new System.Drawing.Size(74, 17);
            this.rdbDone.TabIndex = 11;
            this.rdbDone.Text = "تمام شده";
            this.rdbDone.UseVisualStyleBackColor = true;
            // 
            // gpbStatus
            // 
            this.gpbStatus.Controls.Add(this.rdbDone);
            this.gpbStatus.Controls.Add(this.rdbNotDone);
            this.gpbStatus.Location = new System.Drawing.Point(236, 441);
            this.gpbStatus.Name = "gpbStatus";
            this.gpbStatus.Size = new System.Drawing.Size(116, 82);
            this.gpbStatus.TabIndex = 12;
            this.gpbStatus.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(426, 555);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(423, 422);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 14;
            // 
            // ToDoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 701);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gpbStatus);
            this.Controls.Add(this.ddlPerson);
            this.Controls.Add(this.lblPrize);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtPrize);
            this.Controls.Add(this.dgvToDo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ToDoForm";
            this.Text = "کارها";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvToDo)).EndInit();
            this.gpbStatus.ResumeLayout(false);
            this.gpbStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvToDo;
        private System.Windows.Forms.TextBox txtPrize;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPrize;
        private System.Windows.Forms.ComboBox ddlPerson;
        private System.Windows.Forms.RadioButton rdbNotDone;
        private System.Windows.Forms.RadioButton rdbDone;
        private System.Windows.Forms.GroupBox gpbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblError;
    }
}
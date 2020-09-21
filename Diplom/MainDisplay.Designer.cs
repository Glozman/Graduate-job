namespace Diplom
{
    partial class MainDisplay
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.workersTabBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diplom2DataSet = new Diplom.Diplom2DataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.jobListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.workersTabTableAdapter = new Diplom.Diplom2DataSetTableAdapters.WorkersTabTableAdapter();
            this.jobListTableAdapter = new Diplom.Diplom2DataSetTableAdapters.JobListTableAdapter();
            this.listdev = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WorkerBox = new System.Windows.Forms.ComboBox();
            this.JobsBox = new System.Windows.Forms.ComboBox();
            this.mounths = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.StartStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.GTPStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AllTabToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.adddevbtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.workersTabBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplom2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobListBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // workersTabBindingSource
            // 
            this.workersTabBindingSource.DataMember = "WorkersTab";
            this.workersTabBindingSource.DataSource = this.diplom2DataSet;
            // 
            // diplom2DataSet
            // 
            this.diplom2DataSet.DataSetName = "Diplom2DataSet";
            this.diplom2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите вид работ";
            // 
            // jobListBindingSource
            // 
            this.jobListBindingSource.DataMember = "JobList";
            this.jobListBindingSource.DataSource = this.diplom2DataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ваши устройства";
            // 
            // workersTabTableAdapter
            // 
            this.workersTabTableAdapter.ClearBeforeFill = true;
            // 
            // jobListTableAdapter
            // 
            this.jobListTableAdapter.ClearBeforeFill = true;
            // 
            // listdev
            // 
            this.listdev.FormattingEnabled = true;
            this.listdev.Location = new System.Drawing.Point(183, 81);
            this.listdev.Margin = new System.Windows.Forms.Padding(2);
            this.listdev.Name = "listdev";
            this.listdev.Size = new System.Drawing.Size(157, 173);
            this.listdev.TabIndex = 8;
            this.listdev.DoubleClick += new System.EventHandler(this.listdevSelect);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Выберите номер работника";
            // 
            // WorkerBox
            // 
            this.WorkerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkerBox.FormattingEnabled = true;
            this.WorkerBox.Location = new System.Drawing.Point(12, 41);
            this.WorkerBox.Margin = new System.Windows.Forms.Padding(2);
            this.WorkerBox.Name = "WorkerBox";
            this.WorkerBox.Size = new System.Drawing.Size(94, 21);
            this.WorkerBox.TabIndex = 10;
            this.WorkerBox.SelectedIndexChanged += new System.EventHandler(this.WorkerSelect);
            // 
            // JobsBox
            // 
            this.JobsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JobsBox.FormattingEnabled = true;
            this.JobsBox.Location = new System.Drawing.Point(183, 41);
            this.JobsBox.Margin = new System.Windows.Forms.Padding(2);
            this.JobsBox.Name = "JobsBox";
            this.JobsBox.Size = new System.Drawing.Size(329, 21);
            this.JobsBox.TabIndex = 11;
            this.JobsBox.SelectedIndexChanged += new System.EventHandler(this.JobsSelect);
            // 
            // mounths
            // 
            this.mounths.FormattingEnabled = true;
            this.mounths.Location = new System.Drawing.Point(12, 81);
            this.mounths.Name = "mounths";
            this.mounths.Size = new System.Drawing.Size(94, 173);
            this.mounths.TabIndex = 12;
            this.mounths.DoubleClick += new System.EventHandler(this.mounthselect);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Выберите месяц";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuStrip
            // 
            this.MenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartStrip,
            this.AddToolStrip,
            this.CreateToolStrip,
            this.DeleteToolStrip,
            this.CloseStrip,
            this.AllTabToolStrip});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(53, 20);
            this.MenuStrip.Text = "Меню";
            // 
            // StartStrip
            // 
            this.StartStrip.Name = "StartStrip";
            this.StartStrip.Size = new System.Drawing.Size(226, 22);
            this.StartStrip.Text = "Начать";
            this.StartStrip.Click += new System.EventHandler(this.StartStrip_Click);
            // 
            // AddToolStrip
            // 
            this.AddToolStrip.Name = "AddToolStrip";
            this.AddToolStrip.Size = new System.Drawing.Size(226, 22);
            this.AddToolStrip.Text = "Добавить";
            // 
            // CreateToolStrip
            // 
            this.CreateToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GTPStrip,
            this.ReportStrip});
            this.CreateToolStrip.Name = "CreateToolStrip";
            this.CreateToolStrip.Size = new System.Drawing.Size(226, 22);
            this.CreateToolStrip.Text = "Создать";
            // 
            // GTPStrip
            // 
            this.GTPStrip.Name = "GTPStrip";
            this.GTPStrip.Size = new System.Drawing.Size(247, 22);
            this.GTPStrip.Text = "График технического процесса";
            this.GTPStrip.Click += new System.EventHandler(this.CreateGTPStrip_Click);
            // 
            // ReportStrip
            // 
            this.ReportStrip.Name = "ReportStrip";
            this.ReportStrip.Size = new System.Drawing.Size(247, 22);
            this.ReportStrip.Text = "Отчет";
            this.ReportStrip.Click += new System.EventHandler(this.ReportStrip_Click);
            // 
            // DeleteToolStrip
            // 
            this.DeleteToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteItem});
            this.DeleteToolStrip.Name = "DeleteToolStrip";
            this.DeleteToolStrip.Size = new System.Drawing.Size(226, 22);
            this.DeleteToolStrip.Text = "Удалить";
            // 
            // DeleteItem
            // 
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteItem.Text = "Отчет";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // CloseStrip
            // 
            this.CloseStrip.Name = "CloseStrip";
            this.CloseStrip.Size = new System.Drawing.Size(226, 22);
            this.CloseStrip.Text = "Закрыть";
            this.CloseStrip.Click += new System.EventHandler(this.CloseStrip_Click);
            // 
            // AllTabToolStrip
            // 
            this.AllTabToolStrip.Name = "AllTabToolStrip";
            this.AllTabToolStrip.Size = new System.Drawing.Size(226, 22);
            this.AllTabToolStrip.Text = "Посмотреть все устройства";
            this.AllTabToolStrip.Click += new System.EventHandler(this.AllDevToolStrip_Click);
            // 
            // adddevbtn
            // 
            this.adddevbtn.Location = new System.Drawing.Point(183, 260);
            this.adddevbtn.Name = "adddevbtn";
            this.adddevbtn.Size = new System.Drawing.Size(75, 41);
            this.adddevbtn.TabIndex = 17;
            this.adddevbtn.Text = "Добавить устройство";
            this.adddevbtn.UseVisualStyleBackColor = true;
            this.adddevbtn.Click += new System.EventHandler(this.adddevbtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(265, 260);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(75, 41);
            this.deletebtn.TabIndex = 18;
            this.deletebtn.Text = "Удалить устройство";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // MainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 313);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.adddevbtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mounths);
            this.Controls.Add(this.JobsBox);
            this.Controls.Add(this.WorkerBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listdev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainDisplay";
            this.Text = "User Display";
            this.Load += new System.EventHandler(this.MainDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workersTabBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplom2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobListBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Diplom2DataSet diplom2DataSet;
        private System.Windows.Forms.BindingSource workersTabBindingSource;
        private Diplom2DataSetTableAdapters.WorkersTabTableAdapter workersTabTableAdapter;
        private System.Windows.Forms.BindingSource jobListBindingSource;
        private Diplom2DataSetTableAdapters.JobListTableAdapter jobListTableAdapter;
        private System.Windows.Forms.ListBox listdev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox WorkerBox;
        private System.Windows.Forms.ComboBox JobsBox;
        private System.Windows.Forms.ListBox mounths;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartStrip;
        private System.Windows.Forms.ToolStripMenuItem CloseStrip;
        private System.Windows.Forms.ToolStripMenuItem AddToolStrip;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStrip;
        private System.Windows.Forms.ToolStripMenuItem GTPStrip;
        private System.Windows.Forms.ToolStripMenuItem ReportStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteItem;
        private System.Windows.Forms.ToolStripMenuItem AllTabToolStrip;
        private System.Windows.Forms.Button adddevbtn;
        private System.Windows.Forms.Button deletebtn;
    }
}


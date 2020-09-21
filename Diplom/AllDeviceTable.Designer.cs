namespace Diplom
{
    partial class AllDevices
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
            this.DeleteTable = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteTable
            // 
            this.DeleteTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeleteTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Device,
            this.Job,
            this.Worker});
            this.DeleteTable.Location = new System.Drawing.Point(13, 13);
            this.DeleteTable.Name = "DeleteTable";
            this.DeleteTable.Size = new System.Drawing.Size(450, 425);
            this.DeleteTable.TabIndex = 2;
            // 
            // Code
            // 
            this.Code.HeaderText = "Код";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // Device
            // 
            this.Device.HeaderText = "Устройство";
            this.Device.Name = "Device";
            this.Device.ReadOnly = true;
            // 
            // Job
            // 
            this.Job.HeaderText = "Вид работ";
            this.Job.Name = "Job";
            this.Job.ReadOnly = true;
            // 
            // Worker
            // 
            this.Worker.HeaderText = "Исполнитель";
            this.Worker.Name = "Worker";
            this.Worker.ReadOnly = true;
            // 
            // AllDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.DeleteTable);
            this.Name = "AllDevices";
            this.Text = "DeleteDeviceForm";
            this.Load += new System.EventHandler(this.DeleteDeviceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DeleteTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Device;
        private System.Windows.Forms.DataGridViewTextBoxColumn Job;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker;
    }
}
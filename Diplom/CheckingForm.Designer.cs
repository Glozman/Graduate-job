namespace Diplom
{
    partial class CheckingForm
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
            this.checkJob = new System.Windows.Forms.CheckBox();
            this.JobTime = new System.Windows.Forms.MonthCalendar();
            this.btnReport = new System.Windows.Forms.Button();
            this.meslab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkJob
            // 
            this.checkJob.AutoSize = true;
            this.checkJob.Location = new System.Drawing.Point(9, 178);
            this.checkJob.Margin = new System.Windows.Forms.Padding(2);
            this.checkJob.Name = "checkJob";
            this.checkJob.Size = new System.Drawing.Size(121, 17);
            this.checkJob.TabIndex = 0;
            this.checkJob.Text = "Работа выполнена";
            this.checkJob.UseVisualStyleBackColor = true;
            this.checkJob.CheckedChanged += new System.EventHandler(this.checkJob_CheckedChanged);
            // 
            // JobTime
            // 
            this.JobTime.Location = new System.Drawing.Point(9, 9);
            this.JobTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.JobTime.MaxSelectionCount = 365;
            this.JobTime.Name = "JobTime";
            this.JobTime.TabIndex = 1;
            this.JobTime.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.DateSelect);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(46, 234);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(84, 37);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Добавить в отчет";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnRepClick);
            // 
            // meslab
            // 
            this.meslab.AutoSize = true;
            this.meslab.Location = new System.Drawing.Point(6, 210);
            this.meslab.Name = "meslab";
            this.meslab.Size = new System.Drawing.Size(0, 13);
            this.meslab.TabIndex = 4;
            // 
            // CheckingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 280);
            this.Controls.Add(this.meslab);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.JobTime);
            this.Controls.Add(this.checkJob);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CheckingForm";
            this.Text = "Checking Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkJob;
        private System.Windows.Forms.MonthCalendar JobTime;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label meslab;
    }
}
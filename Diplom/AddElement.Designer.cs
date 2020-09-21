namespace Diplom
{
    partial class AddElement
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
            this.newdev = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jobscol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newdev
            // 
            this.newdev.Location = new System.Drawing.Point(12, 34);
            this.newdev.Name = "newdev";
            this.newdev.Size = new System.Drawing.Size(100, 20);
            this.newdev.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите название нового устройства";
            // 
            // jobscol
            // 
            this.jobscol.FormattingEnabled = true;
            this.jobscol.Location = new System.Drawing.Point(12, 80);
            this.jobscol.Name = "jobscol";
            this.jobscol.Size = new System.Drawing.Size(371, 21);
            this.jobscol.TabIndex = 2;
            this.jobscol.SelectedIndexChanged += new System.EventHandler(this.selectjob);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Какой вид работ производится ";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(155, 135);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "Добавить";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // AddElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 170);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jobscol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newdev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddElement";
            this.Text = "Add Element";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newdev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox jobscol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnadd;
    }
}
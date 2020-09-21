namespace Diplom
{
    partial class DeleteDevForm
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
            this.DevicesBox = new System.Windows.Forms.ComboBox();
            this.deletebtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DevicesBox
            // 
            this.DevicesBox.FormattingEnabled = true;
            this.DevicesBox.Location = new System.Drawing.Point(12, 12);
            this.DevicesBox.Name = "DevicesBox";
            this.DevicesBox.Size = new System.Drawing.Size(121, 21);
            this.DevicesBox.TabIndex = 0;
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(149, 9);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(75, 35);
            this.deletebtn.TabIndex = 1;
            this.deletebtn.Text = "Удалить устройство";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(149, 70);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Закрыть";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DeleteDevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 118);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.DevicesBox);
            this.Name = "DeleteDevForm";
            this.Text = "DeleteDevForm";
            this.Load += new System.EventHandler(this.DeleteDevForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox DevicesBox;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}
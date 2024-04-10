namespace AK_C_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            plc_info2 = new Label();
            plc_info = new Label();
            SuspendLayout();
            // 
            // plc_info2
            // 
            plc_info2.AutoSize = true;
            plc_info2.Location = new Point(12, 24);
            plc_info2.Name = "plc_info2";
            plc_info2.Size = new Size(42, 15);
            plc_info2.TabIndex = 1;
            plc_info2.Text = "label1";
            plc_info2.Click += label1_Click;
            // 
            // plc_info
            // 
            plc_info.AutoSize = true;
            plc_info.Location = new Point(12, 74);
            plc_info.Name = "plc_info";
            plc_info.Size = new Size(42, 15);
            plc_info.TabIndex = 2;
            plc_info.Text = "label1";
            plc_info.Click += label1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(plc_info);
            Controls.Add(plc_info2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label plc_info2;
        private Label plc_info;
    }
}

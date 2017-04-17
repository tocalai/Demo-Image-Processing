namespace _4DSensorDemo
{
    partial class MainForm
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
            this.Q1_1_Button = new System.Windows.Forms.Button();
            this.Q1_2_Button = new System.Windows.Forms.Button();
            this.Q2_1_Button = new System.Windows.Forms.Button();
            this.Q2_2_Button = new System.Windows.Forms.Button();
            this.Action_Label = new System.Windows.Forms.Label();
            this.Noise1_LinkLabel = new System.Windows.Forms.LinkLabel();
            this.Noise2_LinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Q1_1_Button
            // 
            this.Q1_1_Button.Location = new System.Drawing.Point(46, 46);
            this.Q1_1_Button.Name = "Q1_1_Button";
            this.Q1_1_Button.Size = new System.Drawing.Size(329, 68);
            this.Q1_1_Button.TabIndex = 0;
            this.Q1_1_Button.Text = "One-dimensional Demo";
            this.Q1_1_Button.UseVisualStyleBackColor = true;
            this.Q1_1_Button.Click += new System.EventHandler(this.Q1_1_Button_Click);
            // 
            // Q1_2_Button
            // 
            this.Q1_2_Button.Location = new System.Drawing.Point(46, 164);
            this.Q1_2_Button.Name = "Q1_2_Button";
            this.Q1_2_Button.Size = new System.Drawing.Size(329, 68);
            this.Q1_2_Button.TabIndex = 1;
            this.Q1_2_Button.Text = "Two-dimensional Demo";
            this.Q1_2_Button.UseVisualStyleBackColor = true;
            this.Q1_2_Button.Click += new System.EventHandler(this.Q1_2_Button_Click);
            // 
            // Q2_1_Button
            // 
            this.Q2_1_Button.Location = new System.Drawing.Point(46, 288);
            this.Q2_1_Button.Name = "Q2_1_Button";
            this.Q2_1_Button.Size = new System.Drawing.Size(329, 68);
            this.Q2_1_Button.TabIndex = 2;
            this.Q2_1_Button.Text = "Noise 4-direction Demo";
            this.Q2_1_Button.UseVisualStyleBackColor = true;
            this.Q2_1_Button.Click += new System.EventHandler(this.Q2_1_Button_Click);
            // 
            // Q2_2_Button
            // 
            this.Q2_2_Button.Location = new System.Drawing.Point(46, 415);
            this.Q2_2_Button.Name = "Q2_2_Button";
            this.Q2_2_Button.Size = new System.Drawing.Size(329, 68);
            this.Q2_2_Button.TabIndex = 3;
            this.Q2_2_Button.Text = "Noise 8-direction Demo";
            this.Q2_2_Button.UseVisualStyleBackColor = true;
            this.Q2_2_Button.Click += new System.EventHandler(this.Q2_2_Button_Click);
            // 
            // Action_Label
            // 
            this.Action_Label.AutoSize = true;
            this.Action_Label.Location = new System.Drawing.Point(20, 535);
            this.Action_Label.Name = "Action_Label";
            this.Action_Label.Size = new System.Drawing.Size(104, 32);
            this.Action_Label.TabIndex = 4;
            this.Action_Label.Text = "Status:";
            // 
            // Noise1_LinkLabel
            // 
            this.Noise1_LinkLabel.AutoSize = true;
            this.Noise1_LinkLabel.Location = new System.Drawing.Point(384, 307);
            this.Noise1_LinkLabel.Name = "Noise1_LinkLabel";
            this.Noise1_LinkLabel.Size = new System.Drawing.Size(199, 32);
            this.Noise1_LinkLabel.TabIndex = 5;
            this.Noise1_LinkLabel.TabStop = true;
            this.Noise1_LinkLabel.Text = "Noise1-Output";
            this.Noise1_LinkLabel.Visible = false;
            this.Noise1_LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Noise1_LinkLabel_LinkClicked);
            // 
            // Noise2_LinkLabel
            // 
            this.Noise2_LinkLabel.AutoSize = true;
            this.Noise2_LinkLabel.Location = new System.Drawing.Point(385, 434);
            this.Noise2_LinkLabel.Name = "Noise2_LinkLabel";
            this.Noise2_LinkLabel.Size = new System.Drawing.Size(199, 32);
            this.Noise2_LinkLabel.TabIndex = 6;
            this.Noise2_LinkLabel.TabStop = true;
            this.Noise2_LinkLabel.Text = "Noise2-Output";
            this.Noise2_LinkLabel.Visible = false;
            this.Noise2_LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Noise2_LinkLabel_LinkClicked);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(728, 612);
            this.Controls.Add(this.Noise2_LinkLabel);
            this.Controls.Add(this.Noise1_LinkLabel);
            this.Controls.Add(this.Action_Label);
            this.Controls.Add(this.Q2_2_Button);
            this.Controls.Add(this.Q2_1_Button);
            this.Controls.Add(this.Q1_2_Button);
            this.Controls.Add(this.Q1_1_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.Button Q1_1_Button;
        private System.Windows.Forms.Button Q1_2_Button;
        private System.Windows.Forms.Button Q2_1_Button;
        private System.Windows.Forms.Button Q2_2_Button;
        private System.Windows.Forms.Label Action_Label;
        private System.Windows.Forms.LinkLabel Noise1_LinkLabel;
        private System.Windows.Forms.LinkLabel Noise2_LinkLabel;
    }
}
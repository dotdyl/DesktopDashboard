namespace DesktopDashboard
{
    partial class Form1
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
            this.containerPanel = new System.Windows.Forms.Panel();
            this.launchButton = new System.Windows.Forms.Button();
            this.openApplicationsList = new System.Windows.Forms.ListBox();
            this.openApplicationsHeader = new System.Windows.Forms.Label();
            this.embedOpenAppsList = new System.Windows.Forms.ListBox();
            this.embedOpenAppsHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.containerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerPanel.Location = new System.Drawing.Point(156, 12);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(993, 603);
            this.containerPanel.TabIndex = 0;
            this.containerPanel.SizeChanged += new System.EventHandler(this.ContainerPanel_SizeChanged);
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(12, 12);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(138, 39);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Open and Embed App";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // openApplicationsList
            // 
            this.openApplicationsList.FormattingEnabled = true;
            this.openApplicationsList.Location = new System.Drawing.Point(12, 227);
            this.openApplicationsList.Name = "openApplicationsList";
            this.openApplicationsList.Size = new System.Drawing.Size(138, 95);
            this.openApplicationsList.TabIndex = 0;
            // 
            // openApplicationsHeader
            // 
            this.openApplicationsHeader.AutoSize = true;
            this.openApplicationsHeader.Location = new System.Drawing.Point(12, 211);
            this.openApplicationsHeader.Name = "openApplicationsHeader";
            this.openApplicationsHeader.Size = new System.Drawing.Size(93, 13);
            this.openApplicationsHeader.TabIndex = 0;
            this.openApplicationsHeader.Text = "Open Applications";
            // 
            // embedOpenAppsList
            // 
            this.embedOpenAppsList.FormattingEnabled = true;
            this.embedOpenAppsList.Location = new System.Drawing.Point(12, 86);
            this.embedOpenAppsList.Name = "embedOpenAppsList";
            this.embedOpenAppsList.Size = new System.Drawing.Size(138, 95);
            this.embedOpenAppsList.TabIndex = 0;
            this.embedOpenAppsList.SelectedIndexChanged += new System.EventHandler(this.embedOpenAppsList_SelectedIndexChanged);
            // 
            // embedOpenAppsHeader
            // 
            this.embedOpenAppsHeader.AutoSize = true;
            this.embedOpenAppsHeader.Location = new System.Drawing.Point(12, 70);
            this.embedOpenAppsHeader.Name = "embedOpenAppsHeader";
            this.embedOpenAppsHeader.Size = new System.Drawing.Size(96, 13);
            this.embedOpenAppsHeader.TabIndex = 1;
            this.embedOpenAppsHeader.Text = "Embed Open Apps";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 627);
            this.Controls.Add(this.embedOpenAppsHeader);
            this.Controls.Add(this.embedOpenAppsList);
            this.Controls.Add(this.openApplicationsHeader);
            this.Controls.Add(this.openApplicationsList);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.containerPanel);
            this.Name = "Form1";
            this.Text = "Desktop Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.ListBox openApplicationsList;
        private System.Windows.Forms.Label openApplicationsHeader;
        private System.Windows.Forms.ListBox embedOpenAppsList;
        private System.Windows.Forms.Label embedOpenAppsHeader;
    }
}


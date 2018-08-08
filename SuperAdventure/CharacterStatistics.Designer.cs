namespace SuperAdventure
{
    partial class CharacterStatistics
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
            this.cboHelm = new System.Windows.Forms.ComboBox();
            this.cboHands = new System.Windows.Forms.ComboBox();
            this.cboPants = new System.Windows.Forms.ComboBox();
            this.cboChest = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboHelm
            // 
            this.cboHelm.FormattingEnabled = true;
            this.cboHelm.Location = new System.Drawing.Point(12, 12);
            this.cboHelm.Name = "cboHelm";
            this.cboHelm.Size = new System.Drawing.Size(121, 21);
            this.cboHelm.TabIndex = 0;
            // 
            // cboHands
            // 
            this.cboHands.FormattingEnabled = true;
            this.cboHands.Location = new System.Drawing.Point(12, 93);
            this.cboHands.Name = "cboHands";
            this.cboHands.Size = new System.Drawing.Size(121, 21);
            this.cboHands.TabIndex = 1;
            // 
            // cboPants
            // 
            this.cboPants.FormattingEnabled = true;
            this.cboPants.Location = new System.Drawing.Point(12, 66);
            this.cboPants.Name = "cboPants";
            this.cboPants.Size = new System.Drawing.Size(121, 21);
            this.cboPants.TabIndex = 2;
            // 
            // cboChest
            // 
            this.cboChest.FormattingEnabled = true;
            this.cboChest.Location = new System.Drawing.Point(12, 39);
            this.cboChest.Name = "cboChest";
            this.cboChest.Size = new System.Drawing.Size(121, 21);
            this.cboChest.TabIndex = 3;
            // 
            // CharacterStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.cboChest);
            this.Controls.Add(this.cboPants);
            this.Controls.Add(this.cboHands);
            this.Controls.Add(this.cboHelm);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "CharacterStatistics";
            this.ShowIcon = false;
            this.Text = "CharacterStatistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterStatistics_FormClosing);
            this.LocationChanged += new System.EventHandler(this.CharacterStatistics_LocationChanged);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cboHelm;
        public System.Windows.Forms.ComboBox cboHands;
        public System.Windows.Forms.ComboBox cboPants;
        public System.Windows.Forms.ComboBox cboChest;
    }
}
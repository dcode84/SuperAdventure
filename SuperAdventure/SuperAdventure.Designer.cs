﻿namespace SuperAdventure
{
    partial class SuperAdventure
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelHitPoints = new System.Windows.Forms.Label();
            this.labelGold = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.selectionLabel = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.experienceProgressBar = new CustomControls.CustomProgressBar();
            this.labelDamageReduction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // labelHitPoints
            // 
            this.labelHitPoints.AutoSize = true;
            this.labelHitPoints.Location = new System.Drawing.Point(110, 19);
            this.labelHitPoints.Name = "labelHitPoints";
            this.labelHitPoints.Size = new System.Drawing.Size(13, 13);
            this.labelHitPoints.TabIndex = 4;
            this.labelHitPoints.Text = "0";
            // 
            // labelGold
            // 
            this.labelGold.AutoSize = true;
            this.labelGold.Location = new System.Drawing.Point(110, 45);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(13, 13);
            this.labelGold.TabIndex = 5;
            this.labelGold.Text = "0";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(110, 99);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(13, 13);
            this.labelLevel.TabIndex = 7;
            this.labelLevel.Text = "0";
            // 
            // selectionLabel
            // 
            this.selectionLabel.AutoSize = true;
            this.selectionLabel.Location = new System.Drawing.Point(499, 541);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.Size = new System.Drawing.Size(69, 13);
            this.selectionLabel.TabIndex = 8;
            this.selectionLabel.Text = "Select action";
            this.selectionLabel.Visible = false;
            // 
            // cboWeapons
            // 
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(369, 559);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 21);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(369, 593);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 21);
            this.cboPotions.TabIndex = 10;
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(496, 557);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Use";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(496, 593);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(75, 23);
            this.btnUsePotion.TabIndex = 12;
            this.btnUsePotion.Text = "Use";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(493, 433);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(75, 23);
            this.btnNorth.TabIndex = 13;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(573, 457);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(75, 23);
            this.btnEast.TabIndex = 14;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(493, 487);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(75, 23);
            this.btnSouth.TabIndex = 15;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(412, 457);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(75, 23);
            this.btnWest.TabIndex = 16;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(347, 19);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbLocation.Size = new System.Drawing.Size(360, 40);
            this.rtbLocation.TabIndex = 17;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(347, 65);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(360, 351);
            this.rtbMessages.TabIndex = 18;
            this.rtbMessages.Text = "";
            this.rtbMessages.TextChanged += new System.EventHandler(this.rtbMessages_TextChanged);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Location = new System.Drawing.Point(16, 130);
            this.dgvInventory.MaximumSize = new System.Drawing.Size(312, 309);
            this.dgvInventory.MinimumSize = new System.Drawing.Size(312, 200);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(312, 200);
            this.dgvInventory.TabIndex = 19;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(16, 446);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.Size = new System.Drawing.Size(312, 189);
            this.dgvQuests.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 559);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Character";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCharacter_Click);
            // 
            // experienceProgressBar
            // 
            this.experienceProgressBar.Location = new System.Drawing.Point(87, 71);
            this.experienceProgressBar.Name = "experienceProgressBar";
            this.experienceProgressBar.Size = new System.Drawing.Size(128, 22);
            this.experienceProgressBar.TabIndex = 22;
            // 
            // labelDamageReduction
            // 
            this.labelDamageReduction.AutoSize = true;
            this.labelDamageReduction.Location = new System.Drawing.Point(270, 45);
            this.labelDamageReduction.Name = "labelDamageReduction";
            this.labelDamageReduction.Size = new System.Drawing.Size(13, 13);
            this.labelDamageReduction.TabIndex = 23;
            this.labelDamageReduction.Text = "0";
            // 
            // SuperAdventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.labelDamageReduction);
            this.Controls.Add(this.experienceProgressBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.selectionLabel);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelGold);
            this.Controls.Add(this.labelHitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(735, 690);
            this.MinimumSize = new System.Drawing.Size(735, 690);
            this.Name = "SuperAdventure";
            this.ShowIcon = false;
            this.Text = "Super Adventure";
            this.Load += new System.EventHandler(this.SuperAdventure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelHitPoints;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.Button button1;
        private CustomControls.CustomProgressBar experienceProgressBar;
        private System.Windows.Forms.Label labelDamageReduction;
        public System.Windows.Forms.RichTextBox rtbMessages;
        public System.Windows.Forms.Label selectionLabel;
        public System.Windows.Forms.ComboBox cboWeapons;
        public System.Windows.Forms.ComboBox cboPotions;
        public System.Windows.Forms.Button btnUseWeapon;
        public System.Windows.Forms.Button btnUsePotion;
    }
}


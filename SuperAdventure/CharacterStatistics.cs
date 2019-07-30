using Engine;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperAdventure
{
    public partial class CharacterStatistics : Form
    {
        public const int _offset = -14;
        private readonly SuperAdventure _originalParent;

        public CharacterStatistics(SuperAdventure _parentForm)
        {
            InitializeComponent();
            _originalParent = _parentForm;
        }

        private void CharacterStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _originalParent.charStatisticIsOpen = false;
            e.Cancel = true;
        }

        private void CharacterStatistics_Load(object sender, EventArgs e)
        {
            SetCharacterStatisticsLocation();
            UpdateEquipmentListInUI();
            SetCharacterStats();
        }

        private void SetCharacterStatisticsLocation()
        {
            this.Left = _originalParent.Left + _originalParent.Width + _offset;
            this.Top = _originalParent.Top;
        }

        private void UpdateEquipmentListInUI()
        {
            UpdateHelmListInUI();
            UpdateChestListInUI();
            UpdatePantsListInUI();
            UpdateGlovesListInUI();
        }

        private void SetCharacterStats()
        {
            dgvStats.RowHeadersVisible = false;
            dgvStats.ColumnHeadersVisible = false;
            dgvStats.ColumnCount = 2;
            dgvStats.Columns[0].Width = 87;
            dgvStats.Columns[1].Width = 30;

            dgvStats.DefaultCellStyle.SelectionBackColor = dgvStats.DefaultCellStyle.BackColor;
            dgvStats.DefaultCellStyle.SelectionForeColor = dgvStats.DefaultCellStyle.ForeColor;
            dgvStats.Rows.Add("Strength", _originalParent.player.Strength.ToString());
            dgvStats.Rows.Add("Intelligence", _originalParent.player.Intelligence.ToString());
            dgvStats.Rows.Add("Vitality", _originalParent.player.Vitality.ToString());
            dgvStats.Rows.Add("Defense", _originalParent.player.Defense.ToString());

            dgvStats.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void UpdateHelmListInUI()
        {
            List<ArmorHelm> helmets = new List<ArmorHelm>();

            foreach (InventoryItem inventoryItem in _originalParent.player.Inventory)
            {
                if (inventoryItem.Item is ArmorHelm)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        helmets.Add((ArmorHelm)inventoryItem.Item);
                    }
                }
            }

            if (helmets.Count == 0)
            {
                cboHelm.Text = "Helmet...";
            }
            else
            {
                cboHelm.DataSource = helmets;
                cboHelm.DisplayMember = "Name";
                cboHelm.ValueMember = "ID";
                cboHelm.SelectedItem = 0;
            }
        }

        private void UpdateChestListInUI()
        {
            List<ArmorChest> chests = new List<ArmorChest>();

            foreach (InventoryItem inventoryItem in _originalParent.player.Inventory)
            {
                if (inventoryItem.Item is ArmorChest)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        chests.Add((ArmorChest)inventoryItem.Item);
                    }
                }
            }

            if (chests.Count == 0)
            {
                cboChest.Text = "Chests...";
            }
            else
            {
                cboChest.DataSource = chests;
                cboChest.DisplayMember = "Name";
                cboChest.ValueMember = "ID";
                cboChest.SelectedItem = 0;
            }
        }

        private void UpdatePantsListInUI()
        {
            List<ArmorPants> pants = new List<ArmorPants>();

            foreach (InventoryItem inventoryItem in _originalParent.player.Inventory)
            {
                if (inventoryItem.Item is ArmorPants)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        pants.Add((ArmorPants)inventoryItem.Item);
                    }
                }
            }

            if (pants.Count == 0)
            {
                cboPants.Text = "Pants...";
            }
            else
            {
                cboPants.DataSource = pants;
                cboPants.DisplayMember = "Name";
                cboPants.ValueMember = "ID";
                cboPants.SelectedItem = 0;
            }
        }

        private void UpdateGlovesListInUI()
        {
            List<ArmorGloves> gloves = new List<ArmorGloves>();

            foreach (InventoryItem inventoryItem in _originalParent.player.Inventory)
            {
                if (inventoryItem.Item is ArmorGloves)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        gloves.Add((ArmorGloves)inventoryItem.Item);
                    }
                }
            }

            if (gloves.Count == 0)
            {
                cboHands.Text = "Gloves...";
            }
            else
            {
                cboHands.DataSource = gloves;
                cboHands.DisplayMember = "Name";
                cboHands.ValueMember = "ID";
                cboHands.SelectedItem = 0;
            }
        }

        private void SetDefensePoints()
        {
            ArmorHelm currentHelm = (ArmorHelm)cboHelm.SelectedItem;
            ArmorChest currentChest = (ArmorChest)cboChest.SelectedItem;
            ArmorPants currentPants = (ArmorPants)cboPants.SelectedItem;
            ArmorGloves currentGloves = (ArmorGloves)cboHands.SelectedItem;

            int currentDefensePoints = currentHelm.Defense + currentChest.Defense + currentPants.Defense + currentGloves.Defense;
            _originalParent.player.Defense = currentDefensePoints;
        }
    }
}

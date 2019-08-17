using Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SuperAdventure
{
    public partial class CharacterStatistics : Form
    {
        public const int _offset = -14;

        private readonly SuperAdventure _superAdventure;
        private int _helmDefense;
        private int _chestDefense;
        private int _pantsDefense;
        private int _handsDefense;

        public CharacterStatistics(SuperAdventure superAdventure)
        {
            InitializeComponent();
            _superAdventure = superAdventure;
            UpdateEquipmentListInUI();
        }

        private void CharacterStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _superAdventure.charStatisticIsOpen = false;
            e.Cancel = true;
        }

        private void CharacterStatistics_Load(object sender, EventArgs e)
        {
            SetCharacterStatisticsLocation();
            ConfigureCharacterStatsUI();
        }

        private void SetCharacterStatisticsLocation()
        {
            this.Left = _superAdventure.Left + _superAdventure.Width + _offset;
            this.Top = _superAdventure.Top;
        }

        private void UpdateEquipmentListInUI()
        {
            UpdateHelmListInUI();
            UpdateChestListInUI();
            UpdatePantsListInUI();
            UpdateGlovesListInUI();
        }

        public void ConfigureCharacterStatsUI()
        {
            dgvStats.Rows.Clear();
            dgvStats.RowHeadersVisible = false;
            dgvStats.ColumnHeadersVisible = false;
            dgvStats.ColumnCount = 2;
            dgvStats.Columns[0].Width = 87;
            dgvStats.Columns[1].Width = 30;

            dgvStats.DefaultCellStyle.SelectionBackColor = dgvStats.DefaultCellStyle.BackColor;
            dgvStats.DefaultCellStyle.SelectionForeColor = dgvStats.DefaultCellStyle.ForeColor;
            dgvStats.Rows.Add("Strength", _superAdventure.player.Strength.ToString());
            dgvStats.Rows.Add("Intelligence", _superAdventure.player.Intelligence.ToString());
            dgvStats.Rows.Add("Vitality", _superAdventure.player.Vitality.ToString());
            dgvStats.Rows.Add("Defense", _superAdventure.player.Defense.ToString());
            dgvStats.Rows.Add("StatPoints", _superAdventure.player.StatPoints.ToString());
           
            dgvStats.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            dgvStats.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStats.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvStats.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        }

        private void UpdateHelmListInUI()
        {
            List<ArmorHelm> helmets = new List<ArmorHelm>();

            foreach (InventoryItem inventoryItem in _superAdventure.player.Inventory)
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

            foreach (InventoryItem inventoryItem in _superAdventure.player.Inventory)
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

            foreach (InventoryItem inventoryItem in _superAdventure.player.Inventory)
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

            foreach (InventoryItem inventoryItem in _superAdventure.player.Inventory)
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

        public void SetDefensePoints()
        {
            int currentDefensePoints = _helmDefense + _chestDefense + _pantsDefense + _handsDefense;
            _superAdventure.player.Defense = currentDefensePoints;
        }

        private void CboHelm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmorHelm currentHelm = (ArmorHelm)cboHelm.SelectedItem;
            _helmDefense = currentHelm.Defense;

            SetDefensePoints();
            ConfigureCharacterStatsUI();
        }

        private void CboChest_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmorChest currentChest = (ArmorChest)cboChest.SelectedItem;
            _chestDefense = currentChest.Defense;

            SetDefensePoints();
            ConfigureCharacterStatsUI();
        }

        private void CboPants_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmorPants currentPants = (ArmorPants)cboPants.SelectedItem;
            _pantsDefense = currentPants.Defense;

            SetDefensePoints();
            ConfigureCharacterStatsUI();
        }

        private void CboHands_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmorGloves currentHands = (ArmorGloves)cboHands.SelectedItem;
            _handsDefense = currentHands.Defense;

            SetDefensePoints();
            ConfigureCharacterStatsUI();
        }

        private void DgvStats_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvStats.ClearSelection();
        }
    }
}

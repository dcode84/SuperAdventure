using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine;
using Extensions;
using SuperAdventure.Processes;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        public Player player;
        private Monster _currentMonster;
        private CharacterStatistics charStatistics;
        private QuestProcessor _questMessager;

        public bool charStatisticIsOpen = false;
        public new virtual RightToLeft Right { get; set; }

        public SuperAdventure()
        {
            InitializeComponent();
            charStatistics = new CharacterStatistics(this);
            _questMessager = new QuestProcessor(this);
            player = new Player(20, 1, 0, 1, 1, 1, 0, 10, 10);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            player.Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_RUSTY_SWORD), 1));
            player.Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_HELM), 1));
            player.Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_SHIRT), 1));
            player.Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_PANTS), 1));
            player.Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_GLOVES), 1));
            UpdatePlayerStats();
            dgvInventory.MouseWheel += new MouseEventHandler(dgvInventory_MouseWheel);
            dgvQuests.MouseWheel += new MouseEventHandler(dgvQuests_MouseWheel);
            this.Move += new EventHandler(MoveSubForm);
            this.Resize += new EventHandler(MoveSubForm);

        }

        private void SuperAdventure_Load(object sender, EventArgs e)
        {
            SetInventoryUI();
            SetQuestUI();
            SetCharacterStats();
            dgvInventory.ScrollBars = ScrollBars.None;
            dgvQuests.ScrollBars = ScrollBars.None;
            MoveSubForm(this, e);
        }

        private void rtbMessages_TextChanged(object sender, EventArgs e)
        {
            const int maxIndex = 100;
            const int indexToRemove = 0;
            rtbMessages.SelectionStart = rtbMessages.GetFirstCharIndexFromLine(indexToRemove);
            rtbMessages.SelectionLength = rtbMessages.Lines[indexToRemove].Length + 1;

            if (rtbMessages.Lines.Length > maxIndex)
            {
                rtbMessages.ReadOnly = false;
                rtbMessages.SelectedText = String.Empty;
                rtbMessages.ReadOnly = true;
            }
            ScrollToBottomOfMessages();
        }

        private void dgvInventory_MouseWheel(object sender, MouseEventArgs e)
        {
            int currentIndex = this.dgvInventory.FirstDisplayedScrollingRowIndex;
            int scrollLines = SystemInformation.MouseWheelScrollLines;

            if (currentIndex >= 0)
            {
                if (e.Delta > 0)
                {
                    this.dgvInventory.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
                }

                if (e.Delta < 0)
                {
                    if (this.dgvInventory.Rows.Count > (currentIndex + scrollLines))
                        this.dgvInventory.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
                }
            }
        }

        private void dgvQuests_MouseWheel(object sender, MouseEventArgs e)
        {
            int currentIndex = this.dgvQuests.FirstDisplayedScrollingRowIndex;
            int scrollLines = SystemInformation.MouseWheelScrollLines;

            if (e.Delta > 0)
            {
                this.dgvQuests.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
            }

            if (e.Delta < 0)
            {
                if (this.dgvQuests.Rows.Count > (currentIndex + scrollLines))
                    this.dgvQuests.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
            }
        }

        protected void MoveSubForm(object sender, EventArgs e)
        {
            if (charStatistics != null)
            {
                charStatistics.Left = this.Left + this.Width + CharacterStatistics._offset;
                charStatistics.Top = this.Top;
            }
        }

        private void SetReductionLabel()
        {
            double percentDefense = player.ComputeDamageReduction * 100;
            labelDamageReduction.Text = string.Format("{0:0.00}", percentDefense);
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
                cboWeapons.SelectedIndex = 0;
            }
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToNorth);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToWest);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToEast);
        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items
            if (!player.HasRequiredItemToEnterLocation(newLocation))
            {
                rtbMessages.AppendText("You must have a "
                                       + newLocation.ItemRequiredToEnter.Name + " to enter this location.", true);
                return;
            }

            player.CurrentLocation = newLocation;

            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            rtbLocation.Text = newLocation.Name + Environment.NewLine + newLocation.Description + Environment.NewLine;

            player.CurrentHitPoints = player.MaximumHitPoints;

            labelHitPoints.Text = player.CurrentHitPoints.ToString();

            if (newLocation.QuestAvailableHere != null)
            {
                bool playerAlreadyHasQuest = player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = player.CompletedThisQuest(newLocation.QuestAvailableHere);

                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        if (playerHasAllItemsToCompleteQuest)
                        {
                            QuestCompleted(newLocation);
                        }
                    }
                }
                else
                {
                    GainQuest(newLocation);
                }
            }
            MonsterCheck(newLocation);

            UpdateInventoryList();
            UpdateQuestList();
            UpdateWeaponListInUI();
            UpdatePotionListInUI();
        }

        private void QuestCompleted(Location newLocation)
        {
            bool alreadyRewarded = false;

            if (alreadyRewarded == false)
            {
                _questMessager.CompleteQuestMessage(newLocation);
                _questMessager.RewardQuestMessage(newLocation);
                _questMessager.RewardQuest(newLocation);

                alreadyRewarded = true;
            }
            else
                _questMessager.AlreadyReveicedQuestMessage();
        }

        private void GainQuest(Location newLocation)
        {
            _questMessager.ReceiveQuestMessage(newLocation);
            _questMessager.ReceiveQuest(newLocation);
        }

        private void MonsterCheck(Location newLocation)
        {
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.AppendText("You see a " + newLocation.MonsterLivingHere.Name, true);
                ScrollToBottomOfMessages();

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                selectionLabel.Visible = true;
                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                _currentMonster = null;
                selectionLabel.Visible = false;
                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }
        }

        private void SetCharacterStats()
        {
            charStatistics.dgvStats.RowHeadersVisible = false;
            charStatistics.dgvStats.ColumnHeadersVisible = false;
            charStatistics.dgvStats.ColumnCount = 2;
            charStatistics.dgvStats.Columns[0].Width = 87;
            charStatistics.dgvStats.Columns[1].Width = 30;

            charStatistics.dgvStats.DefaultCellStyle.SelectionBackColor = charStatistics.dgvStats.DefaultCellStyle.BackColor;
            charStatistics.dgvStats.DefaultCellStyle.SelectionForeColor = charStatistics.dgvStats.DefaultCellStyle.ForeColor;
            charStatistics.dgvStats.Rows.Add("Strength", player.Strength.ToString());
            charStatistics.dgvStats.Rows.Add("Intelligence", player.Intelligence.ToString());
            charStatistics.dgvStats.Rows.Add("Vitality", player.Vitality.ToString());
            charStatistics.dgvStats.Rows.Add("Defense", player.Defense.ToString());

            charStatistics.dgvStats.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void SetInventoryUI()
        {
            dgvInventory.DefaultCellStyle.SelectionBackColor = dgvInventory.DefaultCellStyle.BackColor;
            dgvInventory.DefaultCellStyle.SelectionForeColor = dgvInventory.DefaultCellStyle.ForeColor;
            dgvInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvInventory.EnableHeadersVisualStyles = false;
            dgvInventory.GridColor = Color.Gray;

            dgvInventory.RowHeadersVisible = false;
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Quantity";
            dgvInventory.Columns[0].Width = 50;
            dgvInventory.Columns[1].Name = "Name";
            dgvInventory.Columns[1].Width = 259;
        }

        private void SetQuestUI()
        {
            dgvQuests.DefaultCellStyle.SelectionBackColor = dgvQuests.DefaultCellStyle.BackColor;
            dgvQuests.DefaultCellStyle.SelectionForeColor = dgvQuests.DefaultCellStyle.ForeColor;
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 198;
            dgvQuests.Columns[1].Name = "Completed";
            dgvQuests.Columns[1].Width = 110;
        }

        private void UpdateInventoryList()
        {
            dgvInventory.Rows.Clear();
            foreach (InventoryItem inventoryItem in player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Quantity.ToString(), inventoryItem.Details.Name });
                }
            }
        }

        private void UpdateQuestList()
        {
            dgvQuests.Rows.Clear();
            foreach (PlayerQuest playerQuest in player.Quests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdatePotionListInUI()
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach (InventoryItem inventoryItem in player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";
                cboPotions.SelectedIndex = 0;
            }
        }

        public void ScrollToBottomOfMessages()
        {
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void UpdatePlayerStats()
        {
            player.LevelUp();
            charStatistics.statPointsLabel.Text = player.StatPoints.ToString();
            IncreaseExperienceBar();
            // UpdateEquipmentListInUI();
            // SetDefensePoints();
            labelHitPoints.Text = player.CurrentHitPoints.ToString();
            labelGold.Text = player.Gold.ToString();
            labelLevel.Text = player.Level.ToString();
        }

        private void DisplayDamageOnMonster(int damageToMonster)
        {
            _currentMonster.CurrentHitPoints -= damageToMonster;

            if (damageToMonster <= 0)
            {
                rtbMessages.AppendText(Environment.NewLine + "You have missed.", true);
            }
            else
            {
                string playerDPS = Environment.NewLine + "You've hit the "
                                                       + _currentMonster.Name + " for " + damageToMonster.ToString() + " damage.";
                rtbMessages.AppendText(playerDPS, Color.Blue, true);
            }
        }

        private void DisplayVictoryText()
        {
            rtbMessages.AppendText(Environment.NewLine);
            rtbMessages.AppendText("You've defeated the " + _currentMonster.Name + ".", true);
            rtbMessages.AppendText("Gained: ", true);
            rtbMessages.AppendText(_currentMonster.RewardExperiencePoints + " experience", true);
            rtbMessages.AppendText(_currentMonster.RewardGold + " gold", true);
        }

        private void SetExperiencePoints()
        {
            if (_currentMonster.RewardExperiencePoints > player.ComputeExperiencePoints)
            {
                _currentMonster.RewardExperiencePoints = player.ComputeExperiencePoints;
                player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
            }
            else
                player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
        }

        private void SetGold()
        {
            player.Gold += _currentMonster.RewardGold;
        }

        private void RollLoot(List<InventoryItem> lootedItems)
        {
            foreach (LootItem lootItem in _currentMonster.LootTable)
            {
                if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                }
            }
        }

        private void AddItemsToInventory(List<InventoryItem> lootedItems)
        {
            foreach (InventoryItem inventoryItem in lootedItems)
            {
                player.AddItemToInventory(inventoryItem.Details);

                if (inventoryItem.Quantity == 1)
                {
                    rtbMessages.AppendText("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name, true);
                }
                else
                {
                    rtbMessages.AppendText("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural, true);
                }
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;
            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);

            DisplayDamageOnMonster(damageToMonster);

            if (_currentMonster.CurrentHitPoints <= 0)
            {
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                DisplayVictoryText();
                SetExperiencePoints();
                RollLoot(lootedItems);
                AddItemsToInventory(lootedItems);
                UpdateInventoryList();
                UpdatePotionListInUI();
                MoveTo(player.CurrentLocation);
            }
            else
            {
                MonsterDPS();
            }
            UpdatePlayerStats();
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            HealingPotion currentHealingPotion = (HealingPotion)cboPotions.SelectedItem;
            player.CurrentHitPoints += currentHealingPotion.AmountToHeal;

            if (player.CurrentHitPoints > player.MaximumHitPoints)
            {
                int maximumHitPointsExceeded = player.CurrentHitPoints - player.MaximumHitPoints;
                int maximumPossibleHealByPotion = currentHealingPotion.AmountToHeal - maximumHitPointsExceeded;
                player.CurrentHitPoints -= maximumHitPointsExceeded;
                rtbMessages.AppendText("You have healed for " + maximumPossibleHealByPotion.ToString() + " HP", true);
            }
            else
            {
                rtbMessages.AppendText("You have healed for " + currentHealingPotion.AmountToHeal.ToString(), true);
            }
            player.RemoveHealingPotionFromInventory(currentHealingPotion);
            UpdatePlayerStats();
            UpdateInventoryList();
            UpdatePotionListInUI();
            MonsterDPS();
        }

        private void MonsterDPS()
        {
            int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);
            player.CurrentHitPoints -= damageToPlayer;
            string mobDPS = String.Format("The {0} has hit you for {1} damage.", _currentMonster.Name, damageToPlayer.ToString());

            if (damageToPlayer >= 1)
            {
                rtbMessages.AppendText(mobDPS, Color.Red, true);
            }
            else
            {
                rtbMessages.AppendText("The " + _currentMonster.Name + " has missed.", true);
            }

            if (player.CurrentHitPoints <= 0)
            {
                rtbMessages.AppendText(Environment.NewLine + "You have died.", true);
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
            if (charStatisticIsOpen == false)
            {
                charStatistics.Show();
                charStatisticIsOpen = true;
            }
            else
            {
                charStatistics.Hide();
                charStatisticIsOpen = false;
            }
        }

        private void IncreaseExperienceBar()
        {
            experienceProgressBar.Value = player.ExperiencePoints;
            experienceProgressBar.Maximum = player.ComputeExperiencePoints;
        }
    }
}
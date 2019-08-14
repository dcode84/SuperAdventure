using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine;
using Engine.EventArgs;
using Extensions;
using SuperAdventure.Messages;
using SuperAdventure.Processes;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        public Player player;
        //private MessageHandler _gameMessageHandler = new MessageHandler();
        private CharacterStatistics _charStatistics;
        private readonly QuestMessager _questMessager;
        private readonly QuestProcessor _questProcessor;
        public CombatMessager _combatMessager;
        public CombatProcessor _combatProcessor;

        public bool charStatisticIsOpen = false;
        public new virtual RightToLeft Right { get; set; }

        //public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        public SuperAdventure()
        {
            InitializeComponent();
            
            _questMessager = new QuestMessager(this);
            _questProcessor = new QuestProcessor(this);
            _combatMessager = new CombatMessager(this);
            _combatProcessor = new CombatProcessor(this);
            _charStatistics = new CharacterStatistics(this);
            player = new Player(20, 1, 0, 1, 1, 1, 0, 10, 10);
            //OnMessageRaised += DisplayMessage;
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            SetInventoryUI();
            UpdatePlayerStats();
            dgvInventory.MouseWheel += new MouseEventHandler(dgvInventory_MouseWheel);
            dgvQuests.MouseWheel += new MouseEventHandler(dgvQuests_MouseWheel);
            this.Move += new EventHandler(MoveSubForm);
            this.Resize += new EventHandler(MoveSubForm);
            //RaiseInformation("Pewwwwww");
            //RaiseWarning("Meeeeeeeeow", Color.Red);
            //RaiseWarning("fuuuuu", Color.Blue);
        }

        private void SuperAdventure_Load(object sender, EventArgs e)
        {
            SetQuestUI();
            //SetCharacterStats();
            dgvInventory.ScrollBars = ScrollBars.None;
            dgvQuests.ScrollBars = ScrollBars.None;
            MoveSubForm(this, e);
        }

        private void rtbMessages_TextChanged(object sender, EventArgs e)
        {
            DeleteMessagesRowOverflow();
            ScrollToBottomOfMessages();
        }


        //public void RaiseInformation(string message, bool addNewLine = false)
        //{
        //    if (OnMessageRaised != null)
        //    {
        //        OnMessageRaised(this, new GameMessageEventArgs(message, addNewLine));
        //    }
        //}

        //public void RaiseWarning(string message, Color color, bool addNewLine = false)
        //{
        //    if (OnMessageRaised != null)
        //    {
        //        OnMessageRaised(this, new GameMessageEventArgs(message, color, addNewLine));
        //    }
        //}

        public void DisplayMessage(object sender, GameMessageEventArgs gameMessageEventArgs)
        {
            if (gameMessageEventArgs.Color == null)
            {
                rtbMessages.AppendText(gameMessageEventArgs.Message + Environment.NewLine);
            }
            else
            {
                rtbMessages.AppendText(gameMessageEventArgs.Message, gameMessageEventArgs.Color, true);
            }

            if (gameMessageEventArgs.AddNewLine == true)
            {
                rtbMessages.AppendText(Environment.NewLine);
            }

            //ScrollToBottomOfMessages();
        }

        private void DeleteMessagesRowOverflow()
        {
            const int maxIndex = 100;

            SelectMessagesIndex();
            if (rtbMessages.Lines.Length > maxIndex)
            {
                rtbMessages.ReadOnly = false;
                rtbMessages.SelectedText = String.Empty;
                SelectMessagesIndex();
                if (rtbMessages.SelectedText == $"\n")
                {
                    rtbMessages.SelectedText = String.Empty;
                }
                rtbMessages.ReadOnly = true;
            }
            //ScrollToBottomOfMessages();
        }

        private void SelectMessagesIndex()
        {
            const int index = 0;
            rtbMessages.SelectionStart = rtbMessages.GetFirstCharIndexFromLine(index);
            rtbMessages.SelectionLength = rtbMessages.Lines[index].Length + 1;
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
            if (_charStatistics != null)
            {
                _charStatistics.Left = this.Left + this.Width + CharacterStatistics._offset;
                _charStatistics.Top = this.Top;
            }
        }

        private void SetReductionLabel()
        {
            double percentDefense = player.ComputeDamageReduction * 100;
            labelDamageReduction.Text = string.Format("{0:0.00}", percentDefense);
        }

        private void UpdateWeaponListInUI()
        {
            List<IWeapon> weapons = new List<IWeapon>();

            foreach (InventoryItem inventoryItem in player.Inventory)
            {
                if (inventoryItem.Item is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Item);
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

        public void MoveTo(ILocation newLocation)
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
            _combatProcessor.MonsterCheck(newLocation);

            UpdateQuestList();
            UpdateWeaponListInUI();
            UpdatePotionListInUI();
        }

        private void QuestCompleted(ILocation newLocation)
        {
            bool alreadyRewarded = false;

            if (alreadyRewarded == false)
            {
                _questMessager.CompleteQuestMessage(newLocation);
                _questMessager.RewardQuestMessage(newLocation);
                _questProcessor.RewardQuest(newLocation);
                _questProcessor.CompleteQuest(newLocation);

                alreadyRewarded = true;
            }
            else
                _questProcessor.AlreadyReveicedQuestMessage();
        }

        private void GainQuest(ILocation newLocation)
        {
            _questMessager.ReceiveQuestMessage(newLocation);
            _questProcessor.ReceiveQuest(newLocation);
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
            UpdateInventoryList();
        }

        private void SetQuestUI()
        {
            dgvQuests.DefaultCellStyle.SelectionBackColor = dgvQuests.DefaultCellStyle.BackColor;
            dgvQuests.DefaultCellStyle.SelectionForeColor = dgvQuests.DefaultCellStyle.ForeColor;
            dgvQuests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvQuests.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvQuests.EnableHeadersVisualStyles = false;
            dgvQuests.GridColor = Color.Gray;

            dgvQuests.RowHeadersVisible = false;
            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 239;
            dgvQuests.Columns[1].Name = "Completed";
            dgvQuests.Columns[1].Width = 70;
        }

        public void UpdateInventoryList()
        {
            dgvInventory.Rows.Clear();
            foreach (InventoryItem inventoryItem in player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Quantity.ToString(), inventoryItem.Item.Name });
                }
            }
        }

        private void UpdateQuestList()
        {
            dgvQuests.Rows.Clear();
            foreach (PlayerQuest playerQuest in player.Quests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Quest.Name, playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdatePotionListInUI()
        {
            List<IHealingPotion> healingPotions = new List<IHealingPotion>();

            foreach (InventoryItem inventoryItem in player.Inventory)
            {
                if (inventoryItem.Item is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Item);
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
            //_charStatistics.statPointsLabel.Text = player.StatPoints.ToString();
            IncreaseExperienceBar();
            labelHitPoints.Text = player.CurrentHitPoints.ToString();
            labelGold.Text = player.Gold.ToString();
            labelLevel.Text = player.Level.ToString();
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            IWeapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            _combatProcessor.DamageOnMonster(currentWeapon);

            if (_combatProcessor._currentMonster.CurrentHitPoints <= 0)
            {
                UpdateInventoryList();
                UpdatePotionListInUI();
                UpdatePlayerStats();
                MoveTo(player.CurrentLocation);
            }
            else if (player.CurrentHitPoints <= 0)
            {
                _combatProcessor.PlayerDied();
            }
            UpdatePlayerStats();
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            IHealingPotion currentHealingPotion = (IHealingPotion)cboPotions.SelectedItem;
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
            _combatProcessor.MonsterDPS();
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
             _charStatistics.statPointsLabel.Text = player.StatPoints.ToString();

            if (charStatisticIsOpen == false)
            {
                _charStatistics.Show();
                charStatisticIsOpen = true;
            }
            else
            {
                _charStatistics.Hide();
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
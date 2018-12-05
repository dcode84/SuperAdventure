using System;
using System.Windows.Forms;

namespace SuperAdventure
{
    public partial class CharacterStatistics : Form
    {
        SuperAdventure _originalParent;
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
        }

        private void SetCharacterStatisticsLocation()
        {
            this.Left = _originalParent.Left + _originalParent.Width + SuperAdventure._offset;
            this.Top = _originalParent.Top;
        }
    }
}

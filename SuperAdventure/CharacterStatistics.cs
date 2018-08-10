using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperAdventure
{
    public partial class CharacterStatistics : Form
    {
        public CharacterStatistics()
        {
            InitializeComponent();
        }

        private void CharacterStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        //private void CharacterStatistics_LocationChanged(object sender, EventArgs e)
        //{
        //    SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
        //}
    }
}

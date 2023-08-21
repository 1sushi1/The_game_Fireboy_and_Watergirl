using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace ForestMan
{
    public partial class Entry : Form
    {
        public SoundPlayer bgm = new SoundPlayer(Properties.Resources.bgm2);
        public Entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgm.Stop();
            this.Hide();
            frmMain frm = new frmMain();
            frm.ShowDialog();
            this.Close();
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            bgm.PlayLooping();
        }

        private void aboutMe_Click(object sender, EventArgs e)
        {
            frmAboutMe aboutMe = new frmAboutMe();
            aboutMe.ShowDialog();
        }
    }
}

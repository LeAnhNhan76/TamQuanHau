using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace _8QuanHau
{
    public partial class fMayVSMay : Form
    {
        QLBanCo BanCo;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public fMayVSMay()
        {
            player.URL = Application.StartupPath + "\\resources\\Kiss-the-rain.mp3";
            player.controls.play();
            InitializeComponent();

            BanCo = new QLBanCo(pnBanCo);
           
            BanCo.VeBanCo();
            pnBanCo.Enabled = false;         
            tmCoolDown.Enabled = false;
            tmCoolDown.Interval = 1000;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        void NewGame()
        {
            BanCo.VeBanCo();
            pnBanCo.Enabled = false;
        }
      
        private void fMayVSMay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                player.controls.stop();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // BanCo.solveNQ();
            MessageBox.Show("Tro choi bat dau!");
            tmCoolDown.Start();
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        int dem = 0;
        private void btn_sound_Click(object sender, EventArgs e)
        {
            if (dem == 0)
            {
                dem = 1;
                player.controls.pause();
                btn_sound.BackgroundImage = Image.FromFile(Application.StartupPath + "\\resources\\no-sound.png");
            }
            else
            {
                dem = 0;
                player.controls.play();
                btn_sound.BackgroundImage = Image.FromFile(Application.StartupPath + "\\resources\\sound.png");
            }
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            if (BanCo.a == true)
            {
                if (BanCo.solan < 8)
                {
                    BanCo.solveNQ2();

                }
                else
                {
                    tmCoolDown.Stop();
                    MessageBox.Show("Tran dau hoa");
                }

            }
            else
            {
                tmCoolDown.Stop();
                if (BanCo.solan % 2 == 0)
                {
                    MessageBox.Show("May 2 thang");
                }
                else
                {
                    MessageBox.Show("May 1 thang");
                }

            }
        }
    }
}

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
    public partial class fNguoiVSNguoi : Form
    {
        QLBanCo BanCo;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        public fNguoiVSNguoi()
        {
            player.URL = Application.StartupPath + "\\resources\\Kiss-the-rain.mp3";
            //player.controls.play();
            InitializeComponent();
            BanCo = new QLBanCo(pnBanCo, txtNguoi1, pibNguoi1,0);
            BanCo.EndedGame += BanCo_EndedGame;
            BanCo.Playermarked += BanCo_Playermarked;

            prgbCoolDown.Step = Cons.COOL_DOWN_STEP;
            prgbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prgbCoolDown.Value = 0;

            
            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;
            tmCoolDown.Enabled = true;
            BanCo.VeBanCo();
            //tmCoolDown.Start();          
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


        void EndGame()
        {
            tmCoolDown.Stop();
            pnBanCo.Enabled = false;
            MessageBox.Show("Game over!\n"+"Người chiến thắng là: "+ txtNguoi1.Text,"Kết quả ván cờ!");
            btnPause.Enabled = false;
        }
        void NewGame()
        {
            prgbCoolDown.Value = 0;
            tmCoolDown.Stop();
            BanCo.VeBanCo();
            btnPause.Enabled = true;
        }

        private void BanCo_Playermarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            prgbCoolDown.Value = 0;
        }

        private void BanCo_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tmCoolDown_Tick_1(object sender, EventArgs e)
        {
            prgbCoolDown.PerformStep();

            if (prgbCoolDown.Value >= prgbCoolDown.Maximum)
            {
                tmCoolDown.Stop();         
                pnBanCo.Enabled = false;
                btnPause.Enabled = false;
                if(BanCo.CurrentPlayer == 0)
                {
                    MessageBox.Show("Game over!\n" + "Người chiến thắng là: " + BanCo.Player[1].Name, "Kết quả ván cờ!");
                }
                else
                {
                    MessageBox.Show("Game over!\n" + "Người chiến thắng là: " + BanCo.Player[0].Name, "Kết quả ván cờ!");
                }
            }
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fNguoiVSNguoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmCoolDown.Enabled = false;
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                tmCoolDown.Enabled = true;
                e.Cancel = true;
            }
            else
            {
                tmCoolDown.Enabled = false;
                player.controls.stop();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                tmCoolDown.Enabled = false;
                pnBanCo.Enabled = false;
                btnPause.Text = "Start";
                player.controls.pause();


                if (prgbCoolDown.Value < prgbCoolDown.Maximum)
                {
                    if (MessageBox.Show("Tạm Dừng Ván Cờ. Bạn có muốn tiếp tục chơi?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        btnPause.Text = "Pause";
                        pnBanCo.Enabled = true;
                        tmCoolDown.Enabled = true;
                        player.controls.play();

                    }
                }
            }
            else
            {
                btnPause.Text = "Pause";
                pnBanCo.Enabled = true;
                tmCoolDown.Enabled = true;
                player.controls.play();
            }
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
    }
}

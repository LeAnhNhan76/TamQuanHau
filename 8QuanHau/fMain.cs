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
    public partial class fMain : Form
    {
       
        public fMain()
        {
            InitializeComponent();
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

        private void btn_NguoiVSNguoi_Click(object sender, EventArgs e)
        {
            fNguoiVSNguoi NVSN = new fNguoiVSNguoi();
            NVSN.ShowDialog();
        }

        private void btn_MayVSMay_Click(object sender, EventArgs e)
        {
            fMayVSMay MVSM = new fMayVSMay();
            MVSM.ShowDialog();
        }

        private void btn_NguoiVSMay_Click(object sender, EventArgs e)
        {
            fNguoiVSMay NVSM = new fNguoiVSMay();
            NVSM.ShowDialog();
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn tắt ứng dụng?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                MessageBox.Show("Hẹn gặp lại bạn nha!", "Thông báo");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

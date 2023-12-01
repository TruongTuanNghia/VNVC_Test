using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connect;
using VNVC.Model;
using VNVC.Model.UserBet;
using VNVC.Model.UserInfo;
using VNVC.Session;

namespace VNVC
{
    public partial class frtUserBet : Form
    {
        public frtUserBet()
        {
            InitializeComponent();
        }
        ConnectSQL connectSQL = new ConnectSQL();       
        private void frtUserBet_Load(object sender, EventArgs e)
        {          
            lbTitle.Text = $"Bạn đang đặt cược cho slot {DateTime.Now.AddHours(1).Hour} giờ";
            GetUserInfo(UserInfo.PhoneNumber);
            GetResulsBet(UserInfo.PhoneNumber);

        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            try
            {
                var listParameter = new List<SqlParameter>
                {
                    new SqlParameter("@PhoneNumber", UserInfo.PhoneNumber),
                    new SqlParameter("@HourSlot", DateTime.Now.AddHours(1).Hour),
                    new SqlParameter("@NumberBet", nrBet.Value),
                    new SqlParameter("@MoneyBet", txtMoneyBet.Text.Trim())
                };
                var result = connectSQL.ExecuteSP<ResponseResult>("InserBet", listParameter);
                if (result.Result == "1")
                {
                    MessageBox.Show("Đặt cược thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetResulsBet(UserInfo.PhoneNumber);
                }
                else
                {
                    MessageBox.Show("Đặt cược thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Đặt cược thất bại {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMoneyBet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void GetUserInfo(string phone)
        {
            var listParameter = new List<SqlParameter>
                {
                    new SqlParameter("@PhoneNumber", UserInfo.PhoneNumber)

                };
            var result = connectSQL.ExecuteSP<ResponUserInfo>("GetUserInfo", listParameter);
            lbName.Text = $"Chào {result.Name} Ngày sinh { result.BirthDate.ToString().Split(' ')[0]}";
          
        }
        public void GetResulsBet(string phone)
        {
            var listParameter = new List<SqlParameter>
                {
                    new SqlParameter("@PhoneNumber", UserInfo.PhoneNumber)

                };
            var result = connectSQL.ExecuteSPList<ResponResults>("GetResulstBet", listParameter);

            dtgUserBet.DataSource = result.Select(c => new
            {
                DateBet = c.DateBet,
                HourSlot= c.HourSlot,
                NumberBet=c.NumberBet,
                MoneyBet =c.MoneyBet,
                Results =c.Results
            }
            ).ToList();
        }

        private void dtgUserBet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(Color.Red))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        
    }
}

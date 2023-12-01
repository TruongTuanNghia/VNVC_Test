using Connect;
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
using VNVC.Model;
using VNVC.Session;

namespace VNVC
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        ConnectSQL connectSQL = new ConnectSQL();     
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();
            if (phoneNumber.Length==0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }else
            {
                try
                {
                    var listParameter = new List<SqlParameter>
                {
                    new SqlParameter("@PhoneNumber", phoneNumber)
                };
                    var result = connectSQL.ExecuteSP<ResponseResult>("LoginUser", listParameter);
                    if (result.Result == "1")
                    {
                        UserInfo.PhoneNumber = phoneNumber;
                        frtUserBet frmber = new frtUserBet();
                        this.Hide();
                        frmber.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đăng nhập thất bại {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    

        }

        private void lbRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Show();
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}

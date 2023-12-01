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

namespace VNVC
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        ConnectSQL connectSQL = new ConnectSQL();

        private void Register_Load(object sender, EventArgs e)
        {
            dtpBirthDate.MaxDate = DateTime.Now;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();
            if (phoneNumber.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
            {
                try
                {
                    var listParameter = new List<SqlParameter>
                {
                    new SqlParameter("@PhoneNumber", phoneNumber),
                    new SqlParameter("@Name", txtName.Text.Trim()),
                    new SqlParameter("@BirthDate", dtpBirthDate.Value)
                };
                    var result = connectSQL.ExecuteSP<ResponseResult>("InserUser", listParameter);
                    if (result.Result == "1")
                    {
                        MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login = new Login();
                        this.Hide();
                        login.Show();
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đăng ký thất bại {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}

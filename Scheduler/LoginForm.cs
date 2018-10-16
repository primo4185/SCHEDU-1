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

namespace Scheduler
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kccistc\Documents\Data5.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserInfo where Id='" + textBoxID.Text + "' and Pwd = '" + textBoxPwd.Text + "';", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                MainForm mainForm1 = new MainForm();
                mainForm1.Show();

            }
            else
            {
                MessageBox.Show("아이디와 비밀번호를 다시 입력하세요.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentForm = new EnrollmentForm();
            enrollmentForm.Show();
        }
    }
}

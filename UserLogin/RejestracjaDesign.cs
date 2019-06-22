using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserLogin
{
    public partial class RejestracjaDesign : Form
    {
        public RejestracjaDesign()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WIKTOR\Desktop\PeopleCarTransport1\Projekt_PeopleCarTransport\Projekt_PeopleCarTransport\BazaDanych\BD\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
            String str = "insert into tbl_Login(username,password,firstname,lastname,address) values('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtAddress.Text + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Jesteś Zarejestrowany...!!!");
        }

        private void btmDoLogowania_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }
    }
}

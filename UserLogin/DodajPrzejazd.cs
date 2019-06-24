using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserLogin
{
    public partial class DodajPrzejazd : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WIKTOR\Desktop\PeopleCarTransport\BD\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");

        public DodajPrzejazd()
        {
            InitializeComponent();
        }
     


        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into  tbl_Przejazdy values('" + txtImie.Text + "','" + txtSkad.Text + "','" + txtDokad.Text + "','" + txtContact.Text + "','" + dateTimePicker1.Text + "','" + txtGodzina.Text + "','" + numericUpDown1.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            txtImie.Text = "";
            txtSkad.Text = "";
            txtDokad.Text = "";
            txtContact.Text = "";
            dateTimePicker1.Text = "";
            txtGodzina.Text = "";
            numericUpDown1.Text = "0";

            pokarz_przejazdy();
            MessageBox.Show("Przejazd został dodany!!!");

          

        }
        public void pokarz_przejazdy()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_Przejazdy";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

           

        }

        private void DodajPrzejazd_Load(object sender, EventArgs e)
        {
            pokarz_przejazdy();
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tbl_Przejazdy where IdPrzejazdy='" + txtIdPrzejazdy.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            pokarz_przejazdy();
            MessageBox.Show("Przejazd został usunięty!!!");
        }

      

      
    }
}

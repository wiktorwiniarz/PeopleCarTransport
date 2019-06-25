/**
 * @file Kontrolka DodajPrzejazd.cs
 * @autor Wiktor Winiarz
 * @date June 24, 2019
 * @brief Dodanie przejazdu
 * 
 * Ten formularz dotyczy metod dodania przejazdu oraz łączenia z bazą
 */

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
        /**
         * Łączenie z bazą 
         */
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WIKTOR\Desktop\PeopleCarTransport\BD\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");

        public DodajPrzejazd()
        {
            InitializeComponent();
        }


        /// <summary> 
        /// Przycisk zapisu dodania przejazdu 
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
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

        /**Metoda pokazania danych w dataGriedView
         */
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

        /// <summary> 
        /// Jest to metoda która pokazuje przejazdy w kontrolce dodaj przejazd
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void DodajPrzejazd_Load(object sender, EventArgs e)
        {
            pokarz_przejazdy();
        }

        /// <summary> 
        /// Przycisk usunięcia przejazdu z listy przejazdów
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
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

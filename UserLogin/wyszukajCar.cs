/**
 * @file Kontrolka WyszukajCar.cs
 * @autor Wiktor Winiarz
 * @date June 24, 2019
 * @brief Wyszukanie przejazdu
 * 
 * Ten formularz dotyczy metod wyszukania przejazdu oraz łączenia z bazą
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
    public partial class wyszukajCar : UserControl
    {
        /**Łączenie z bazą danych
         */
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WIKTOR\Desktop\PeopleCarTransport\BD\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");

        public wyszukajCar()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Przycisk wyszukania przejazdu
        /// Przez podanie danych skad i dokad chcemy jechac
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
       
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_Przejazdy where skad='" + txtSkad.Text + "'AND dokad='" + txtDokad.Text + "' AND data>='" + dateTimePicker1.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

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
        /// Jest to metoda która pokazuje przejazdy w kontrolce wyszukaj przejazd
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void wyszukajCar_Load(object sender, EventArgs e)
        {
            pokarz_przejazdy();
        }
    }
}

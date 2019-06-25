/**
 * @file Rejestracja.cs
 * @autor Wiktor Winiarz
 * @date June 24, 2019
 * @brief Rejestracja w aplikacji
 * 
 * Ten formularz dotyczy metod rejestracji  i łączenia z bazą
 */

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

        /// <summary> 
        /// Przycisk zamknięcia aplikacji
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary> 
        /// Łączenie z bazą danych
        /// Rejestracja wpisywanie danych personalnych
        /// Potwierdzenie MessageBox o poprawnym zarejestrowaniu
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WIKTOR\Desktop\PeopleCarTransport\BD\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
            String str = "insert into tbl_Login(username,password,firstname,lastname,address) values('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtAddress.Text + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Jesteś Zarejestrowany...!!!");
        }

        /// <summary> 
        /// Nadanie btmLogowania włączenie okna logowania
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void btmDoLogowania_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }
    }
}

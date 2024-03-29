﻿/**
 * @file Logowanie.cs
 * @autor Wiktor Winiarz
 * @date June 24, 2019
 * @brief Logowanie do aplikacji
 * 
 * Ten formularz dotyczy metod logowania  i łączenie z bazą
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Przycisk zamknięcia aplikacji
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary> 
        /// Łączenie z bazą oraz sprawdzanie poprawności danych do zalogowania
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WIKTOR\Desktop\PeopleCarTransport\BD\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from tbl_Login Where username = '" + textUzytkownik.Text.Trim() + "' and password = '" + textHaslo.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                ftmMain objFrmMain = new ftmMain();
                this.Hide();
                objFrmMain.Show();

            }
            else
            {
                MessageBox.Show("Sprawdź swoją nazwę użytkownika i hasło " +
                                "Jeśli nie masz konta zarejestruj się!:) ");
            }
        }

        /// <summary> 
        /// Button do rejestracji
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RejestracjaDesign rejestracja = new RejestracjaDesign();
            rejestracja.Show();
        
        }
    }
}

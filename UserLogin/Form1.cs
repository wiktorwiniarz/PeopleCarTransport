/**
 * @file StronaGlowna.cs
 * @autor Wiktor Winiarz
 * @date June 24, 2019
 * @brief Jest to glowny strona projektu
 * 
 * Ten formularz dotyczy metod strony glownej
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

namespace UserLogin
{
    public partial class ftmMain : Form
    {
        

        public ftmMain()
        {
            InitializeComponent();
            DodajPrzejazd.BringToFront();
        }
        
        private void ftmMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary> 
        /// Przycisk zamknięcia aplikacji
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void Button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        /// <summary> 
        /// Przycisk otwarcia kontrolki dodanie przejazdu
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void btmDodajPrzejazd_Click_1(object sender, EventArgs e)
        {
            DodajPrzejazd.BringToFront();
           
        }

        /// <summary> 
        /// Przycisk otwarcia kontrolki wyszukanie przejazdu
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void btmWyszukajPrzejazd_Click(object sender, EventArgs e)
        {
            wyszukajCar1.BringToFront();
        }

        /// <summary> 
        /// Przycisk wylogowania z aplikacji
        /// </summary> 
        /// <param name="sender"></param>
        ///  <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin logout = new FrmLogin();
            logout.Show();
        }
    }
}

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

 
        //Przycisk zamknięcia
        private void Button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }


      

        private void btmDodajPrzejazd_Click_1(object sender, EventArgs e)
        {
            DodajPrzejazd.BringToFront();
           
        }

        private void btmWyszukajPrzejazd_Click(object sender, EventArgs e)
        {
            wyszukajCar1.BringToFront();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin logout = new FrmLogin();
            logout.Show();
        }
    }
}

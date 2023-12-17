using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RouletteEchte
{
    public partial class Form1 : Form
    {
        //verbinding lagen
        berekenLaag b = new berekenLaag();

        naamKlasse _nk = new naamKlasse();
        veranderKlasse _vk = new veranderKlasse();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //connectie database zodat deze bij het laden getoond wordt
            SQLiteConnection conn = new SQLiteConnection(@"data source=C:/devopsDB/databasesRoulette.db");
            conn.Open();

            string qry = "SELECT * FROM namen";
            SQLiteCommand cmd = new SQLiteCommand(qry, conn);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            //tonen
            dataGridView1.DataSource = dt;
            conn.Close();
            //beweging pijl
            timerSpeedPowerBew.Start();
            timerSpeedPowerHoeveel.Start();
        }
        //foto per foto
        int teller = 0;


        private void timer1_Tick(object sender, EventArgs e)
        {
            //laten draaien roulette (door 'lagg' gaat deze op een random foto uitkomen)
            teller++;
            if (teller >= 37)
            {
                timerSnelheid.Start();
                teller = 0;
            }
            pictureBox1.BackgroundImage = Image.FromFile("../../Resources/sxs_" + teller + ".png");
            if (timer1.Interval >= 120)
            {
                //stoppen timer
                timer1.Stop();

                //b laag gebruiken
                b.Teller = teller;
               
                picVerborgenOpl.Visible = false;
                string naamWin = _nk.GetNaam(b.Getal);
                txtNrOplossing.Text = b.Getal.ToString();

                lblGew.Text = lblGew.Text + naamWin;
                
            }
        }
        
        private void Form1_Click(object sender, EventArgs e)
        {
        }
        int tijdTimer1;
        private void timerSnelheid_Tick(object sender, EventArgs e)
        {
            //vertraging roulette
            tijdTimer1 += 3;
            timer1.Interval = tijdTimer1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void timerSpeed_Tick(object sender, EventArgs e)
        {
            b.PijlLeft = picPijl.Left;
            picPijl.Left = b.PijlLeft;
        }


        private void timerSpeedPowerHoeveel_Tick(object sender, EventArgs e)
        {
        }

        private void picPijlWelkCijferKleur_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void PicStart_CursorChanged(object sender, EventArgs e)
        {
        }

        private void PicStart_MouseHover(object sender, EventArgs e)
        {
        }

        private void PicStart_MouseClick(object sender, MouseEventArgs e)
        {
            panelHulp.Visible = false;
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //tonen info, pauzeren app
            timerSpeedPowerBew.Stop();
            panelHulp.Visible = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //resumen van app
            if (txtNrOplossing.Text == "")
            {
                timerSpeedPowerBew.Start();
            }
            panelHulp.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //bewegen roulette starten
            if (timer1.Interval < 120)
            {
                timer1.Start();
                timerSnelheid.Start();
            }
            //sterkte en balk stoppen
            timerSpeedPowerBew.Stop();
            timerSpeedPowerHoeveel.Stop();
            //met bereken
            tijdTimer1 = tijdTimer1 + b.BalkSnelhd;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sqlconnectie die alles weer laat zien zodat tabel refreshed wordt
            _vk.SetNaam(Convert.ToInt32(txtGekID.Text), txtNwNaam.Text);
            txtGekID.Clear();
            txtNwNaam.Clear();
            SQLiteConnection conn = new SQLiteConnection(@"data source=C:/devopsDB/databasesRoulette.db");
            conn.Open();

            string qry = "SELECT * FROM namen";
            SQLiteCommand cmd = new SQLiteCommand(qry, conn);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // timers stoppen en weer op begininterval zetten
            timer1.Stop();
            timer1.Interval = 10;

            timerSnelheid.Stop();
            timerSnelheid.Interval = 500;

            timerSpeedPowerBew.Stop();
            timerSpeedPowerBew.Interval = 1;

            timerSpeedPowerHoeveel.Stop();
            timerSpeedPowerHoeveel.Interval = 1;

            // Resetten variabelen zoals ze in het begin stonden
            teller = 0;
            tijdTimer1 = 0;
            pictureBox1.BackgroundImage = Image.FromFile("../../Resources/sxs_" + teller + ".png");  // Reset the image
            txtNrOplossing.Text = "";
            lblGew.Text = "";

            //weer starten van pijl
            timerSpeedPowerBew.Start();
            timerSpeedPowerHoeveel.Start();
        }

        private void panelHulp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
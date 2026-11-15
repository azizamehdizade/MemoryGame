using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int xallar = 0;     
        int sehvler = 0;     
        int tapilan = 0;     

        int qirmizi = 0;
        int mavi = 0;
        int yasil = 0;
        int sari = 0;

        int kilid = 0;      
        int netice = 0;    

        Button secilen1;
        Button secilen2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YeniOyun();
        }

        void RengVer(Button b)
        {
            int reng = random.Next(1, 5);

            while ((reng == 1 && qirmizi == 2) ||
                   (reng == 2 && mavi == 2) ||
                   (reng == 3 && yasil == 2) ||
                   (reng == 4 && sari == 2))
            {
                reng = random.Next(1, 5);
            }

            b.Tag = reng;

            if (reng == 1) qirmizi++;
            else if (reng == 2) mavi++;
            else if (reng == 3) yasil++;
            else sari++;

            b.BackColor = Color.Silver;
            b.Text = "";
            b.Enabled = true;
        }

        void RengAc(Button b)
        {
            int reng = Convert.ToInt32(b.Tag);

            if (reng == 1) b.BackColor = Color.Red;
            else if (reng == 2) b.BackColor = Color.Blue;
            else if (reng == 3) b.BackColor = Color.Green;
            else b.BackColor = Color.Yellow;
        }

   
        private void Kart_Click(object sender, EventArgs e)
        {
            if (kilid == 1)
                return;

            Button b = (Button)sender;

            if (b.Enabled == false || b == secilen1)
                return;

            RengAc(b);

            if (secilen1 == null)
            {
                secilen1 = b;
                label5.Text = "";
            }
            else
            {
                secilen2 = b;
                kilid = 1;

                if (secilen1.Tag.ToString() == secilen2.Tag.ToString())
                {
                    // DOĞRU TƏXMİN
                    xallar++;
                    label2.Text = xallar.ToString();

                    secilen1.Text = "✅";
                    secilen2.Text = "✅";
                    label5.Text = "✅";

                    secilen1.Enabled = false;
                    secilen2.Enabled = false;

                    tapilan = tapilan + 2;
                    netice = 1;
                }
                else
                {
                
                    sehvler++;
                    label4.Text = sehvler.ToString();

                    secilen1.Text = "❌";
                    secilen2.Text = "❌";
                    label5.Text = "❌";

                    netice = 0;
                }

                timer1.Start();
            }
        }

        void YeniOyun()
        {
            timer1.Stop();

            xallar = 0;
            sehvler = 0;
            tapilan = 0;

            qirmizi = 0;
            mavi = 0;
            yasil = 0;
            sari = 0;

            kilid = 0;
            netice = 0;

            secilen1 = null;
            secilen2 = null;

            label2.Text = "0";
            label4.Text = "0";
            label5.Text = "";

            RengVer(button1);
            RengVer(button2);
            RengVer(button3);
            RengVer(button4);
            RengVer(button5);
            RengVer(button6);
            RengVer(button7);
            RengVer(button8);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (secilen1 == null || secilen2 == null)
                return;

            label5.Text = "";

            if (netice == 0)
            {
                secilen1.BackColor = Color.Silver;
                secilen2.BackColor = Color.Silver;
                secilen1.Text = "";
                secilen2.Text = "";
            }

            secilen1 = null;
            secilen2 = null;
            kilid = 0;

            if (tapilan == 8)
            {
                kilid = 1;
                MessageBox.Show($"Oyun bitdi!\n\nDüzgün addım (Xal): {xallar}\nSəhv addım: {sehvler}", "Təbriklər", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
        private void button9_Click(object sender, EventArgs e)
        {
            YeniOyun();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Oyundan çıxış edilsinmi?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
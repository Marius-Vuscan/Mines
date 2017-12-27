using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mines
{
    public partial class Form1 : Form
    {
        public Random r = new Random();
        public int i;
        public Form1()
        {
            InitializeComponent();
            //Creator: Marius Vușcan
            //    * = Bomb
            hide();
            draw();
        }
        public void draw()
        {
            Button[] B = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };

            foreach (Button element in B)
            {
                element.Click += delegate
                {
                    element.ForeColor = System.Drawing.Color.SteelBlue;
                    check(element);
                };
            }
        }
        public void hide()
        {
            Button[] B = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            for (int i = 0; i < 25; i++)
            {
                B[i].Visible = false;
            }
        }
        public void show()
        {
            Button[] B = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            for (int i = 0; i < 25; i++)
            {
                B[i].Visible = true;
            }
        }
        public void Shuffle()
        {
            Button[] B = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            for (int i = 0; i < 25; i++)
            {
                int j = i + r.Next(25 - i);
                string x = B[j].Text;
                B[j].Text = B[i].Text;
                B[i].Text = x;
            }
        }
        public void Matrix()
        {
            StakeLabel.Text = "0";
            Button[] B = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            int mines = int.Parse(MinesBox.Text);
            int bet = int.Parse(BetBox.Text);
            //add prize
            int x = (int.Parse(BetBox.Text) * int.Parse(MinesBox.Text) * 2) / 10;
            for (int i = 0; i < 25; i++)
            {
                string d = r.Next(1, x + 1).ToString();
                B[i].Text = "+" + d;

            }
            //add mines
            for (i = 0; i < mines; i++)
            {
                B[i].Text = "*";
            }
            //hide
            for (i = 0; i < 25; i++)
            {
                B[i].ForeColor = System.Drawing.Color.White;
            }
            Shuffle();
        }
        private void stars()
        {
            if (int.Parse(CoinsLabel.Text) >= 500)
            {
                s1.ForeColor = System.Drawing.Color.Gold;
                if (int.Parse(CoinsLabel.Text) >= 5000)
                {
                    s2.ForeColor = System.Drawing.Color.Gold;
                    if (int.Parse(CoinsLabel.Text) >= 50000)
                    {
                        s3.ForeColor = System.Drawing.Color.Gold;
                        if (int.Parse(CoinsLabel.Text) >= 500000)
                        {
                            s4.ForeColor = System.Drawing.Color.Gold;
                        }
                    }
                }
            }
        }
        public void check(Button b)
        {
            //check if is mine
            if (b.Text == "*")
            {
                MessageBox.Show("Boom!");
                Matrix();
                hide();
                if (CoinsLabel.Text == "0")
                {
                    CoinsAddButton.Visible = true;
                }
                PlayButton.Visible = true;
                MaxButton.Visible = true;
                TakeButton.Visible = false;
            }
            else
            {
                //add in stake
                StakeLabel.Text = (int.Parse(StakeLabel.Text) + int.Parse(b.Text)).ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void MaxButton_Click(object sender, EventArgs e)
        {
            BetBox.Text = CoinsLabel.Text;
        }

        private void CoinsAddButton_Click(object sender, EventArgs e)
        {
            CoinsLabel.Text = "50";
            CoinsAddButton.Visible = false;
        }

        private void TakeButton_Click_1(object sender, EventArgs e)
        {
            CoinsLabel.Text = (int.Parse(CoinsLabel.Text) + int.Parse(StakeLabel.Text)).ToString();
            Matrix();
            hide();
            stars();
            PlayButton.Visible = true;
            MaxButton.Visible = true;
            TakeButton.Visible = false;
        }

        private void PlayButton_Click_1(object sender, EventArgs e)
        {
            if (int.Parse(CoinsLabel.Text) <= 0 || int.Parse(CoinsLabel.Text) < int.Parse(BetBox.Text))
            {
                MessageBox.Show("Not enough coins!");
            }
            else
            {
                if (int.Parse(MinesBox.Text) < 3 || int.Parse(MinesBox.Text) > 20)
                {
                    MessageBox.Show("Mines: (3,20)");
                }
                else
                {
                    Matrix();
                    StakeLabel.Text = BetBox.Text;
                    CoinsLabel.Text = (int.Parse(CoinsLabel.Text) - int.Parse(BetBox.Text)).ToString();
                    show();
                    PlayButton.Visible = false;
                    MaxButton.Visible = false;
                    TakeButton.Visible = true;
                }
            }
        }
    }
}
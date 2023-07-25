using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan_Game
{
    public partial class Form1 : Form
    {

        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        bool isgameover;


        int speed = 7;

        int redguyspeed = 9;
        int pinkguyspeed = 9;
        int orangeguyxspeed = 9;
        int orangeguyyspeed = 9;

        int score = 0;

        public Form1()
        {
            InitializeComponent();

            resetgame();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacwoman.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;

                pacwoman.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                pacwoman.Image = Properties.Resources.Up;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                pacwoman.Image = Properties.Resources.down;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

            if(e.KeyCode == Keys.Enter && isgameover == true)
            {
                resetgame();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            txtscore.Text = "Score: " + score;
            if (goleft)
            {
                pacwoman.Left -= speed;
            }
            if (goright)
            {
                pacwoman.Left += speed;
            }
            if (goup)
            {
                pacwoman.Top -= speed;
            }
            if (godown)
            {
                pacwoman.Top += speed;
            }

            if(pacwoman.Left < -10)
            {
                pacwoman.Left = 530;
            }
            if(pacwoman.Left > 530)
            {
                pacwoman.Left = -10;
            }
            if (pacwoman.Top < -10)
            {
                pacwoman.Top = 450;
            }
            if (pacwoman.Top > 450)
            {
                pacwoman.Top = -10;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "coin")
                {

                    if (((PictureBox)x).Bounds.IntersectsWith(pacwoman.Bounds))
                    {
                        this.Controls.Remove(x);
                        score++;
                    }
                }

                if (x is PictureBox && x.Tag == "wall")
                 {

                     if (((PictureBox)x).Bounds.IntersectsWith(pacwoman.Bounds))
                     {
                         gameover();
                         label2.Text = "You Lose! Game Over!";
                     }

                     if (orangeguy.Bounds.IntersectsWith(x.Bounds))
                     {
                         orangeguyxspeed = -orangeguyxspeed;
                     }
                 }

                 if (x is PictureBox && x.Tag == "ghost1" || x.Tag == "ghost2" || x.Tag == "ghost3")
                 {

                     if (((PictureBox)x).Bounds.IntersectsWith(pacwoman.Bounds))
                     {
                        gameover();
                        label2.Text = "You Lose! Game Over!";
                    }

                 }
            }

            redguy.Left += redguyspeed;

            pinkguy.Left += pinkguyspeed;
            
            if (redguy.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                redguyspeed  = -redguyspeed;
            }
          
            else if (redguy.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                redguyspeed = -redguyspeed;
            }
            
            if (pinkguy.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                pinkguyspeed = -pinkguyspeed;
            }
            
            else if (pinkguy.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                pinkguyspeed = -pinkguyspeed;
            }



            if (score == 116)
            {
                gameover();
                label2.Text = "You Win! Game Over!";
            }

            orangeguy.Left -= orangeguyxspeed;

            orangeguy.Top -= orangeguyyspeed;

            if (orangeguy.Left < 0 || orangeguy.Left > 500)
            {
                orangeguyxspeed = -orangeguyxspeed;
            }
            if (orangeguy.Top < 0 || orangeguy.Top > 450)
            {
                orangeguyyspeed = -orangeguyyspeed;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void resetgame()
        {
            txtscore.Text = "Score : 0";
            score = 0;
            isgameover = false;

            pacwoman.Left = 47;
            pacwoman.Top = 246;

            redguy.Left = 250;
            redguy.Top = 65;

            pinkguy.Left = 120;
            pinkguy.Top = 382;

            orangeguy.Left = 300;
            orangeguy.Top = 100;

            timer1.Start();
            label2.Visible = false;

        }

        private void gameover()
        {
            label2.Visible = true;
            isgameover = true;
            timer1.Stop();

        }

        private void pictureBox112_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox107_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox108_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox109_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox110_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox94_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox95_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox96_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox106_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox90_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox91_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox92_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox93_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox79_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox82_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox83_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox84_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox73_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox76_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void redguy_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox111_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

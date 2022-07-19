using Resing_car;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recing_car
{
    public partial class Form1 : Form
    {
        player player1;
        Scena scena;
        Car1 car1;
        Line line;
        Finis finiis;
        bool isFinis;
        End end;
        Label liv;
        public Form1()
        {
            InitializeComponent();
            scena = new Scena();
            car1 = new Car1();
            line = new Line();
            finiis = new Finis();
            isFinis = false;
            liv = new Label();
            liv.Text = "Live ";
            liv.Location = new Point(30, 530);
            CreateCar.Interval = 4000;
            MuveCar.Interval = 80;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            player1 = new player(YourName.Text);
            this.Controls.Clear();
            this.Controls.Add(line.LeftLine);
            this.Controls.Add(line.RightLine);
            this.Controls.Add(car1.car);
            this.Controls.Add(liv);
            CreateCar.Start();
            MuveCar.Start();
        }

        private void YourName_Validating(object sender, CancelEventArgs e)
        {
            if (YourName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(YourName, "Your name is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(YourName, null);
                e.Cancel = false;
            }
        }

        private void CreateCar_Tick(object sender, EventArgs e)
        {
            if (player1.Points < 15)
            {
                Cars c = new Cars();
                scena.Add(c);
                foreach (Cars cc in scena.cars)
                {
                    this.Controls.Add(cc.car);
                }
            }
            else
            {
                end = new End();

                this.Controls.Add(end.finis);
                CreateCar.Stop();
            }
            Remuve();
        }

        private void MuveCar_Tick(object sender, EventArgs e)
        {
            if (player1.Points > 15)
            {
                bool fin = end.Move(10);
                if (fin)
                {
                    Over();
                }
            }
            liv.Text = "LIVE " + player1.life;
            scena.Move();
            collision();
            Remuve();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isFinis == true && e.KeyCode == Keys.R)
            {
                Application.Restart();
            }
            if (isFinis == true && e.KeyCode == Keys.C)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Left)
            {
              if(car1.car.Left>20)
                car1.Move(-10);
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (car1.car.Left < 550)
                    car1.Move(10);
            }
        }
        public void collision()
        {
            if (scena.cars.Count > 0)
            {

                foreach (Cars c in scena.cars)
                {

                    Point l1 = new Point(c.car.Location.X, c.car.Location.Y);
                    Point r1 = new Point(l1.X + c.car.Width, l1.Y - c.car.Height);

                    Point l2 = new Point(car1.car.Location.X, car1.car.Location.Y);
                    Point r2 = new Point(l2.X + car1.car.Width, l2.Y - car1.car.Height);


                    if (doOverlap(l1, r1, l2, r2))
                    {
                        c.collision = true;
                        this.Controls.Remove(c.car);
                        player1.life--;
                        if (player1.life == 0)
                        {

                            Over();
                        }

                    }
                }
                scena.RemuveCollision();
            }
        }
        public bool doOverlap(Point l1, Point r1, Point l2, Point r2)
        {

            if (l1.X > r2.X || l2.X > r1.X)
            {
                return false;
            }

            if (l1.Y < r2.Y || l2.Y < r1.Y)
            {
                return false;
            }
            return true;
        }
        public void Remuve()
        {

            foreach (Cars c in scena.cars)
            {
                if (c.flag == true)
                {
                    this.Controls.Remove(c.car);
                    player1.Points++;
                }
            }
            scena.Remuve();
        }

        public void Over()
        {
            isFinis = true;
            Label info = new Label();
            info.Text = "For a new game push   R    for closing push   C";
            info.BackColor = Color.White;
            info.ForeColor = Color.Red;
            info.Location = new Point(230, 10);
            info.Width = 230;
            Label name = new Label();
            name.Text = "Name: " + player1.Name;
            name.ForeColor = Color.Red;
            name.Location = new Point(290, 220);
            name.BackColor = Color.White;
            Label points = new Label();
            points.Text = "Points: " + player1.Points;
            points.ForeColor = Color.Red;
            points.BackColor = Color.White;
            points.Location = new Point(290, 237);
            if (player1.life == 0)
            {
                this.Controls.Add(finiis.GameOver);
            }
            else
            {
                this.Controls.Add(finiis.finiss);
            }
            this.Controls.Add(points);
            this.Controls.Add(name);
            this.Controls.Add(info);
            CreateCar.Stop();
            MuveCar.Stop();
            foreach (Cars c in scena.cars)
            {
                this.Controls.Remove(c.car);
            }
            liv.Text = "LIVE " + player1.life;
        }
    }
}

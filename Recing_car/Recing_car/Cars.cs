using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Resing_car
{
    public class Cars
    {
        public PictureBox car { set; get; }
        public Random randomPoint = new Random();
        public Random randomImage = new Random();
        public bool flag { set; get; }
        public bool collision { set; get; }
        public Cars()
        {
            int ra = randomImage.Next(0, 3);
            car = new PictureBox();
            if (ra == 1)
            {
                car.Image = Recing_car.Properties.Resources.car3_removebg_preview;
            }
            else if (ra == 2)
            {
                car.Image = Recing_car.Properties.Resources.car1_removebg_preview;
            }
            else
            {
                car.Image = Recing_car.Properties.Resources._2car_removebg_preview;
            }
        
            car.Location = new Point(randomPoint.Next(0, 550), -190);
            car.Width = 100;
            car.Height = 190;
            flag = false;
            collision = false;

        }
        public void Move(int index)
        {
            Point p = car.Location;
            p.Y += index;
            car.Location = p;

        }


    }
}

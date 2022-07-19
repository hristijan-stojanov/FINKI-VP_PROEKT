using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Resing_car
{
    public class Car1
    {

        public PictureBox car { get; set; }

        public Car1()
        {
            car = new PictureBox();
            car.Location = new Point(280, 350);
            car.Height = 180;
            car.Width = 90;
             car.Image=Recing_car.Properties.Resources.car1_removebg_preview ;
        }
        public void Move(int index)
        {
            Point p = car.Location;
            p.X += index;
            
            
                car.Location = p;
            
        }


    }
}
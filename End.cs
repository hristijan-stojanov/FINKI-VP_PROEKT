using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Resing_car
{
    public class End
    {
        public PictureBox finis { set; get; }
        public End()
        {
            finis = new PictureBox();
            finis.Width = 900;
            finis.Height = 150;
            finis.Location = new Point(20, -150);
             finis.Image = Recing_car.Properties.Resources.finisss;

        }
        public bool Move(int index)
        {
            if (finis.Location.Y < 500)
            {
                finis.Location = new Point(finis.Location.X, finis.Location.Y + index);
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

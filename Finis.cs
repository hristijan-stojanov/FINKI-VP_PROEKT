using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Resing_car
{
    public class Finis
    {
        public PictureBox GameOver { set; get; }
        public PictureBox finiss { get; set; }
        public Finis()
        {
            GameOver = new PictureBox();
            GameOver.Location = new Point(155, 30);
            GameOver.Width = 370;
            GameOver.Height = 170;
            GameOver.Image = Recing_car.Properties.Resources.gam_over_removebg_preview;
            finiss = new PictureBox();
            finiss.Location = new Point(130, 80);
            finiss.Width = 570;
            finiss.Height = 130;
             finiss.Image = Recing_car.Properties.Resources._1win_removebg_preview;

        }
    }
}

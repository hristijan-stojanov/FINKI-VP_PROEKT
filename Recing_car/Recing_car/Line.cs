using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Resing_car
{
    public class Line
    {
        public PictureBox LeftLine { get; set; }
        public PictureBox RightLine { get; set; }
        public Line()
        {
            LeftLine = new PictureBox();
            LeftLine.Location = new Point(0, 0);
            LeftLine.Height = 600;
            LeftLine.Width = 20;
            LeftLine.BackColor = Color.White;

            RightLine = new PictureBox();
            RightLine.Location = new Point(642, 0);
            RightLine.Height = 600;
            RightLine.Width = 20;
            RightLine.BackColor = Color.White;
        }
    }
}

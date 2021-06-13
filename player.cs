using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resing_car
{
    public class player
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int life { get; set; }
        public player(string Name)
        {
            this.Name = Name;
            this.Points = 0;
            this.life = 3;
        }
    }
}

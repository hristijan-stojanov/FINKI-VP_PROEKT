using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resing_car
{
    public class Scena
    {
        public List<Cars> cars { set; get; }
        public Scena()
        {
            cars = new List<Cars>();
        }
        public void Move()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].car.Location.Y > 550)
                {
                    cars[i].flag = true;
                }
                cars[i].Move(10);
            }
        }
        public void Add(Cars c)
        {
            cars.Add(c);
        }
        public void Remuve()
        {
            var remuv = cars.SingleOrDefault(r => r.flag == true);
            if (remuv != null)
            {
                cars.Remove(remuv);
            }
        }
        public void RemuveCollision()
        {
            var remuv1 = cars.SingleOrDefault(r => r.collision == true);
            if (remuv1 != null)
            {
                cars.Remove(remuv1);
            }
        }
    }
}

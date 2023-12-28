using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Satellite : BaseEntity
    {
        private int planetId;

        public Satellite(int id, string name, int temperature, int humidity, int windSpeed, int pressure, int planetId) : base(id, name, temperature, humidity, windSpeed, pressure)
        {
            PlanetId = planetId;
        }

        public int PlanetId { get => planetId; set => planetId = value; }
    }
}

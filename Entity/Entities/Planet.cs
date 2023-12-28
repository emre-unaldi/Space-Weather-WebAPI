using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Planet : BaseEntity
    {
        private int countOfSatellite;

        public Planet(int id, string name, int temperature, int humidity, int windSpeed, int pressure, int countOfSatellite) : base(id, name, temperature, humidity, windSpeed, pressure)
        {
            CountOfSatellite = countOfSatellite;
        }

        public Planet(){}

        public int CountOfSatellite { get => countOfSatellite; set => countOfSatellite = value; }
    }
}

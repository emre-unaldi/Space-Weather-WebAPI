using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class SatelliteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
        public int Pressure { get; set; }
        public int PlanetId { get; set; }
        public string PlanetName { get; set; }
    }
}

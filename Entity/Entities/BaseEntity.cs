using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private string name;
        private int temperature;
        private int humidity;
        private int windSpeed;
        private int pressure;

        public BaseEntity(int id, string name, int temperature, int humidity, int windSpeed, int pressure)
        {
            Id = id;
            Name = name;
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
            Pressure = pressure;
        }

        public BaseEntity(){}

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Temperature { get => temperature; set => temperature = value; }
        public int Humidity { get => humidity; set => humidity = value; }
        public int WindSpeed { get => windSpeed; set => windSpeed = value; }
        public int Pressure { get => pressure; set => pressure = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Windows.Model
{
    internal record Brand
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        public Brand(string name)
        {
            Name = name;
        }
    }

    internal record Car
    {
        [XmlElement("color")]
        public string Color { get; set; }

        [XmlElement("year")]
        public int Year;

        [XmlElement("brand")]
        public Brand Brand { get; set; }
        public Car(string color, int year, Brand brand)
        {
            Color = color;
            this.Year = year;
            Brand = brand;
        }


    }
}

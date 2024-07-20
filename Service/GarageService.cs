using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Model;
using Windows.Repository;

namespace Windows.Service
{
    internal class GarageService
    {
        private static Car? ProcessCar(XElement car)
        {
            bool parsed = int.TryParse(car.Element("year")?.Value, out int year);
            if (!parsed)
            {
                return null;
            }

            var color = car.Element("color")?.Value ?? string.Empty;

            var brandEl = car.Element("author");

            if (brandEl == null)
            {
                return null;
            }

            var name = brandEl.Attribute("name")?.Value ?? string.Empty;

            ImmutableList<string> validations = [color, color, name];

            if (validations.Any(string.IsNullOrWhiteSpace))
            {
                return null;
            }

            var brand = new Brand(name);
            return new(color, year, brand);
        }
        public static ImmutableList<Car> ReadXML(string path)
        {
            try
            {
                var doc = XDocument.Load(path);
                return doc.Descendants("car")
                    .Select(ProcessCar)
                    .Where(x => x != null)
                    .Select(x => x!)
                    .ToImmutableList();
            }
            catch (Exception)
            {
                return [];
            }
        }

        public static void WriteXml(ImmutableList<Car> cars, string path)
        {
            var doc = new XDocument(
                new XElement("garage",
                    cars.Select(car =>
                        new XElement("car",
                            new XElement("color", car.Color),
                            new XElement("year", car.Year),
                            new XElement(
                                "brand",
                                new XAttribute("name", car.Brand.Name)
                            )
                        )
                    )
                )
            );
            doc.Save(path);
        }

        // Create (Add a new car)
        public static ImmutableList<Car> AddCar(ImmutableList<Car> cars, Car newCar)
        {
            return (
                from car in cars.Add(newCar)
                select car
            ).ToImmutableList();
        }

        // Read (Filter cars by brand)
        public static ImmutableList<Car> GetCarsByBrand(ImmutableList<Car> cars, string brandName)
        {
            return (
                from car in cars
                where car.Brand.Name.Equals(brandName, StringComparison.OrdinalIgnoreCase)
                select car
            ).ToImmutableList();
        }

        // Update (Update car color)
        public static ImmutableList<Car> UpdateCarColor(ImmutableList<Car> cars, string brandName, int year, string newColor)
        {
            return (
                from car in cars
                select (car.Brand.Name == brandName && car.Year == year)
                    ? car with { Color = newColor }
                    : car
            ).ToImmutableList();
        }

        // Delete (Remove a car)
        public static ImmutableList<Car> RemoveCar(ImmutableList<Car> cars, string brandName, int year)
        {
            return (
                from car in cars
                where !(car.Brand.Name == brandName && car.Year == year)
                select car
            ).ToImmutableList();
        }

        // Filter cars by year range
        public static ImmutableList<Car> FilterCarsByYearRange(ImmutableList<Car> cars, int startYear, int endYear)
        {
            return (
                from car in cars
                where car.Year >= startYear && car.Year <= endYear
                select car
            ).ToImmutableList();
        }

        // Group cars by brand
        public static IEnumerable<IGrouping<string, Car>> GroupCarsByBrand(ImmutableList<Car> cars)
        {
            return from car in cars
                   group car by car.Brand.Name into brandGroup
                   select brandGroup;
        }
    }

}

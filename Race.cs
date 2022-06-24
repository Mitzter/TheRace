using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        private string name;
        private int capacity;

        public Race(string name, int capacity)
        {
            Data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public List<Racer> Data { get; private set; }

        public void Add(Racer Racer)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            
            if (Data.Contains(Data.Find(x => x.Name == name)))
            {
                Data.Remove(Data.Find(x => x.Name == name));
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            Data.OrderByDescending(x => x.Age);
            Racer thisRacer = Data.FirstOrDefault();
            return thisRacer;
        }

        public Racer GetRacer(string name)
        {
           Racer thisRacer = Data.Find(x => x.Name == name);
            return thisRacer;
        }
        public Racer GetFastestRacer()
        {
            List<Car> car = new List<Car>();
            foreach (var racer in Data)
            {
                car.Add(racer.Car);
            }
            car.OrderBy(x => x.Speed);
            Car fastestCar = car.Last();
            Racer racerman = Data.Find(x => x.Car == fastestCar);
            return racerman;            
        }
        public int Count => this.Data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}");
            foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}

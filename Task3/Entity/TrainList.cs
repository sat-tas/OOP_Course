using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Entity
{
    public class TrainList
    {
        private List<Train> trains;

        public TrainList()
        {
            this.trains = new List<Train>();
        }

        public int Count { get => trains.Count; }
        
        public Train this[int index]
        {
            get
            {
                if (index < 0 || index >= trains.Count)
                    throw new ArgumentOutOfRangeException($"{nameof(index)} out of range");
                return trains[index];
            }

            set
            {
                if (index < 0 || index >= trains.Count)
                    throw new ArgumentOutOfRangeException($"{nameof(index)} out of range");
                trains[index]= value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public void Add(Train train)
        {
            trains.Add(train);
        }

        public void Add(string ost, int number, TimeSpan time)
        {
            trains.Add(new Train(ost,number,time));
        }

        public Train Reamove(int index)
        {
            if (index < 0 || index >= trains.Count)
                throw new ArgumentOutOfRangeException($"{nameof(index)} out of range");
            Train value = trains[index];
            trains.RemoveAt(index);
            return value; 
        }

        public bool ReadFromFile(string path)
        {
            if (path == null)
                throw new ArgumentNullException($"{nameof(path)} is null");
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int n;
                    if (!Int32.TryParse(sr.ReadLine(), out n))
                        throw new Exception($"No supported file format");
                    for (int i = 0; i < n; i++)
                    {
                        string name = sr.ReadLine();
                        int number = Convert.ToInt32(sr.ReadLine());
                        TimeSpan time = TimeSpan.Parse(sr.ReadLine());
                        Add(name, number, time);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WriteToFile(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(trains.Count);
                    for(int i=0;i<trains.Count;i++)
                    {
                        sw.WriteLine(trains[i].Ost);
                        sw.WriteLine(trains[i].Number);
                        sw.WriteLine(trains[i].Time);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Train[] ToArray()
        {
            return trains.ToArray();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < trains.Count; i++)
            {
                stringBuilder.Append($"{trains[i]}\n");
            }
            return stringBuilder.ToString();
        }
    }

}

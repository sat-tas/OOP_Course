using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Entity
{
    public class TrainSortAndFind
    {
        private delegate int Cmp(Train arg1, Train arg2);

        private string fieldForCompare;

        private Cmp cmp;

        private TrainList trains;

        public TrainSortAndFind(string fieldForCompare, TrainList trains)
        {
            this.fieldForCompare = fieldForCompare ?? throw new ArgumentNullException(nameof(fieldForCompare));
 
            this.trains = trains ?? throw new ArgumentNullException(nameof(trains));
        }

        public TrainList Sort()
        {
            switch (fieldForCompare)
            {
                case "Ost":
                    {
                        cmp = ostCmp;
                        break;
                    }
                case "Number":
                    {
                        cmp = numberCmp;
                        break;
                    }
                case "Time":
                    {
                        cmp = timeCmp;
                        break;
                    }
                default:
                    throw new ArgumentException();
            }
            return QuickSort(trains, 0, trains.Count - 1);
        }

        public List<Train> Find<T>(T value)
        {
            Type type = value.GetType();
            List<Train> result = new List<Train>();
            switch (type.Name)
            {
                case "String":
                    {
                        for (int i=0;i<trains.Count;i++)
                        {
                            if (trains[i].Ost.Equals(value))
                            {
                                result.Add(trains[i]);
                            }
                        }
                        break;
                    }

                case "Int32":
                    {
                        for (int i = 0; i < trains.Count; i++)
                        {
                            if (trains[i].Number.Equals(value))
                            {
                                result.Add(trains[i]);
                            }
                        }
                        break;
                    }

                case "TimeSpan":
                    {
                        for (int i = 0; i < trains.Count; i++)
                        {
                            if (trains[i].Time.Equals(value))
                            {
                                result.Add(trains[i]);
                            }
                        }
                        break;
                    }

                default:
                    {
                        throw new ArgumentException();
                    }
            }
            return result;
        }

        private int ostCmp(Train arg1, Train arg2)
        {
            return arg1.Ost.CompareTo(arg2.Ost);
        }

        private int numberCmp(Train arg1, Train arg2)
        {
            return arg1.Number.CompareTo(arg2.Number);
        }

        private int timeCmp(Train arg1, Train arg2)
        {
            return arg1.Time.CompareTo(arg2.Time);
        }

        private  TrainList QuickSort(TrainList a, int left, int right)
        {   
            if (left < right)
            {
                int q = Partition(a, left, right);
                a = QuickSort(a, left, q);
                a = QuickSort(a, q + 1, right);
            }
            return a;
        }

        private  int Partition(TrainList a, int p, int r)
        {
            Train x = a[p];
            int i = p - 1;
            int j = r + 1;
            while (true)
            {
                do
                {
                    j--;
                }
                while (cmp(a[j],x) > 0);
                do
                {
                    i++;
                }
                while (cmp(a[i],x) < 0);
                if (i < j)
                {
                    Train tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
                else
                {
                    return j;
                }
            }
        }

    }
}

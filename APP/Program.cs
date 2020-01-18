using System;
using WeaponClassification;

namespace APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для запуска 1-ого задания введите 1\nДля запуска 2-ого задания введите 2");
            int vib = Convert.ToInt32(Console.ReadLine());
            switch (vib)
            {
                case 1:
                    {
                        First();
                        break;
                    }
                case 2:
                    {
                        Second();
                        break;
                    }
                case 3:
                    {
                        break;
                    }

                default:
                    break;
            }

        }

        private static void First()
        {
            #region 1
            Console.WriteLine("Первое задание:");
            CBookCard firstBook = new CBookCard("Ivanov", "How make", "MIBR", 1998, "2-266-11156", 20);
            firstBook.Rating = 12;
            CBookCard secondBook = new CBookCard("Petrov", "How live", "MIBR", 1999, "2-300-131356", 50);
            secondBook.Rating = 9;
            Console.WriteLine($"{firstBook}\n{secondBook}");
            #endregion 1

            #region 2
            Console.WriteLine("\nВторое задание:");
            CBookCard[] bookCards = new CBookCard[5];
            bookCards[0] = firstBook;
            bookCards[1] = secondBook;
            bookCards[2] = new CBookCard("Kirov", "Program", "SAO", 2005, "3-123-131356", 30);
            bookCards[2].Rating = 14;
            bookCards[3] = new CBookCard("Akyla", "Baby book", "PRIM", 2002, "5-141-154656", 30);
            bookCards[3].Rating = 15;
            bookCards[4] = new CBookCard("Ivanov", "True", "SPO", 2012, "2-543-113256", 30);
            bookCards[4].Rating = 5;
            Console.WriteLine("Список книг до сортировки:");
            foreach (var item in bookCards)
            {
                Console.WriteLine(item);
            }

            CBookCard.SortByYear(bookCards);

            Console.WriteLine("\nСписок книг после сортировки:");
            foreach (var item in bookCards)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
        private static void Second()
        {
            Blade blade = new Blade(124, 1, "Катана", "Холодное оружие", 3.5);
            Console.WriteLine("Class Balde:");
            Console.WriteLine(blade + "\n");

            Gun gun = new Gun("Автомат", "Огнестрельное оружие", 3.2,30,5.45);
            Console.WriteLine("Class Gun:");
            Console.WriteLine(gun + "\n");

            MachineGun machine = new MachineGun("ПКТ", "Огнестрельное оружие", 112.4, 300, 12.7,"БМП",7.3,150);
            Console.WriteLine("Class MachineGun:");
            Console.WriteLine(machine+"\n");
        }
    }
}

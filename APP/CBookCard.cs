using System;
using System.Collections.Generic;
using System.Text;

namespace APP
{
    internal class CBookCard
    {
        private const int MAX_RATING = 15;
        private string author;
        private string title;
        private string publishingHouse;
        private int year;
        private string iSBN;
        private int count;
        private float rating;

        public string Author { get => author; }
        public string Title { get => title; set => title = value; }
        public string PublishingHouse { get => publishingHouse; set => publishingHouse = value; }
        public int Year { get => year; set => year = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }
        public int Count { get => count; set => count = value; }
        public float Rating
        {
            get => rating;
            set
            {
                if (value < 0 || value > MAX_RATING)
                    throw new ArgumentOutOfRangeException($"{nameof(rating)} out of range [0;{MAX_RATING}]");
                else
                    rating = value;
            }
        }

        public CBookCard(string author, string title, string publishingHouse, int year, string iSBN, int count) : base()
        {
            this.author = author ?? throw new ArgumentNullException(nameof(author));
            this.title = title ?? throw new ArgumentNullException(nameof(title));
            this.publishingHouse = publishingHouse ?? throw new ArgumentNullException(nameof(publishingHouse));
            this.year = year;
            this.iSBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            this.count = count;
        }

        public override string ToString()
        {
            return $"ISBN {iSBN}\n{author} {title}. {publishingHouse}, {year}. Тираж: {count}. Рейтинг: {rating}";
        }

        public static void SortByYear(CBookCard[] books)
        {
            for (int i = 0; i < books.Length; i++)
            {
                for (int j = i + 1; j < books.Length; j++)
                {
                    if (books[i].year < books[j].year)
                    {
                        CBookCard swap = books[i];
                        books[i] = books[j];
                        books[j] = swap;
                    }
                }
            }
        }
    }
}

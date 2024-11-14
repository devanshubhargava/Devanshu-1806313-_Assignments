﻿using System;


namespace Assignment_5
{
    internal class Book
    {
        private string _bookName;
        private string _authorName;

        public Book(string bookName, string authorName)
        {
            _bookName = bookName;
            _authorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"BookName: {_bookName}");
            Console.WriteLine($"\nAuthorName: {_authorName}");
        }
    }

    class BookShelf
    {
        private readonly Book[] books = new Book[5];

        public Book this[int index]
        {
            get
            {
                return books[index];
            }

            set
            {
                books[index] = value;
            }
        }

        public static void Main()
        {
            Console.WriteLine("------Book Self Question------\n");
            Console.WriteLine("Enter Book Details\n");
            string bookName, authorName;
            BookShelf bookShelf = new BookShelf();
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter Book {i + 1} Name: ");
                bookName = Console.ReadLine();
                Console.Write($"Enter Book {i + 1} Author Name: ");
                authorName = Console.ReadLine();
                bookShelf[i] = new Book(bookName, authorName);
                Console.WriteLine();
            }

           
            Console.WriteLine("Displaying books details");
            Book book;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Book {i + 1} details");
                book = bookShelf[i];
                book.Display();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
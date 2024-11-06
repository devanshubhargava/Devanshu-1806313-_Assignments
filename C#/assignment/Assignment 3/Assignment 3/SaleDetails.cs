using System;

namespace Assignment3

{

    internal class SaleDetails

    {

        public string salesNo;

        public string productNo;

        public double price;

        public DateTime dateOfSale;

        public int qty;

        public double totalAmount;

        public SaleDetails(string salesNo, string productNo, double price, int qty, DateTime dateOfSale)

        {

            this.salesNo = salesNo;

            this.productNo = productNo;

            this.price = price;

            this.qty = qty;

            this.dateOfSale = dateOfSale;

            Sales(qty, price);

        }

        public void Sales(int qty, double price)

        {

            totalAmount = qty * price;

        }

        public static void ShowData(SaleDetails sale)

        {

            Console.WriteLine("\n\nSale Details:");

            Console.WriteLine($"Sales No: {sale.salesNo}");

            Console.WriteLine($"Product No: {sale.productNo}");

            Console.WriteLine($"Price per Unit: {sale.price}");

            Console.WriteLine($"Quantity: {sale.qty}");

            Console.WriteLine($"Date of Sale: {sale.dateOfSale.ToString("yyyy-MM-dd")}");

            Console.WriteLine($"Total Amount: {sale.totalAmount}");

        }

        static void Main(string[] args)

        {
            Console.WriteLine("------Sales Details------\n\n");

            Console.Write("Enter Sales No: ");

            string salesNo = Console.ReadLine();

            Console.Write("Enter Product No: ");

            string productNo = Console.ReadLine();

            Console.Write("Enter Price per Unit: ");

            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");

            int qty = int.Parse(Console.ReadLine());

            Console.Write("Enter Date of Sale (yyyy-MM-dd): ");

            DateTime dateOfSale = DateTime.Parse(Console.ReadLine());

            SaleDetails sale = new SaleDetails(salesNo, productNo, price, qty, dateOfSale);

            SaleDetails.ShowData(sale);

            Console.ReadLine();

        }

    }

}


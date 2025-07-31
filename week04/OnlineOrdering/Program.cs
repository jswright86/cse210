using System;

class Program
{
    static void Main(string[] args)
    {
        //object 1 = Order 1 , Product 1 & 2, Address 1, Customer 1
        Product O1P1 = new Product("Sunglasses", "SG001", 124.99f, 1);
        Product O1P2 = new Product("Thermos", "TH1001", 22.99f, 2);
        Address O1A1 = new Address("111 Street Dr", "San Antonio", "TX", "USA");
        Customer O1C1 = new Customer("John", "Smith", O1A1);
        Order Order1 = new Order(O1C1);


        //object 2 = Order 2, Products 1 & 2, Address 1, Customer 1
        Product O2P1 = new Product("Garmin Instint", "GIGEN2", 299.99f, 1);
        Product O2P2 = new Product("Apple Iphone 16", "AI16", 1300.00f, 1);
        Address O2A1 = new Address("120 Camino Dr", "BigCity", "ONTARIO", "CA");
        Customer O2C1 = new Customer("Jake", "Huntsman", O2A1);
        Order Order2 = new Order(O2C1);

        //Getters & Setters for Order1
        O1A1.GetCountry();
        Order1.AddProduct(O1P1);
        Order1.AddProduct(O1P2);
        Order1.GetProductsCost();
        Order1.GetShippingCost(O1A1);


        //Getters & Setters for Order2
        O2A1.GetCountry();
        Order2.AddProduct(O2P1);
        Order2.AddProduct(O2P2);
        Order2.GetProductsCost();
        Order2.GetShippingCost(O2A1);


        //Order1 Complete
        Console.WriteLine("Order 1");
        Console.WriteLine(Order1.GetPackingLabel());
        Console.WriteLine(Order1.GetShippingLabel());
        Console.WriteLine("------Total-Price------");
        Console.WriteLine($"${Order1.GetTotalPrice()}");
        Console.WriteLine();

        //Order2 Complete
        Console.WriteLine("Order 2");
        Console.WriteLine(Order2.GetPackingLabel());
        Console.WriteLine(Order2.GetShippingLabel());
        Console.WriteLine("------Total-Price------");
        Console.WriteLine($"${Order2.GetTotalPrice()}");

    }
    
}
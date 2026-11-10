using System;

class Program
{
    static void Main()
    {
        // Create products

        Product product1 = new Product("Mythical Man-Month", 45);
        Product product2 = new Product("Ream of paper (500)", 5);
        Product product3 = new Product("Standart Fruit Laptop", 2000);



        // Create invoice lines
        InvoiceLine line1 = new InvoiceLine(
            1,
                        product1
        );

        InvoiceLine line2 = new InvoiceLine(
            4,
            product2
        );

        InvoiceLine line3 = new InvoiceLine(
            1,
            product3
        );


        // Create invoice
        Invoice invoice = new Invoice(
            new DateTime(2023, 1, 5),
            5678,
            1234,
            new DateTime(2023, 2, 5)
        );


        // Add invoice lines
        invoice.AddLine(line1);
        invoice.AddLine(line2);
        invoice.AddLine(line3);


        // -----------------------------
        // Console String Visitor
        // -----------------------------

        ConsoleStringVisitor consoleVisitor =
            new ConsoleStringVisitor();

        invoice.Accept(consoleVisitor);

        Console.WriteLine("CONSOLE OUTPUT");
        Console.WriteLine();

        Console.WriteLine(
            consoleVisitor.GetResult()
        );


        // -----------------------------
        // XML Visitor
        // -----------------------------

        XmlVisitor xmlVisitor =
            new XmlVisitor();

        invoice.Accept(xmlVisitor);

        Console.WriteLine();
        Console.WriteLine("XML OUTPUT");
        Console.WriteLine();

        Console.WriteLine(
            xmlVisitor.GetResult()
        );
    }
}
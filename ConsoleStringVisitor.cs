
using System;
using System.Text;

public class ConsoleStringVisitor : IVisitor
{
    private StringBuilder result = new StringBuilder();

    public void Visit(Invoice invoice)
    {
        result.Clear();

        // Invoice heading
        result.AppendLine(
            "Invoice".PadRight(36) +
            "Date: " + invoice.Date.ToString("yyyy-MM-dd")
        );

        result.AppendLine();

        result.AppendLine("Customer number: " + invoice.CustomerNumber);
        result.AppendLine("Invoice number: " + invoice.InvoiceNumber);
        result.AppendLine("Payment by: " + invoice.PaymentBy.ToString("yyyy-MM-dd"));

        result.AppendLine();

        // Table headings
        result.AppendLine(
            "Qty".PadRight(6) +
            "Product".PadRight(28) +
            "Unit Price".PadLeft(12) +
            "Total".PadLeft(8)
        );

        decimal preTaxTotal = 0;

        // Visit each invoice line
        foreach (InvoiceLine line in invoice.Lines)
        {
            line.Accept(this);
            preTaxTotal += line.GetTotal();
        }

        // Calculate tax and grand total
        decimal tax = Math.Round(
            preTaxTotal * 0.10m,
            MidpointRounding.AwayFromZero
        );

        decimal total = preTaxTotal + tax;

        result.AppendLine();

        // Right-aligned totals
        result.AppendLine(
            "Pre-tax total:".PadLeft(46) +
            ("$" + preTaxTotal).PadLeft(8)
        );

        result.AppendLine(
            "Tax(10%):".PadLeft(46) +
            ("$" + tax).PadLeft(8)
        );

        result.AppendLine(
            "Total:".PadLeft(46) +
            ("$" + total).PadLeft(8)
        );
    }

    public void Visit(InvoiceLine invoiceLine)
    {
        result.AppendLine(
            invoiceLine.Quantity.ToString().PadRight(6) +
            invoiceLine.Product.Title.PadRight(28) +
            ("$" + invoiceLine.Product.UnitPrice).PadLeft(12) +
            ("$" + invoiceLine.GetTotal()).PadLeft(8)
        );
    }

    public void Visit(Product product)
    {
        result.Append(product.Title);
    }

    public string GetResult()
    {
        return result.ToString();
    }
}

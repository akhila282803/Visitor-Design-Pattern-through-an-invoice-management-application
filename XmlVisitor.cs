using System;
using System.Text;

public class XmlVisitor : IVisitor
{
    private StringBuilder result = new StringBuilder();

    public void Visit(Invoice invoice)
    {
        result.Clear();

        result.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

        result.AppendLine(
            "<invoice date=\"" +
            invoice.Date.ToString("yyyy-MM-dd") +
            "\">"
        );

        result.AppendLine(
            "  <customerNumber>" +
            invoice.CustomerNumber +
            "</customerNumber>"
        );

        result.AppendLine(
            "  <invoiceNumber>" +
            invoice.InvoiceNumber +
            "</invoiceNumber>"
        );

        result.AppendLine(
            "  <paymentBy>" +
            invoice.PaymentBy.ToString("yyyy-MM-dd") +
            "</paymentBy>"
        );

        result.AppendLine("  <lines>");

        decimal preTaxTotal = 0;

        foreach (InvoiceLine line in invoice.Lines)
        {
            line.Accept(this);
            preTaxTotal += line.GetTotal();
        }

        result.AppendLine("  </lines>");

        decimal tax = Math.Round(
            preTaxTotal * 0.10m,
            MidpointRounding.AwayFromZero
        );

        decimal total = preTaxTotal + tax;

        result.AppendLine(
            "  <total pre-tax=\"$" +
            preTaxTotal +
            "\" tax=\"$" +
            tax +
            "\">$" +
            total +
            "</total>"
        );

        result.AppendLine("</invoice>");
    }

    public void Visit(InvoiceLine invoiceLine)
    {
        result.AppendLine("    <line>");

        result.AppendLine(
            "      <qty>" +
            invoiceLine.Quantity +
            "</qty>"
        );

        invoiceLine.Product.Accept(this);

        result.AppendLine(
            "      <total>$" +
            invoiceLine.GetTotal() +
            "</total>"
        );

        result.AppendLine("    </line>");
    }

    public void Visit(Product product)
    {
        result.AppendLine("      <product>");

        result.AppendLine(
            "        <productTitle>" +
            product.Title +
            "</productTitle>"
        );

        result.AppendLine(
            "        <unitPrice>$" +
            product.UnitPrice +
            "</unitPrice>"
        );

        result.AppendLine("      </product>");
    }

    public string GetResult()
    {
        return result.ToString();
    }
}
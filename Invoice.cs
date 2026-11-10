using System;
using System.Collections.Generic;

public class Invoice
{
    public DateTime Date { get; set; }

    public int CustomerNumber { get; set; }

    public int InvoiceNumber { get; set; }

    public DateTime PaymentBy { get; set; }

    public List<InvoiceLine> Lines { get; set; }

    public Invoice(
        DateTime date,
        int customerNumber,
        int invoiceNumber,
        DateTime paymentBy
    )
    {
        Date = date;
        CustomerNumber = customerNumber;
        InvoiceNumber = invoiceNumber;
        PaymentBy = paymentBy;

        Lines = new List<InvoiceLine>();
    }

    public void AddLine(InvoiceLine line)
    {
        Lines.Add(line);
    }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
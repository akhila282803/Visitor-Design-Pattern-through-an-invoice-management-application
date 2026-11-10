public interface IVisitor
{
    void Visit(Invoice invoice);

    void Visit(InvoiceLine invoiceLine);

    void Visit(Product product);
}
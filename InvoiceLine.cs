
public class InvoiceLine
{
    public int Quantity { get; set; }

    public Product Product { get; set; }

    public InvoiceLine(int quantity, Product product)
    {
        Quantity = quantity;
        Product = product;
    }

    public decimal GetTotal()
    {
        return Quantity * Product.UnitPrice;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

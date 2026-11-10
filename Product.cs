public class Product
{
    public string Title { get; set; }

    public decimal UnitPrice { get; set; }

    public Product(string title, decimal unitPrice)
    {
        Title = title;
        UnitPrice = unitPrice;
    }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

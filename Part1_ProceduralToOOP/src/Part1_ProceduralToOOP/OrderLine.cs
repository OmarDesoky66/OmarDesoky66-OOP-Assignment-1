
public class OrderLine
{
    private Product product;
    private int quantity;

    public OrderLine(Product product, int quantity)
    {
        this.product = product;
        this.quantity = quantity;
    }

    public Product GetProduct()
    {
        return product;
    }

    public void SetProduct(Product product)
    {
        this.product = product;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }
}
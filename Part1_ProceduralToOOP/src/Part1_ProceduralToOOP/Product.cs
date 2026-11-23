

public class Product
{
    private int id;
    private string name;
    private double price;
    private int stock;

    public Product(int id, string name, double price, int stock)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.stock = stock;
    }

    public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public double GetPrice()
    {
        return price;
    }

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public int GetStock()
    {
        return stock;
    }

    public void SetStock(int stock)
    {
        this.stock = stock;
    }
}
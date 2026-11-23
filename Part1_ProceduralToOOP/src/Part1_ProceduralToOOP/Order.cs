
public class Order
{
    private int id;
    private Customer customer;
    private string date;
    private bool isPaid;
    private List<OrderLine> lines;

    public Order(int id, Customer customer, string date)
    {
        this.id = id;
        this.customer = customer;
        this.date = date;
        this.isPaid = false;
        this.lines = new List<OrderLine>();
    }

    public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public Customer GetCustomer()
    {
        return customer;
    }

    public void SetCustomer(Customer customer)
    {
        this.customer = customer;
    }

    public string GetDate()
    {
        return date;
    }

    public void SetDate(string date)
    {
        this.date = date;
    }

    public bool GetIsPaid()
    {
        return isPaid;
    }

    public void SetIsPaid(bool isPaid)
    {
        this.isPaid = isPaid;
    }

    public List<OrderLine> GetLines()
    {
        return lines;
    }

    public void SetLines(List<OrderLine> lines)
    {
        this.lines = lines;
    }

    public void PrintOrder()
    {
        Console.WriteLine($"\n=== ORDER #{GetId()} ===");
        Console.WriteLine($"Date: {GetDate()}");
        Console.WriteLine(
            $"Customer: {GetCustomer().GetName()} " +
            $"(#{GetCustomer().GetId()})"
        );

        Console.WriteLine($"Paid: {(GetIsPaid() ? "yes" : "no")}");
        Console.WriteLine("Lines:");

        foreach (OrderLine line in GetLines())
        {
            double lineTotal =
                line.GetProduct().GetPrice() * line.GetQuantity();

            Console.WriteLine(
                $"  - {line.GetProduct().GetName()} " +
                $"x{line.GetQuantity()} " +
                $"@{line.GetProduct().GetPrice():F2} " +
                $"= {lineTotal:F2}"
            );
        }

        Console.WriteLine($"TOTAL: {CalculateTotal():F2}");
    }

    public double CalculateTotal()
    {
        double total = 0.0;

        foreach (OrderLine line in GetLines())
        {
            total += line.GetProduct().GetPrice() * line.GetQuantity();
        }

        if (GetCustomer().GetIsVip())
        {
            total = total * 0.90;
        }

        return total;
    }
}
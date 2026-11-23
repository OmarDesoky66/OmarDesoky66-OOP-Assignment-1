

public class OrderManagementSystem
{
    private const int MAX_CUSTOMERS = 50;
    private const int MAX_PRODUCTS = 50;
    private const int MAX_ORDERS = 100;
    private const int MAX_LINES_PER_ORDER = 20;

    private List<Customer> customers = new();
    private List<Product> products = new();
    private List<Order> orders = new();

    private int FindCustomerIndexById(int id)
    {
        for (int i = 0; i < customers.Count; i++)
        {
            if (customers[i].GetId() == id)
                return i;
        }

        return -1;
    }

    private int FindProductIndexById(int id)
    {
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].GetId() == id)
                return i;
        }

        return -1;
    }

    private int FindOrderIndexById(int id)
    {
        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i].GetId() == id)
                return i;
        }

        return -1;
    }

    public void AddCustomer(int id, string name, string email, string city, bool isVip)
    {
        if (customers.Count >= MAX_CUSTOMERS)
        {
            Console.WriteLine("ERROR: customer list is full.");
            return;
        }

        if (FindCustomerIndexById(id) != -1)
        {
            Console.WriteLine($"ERROR: customer id {id} already exists.");
            return;
        }

        customers.Add(new Customer(id, name, email, city, isVip));
    }

    public void PrintCustomers()
    {
        Console.WriteLine($"\n=== CUSTOMERS ({customers.Count}) ===");

        for (int i = 0; i < customers.Count; i++)
        {
            Customer customer = customers[i];

            Console.WriteLine(
                $"#{customer.GetId()}  {customer.GetName()}  " +
                $"<{customer.GetEmail()}>  {customer.GetCity()}  " +
                $"vip={(customer.GetIsVip() ? "yes" : "no")}"
            );
        }
    }

    public void AddProduct(int id, string name, double price, int stock)
    {
        if (products.Count >= MAX_PRODUCTS)
        {
            Console.WriteLine("ERROR: product list is full.");
            return;
        }

        if (FindProductIndexById(id) != -1)
        {
            Console.WriteLine($"ERROR: product id {id} already exists.");
            return;
        }

        products.Add(new Product(id, name, price, stock));
    }

    public void PrintProducts()
    {
        Console.WriteLine($"\n=== PRODUCTS ({products.Count}) ===");

        for (int i = 0; i < products.Count; i++)
        {
            Product product = products[i];

            Console.WriteLine(
                $"#{product.GetId()}  {product.GetName()}  " +
                $"price={product.GetPrice():F2}  stock={product.GetStock()}"
            );
        }
    }

    public int CreateOrder(int orderId, int customerId, string date)
    {
        if (orders.Count >= MAX_ORDERS)
        {
            Console.WriteLine("ERROR: order list is full.");
            return -1;
        }

        if (FindOrderIndexById(orderId) != -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} already exists.");
            return -1;
        }

        int customerIndex = FindCustomerIndexById(customerId);

        if (customerIndex == -1)
        {
            Console.WriteLine($"ERROR: customer id {customerId} not found.");
            return -1;
        }

        Order order = new Order(orderId, customers[customerIndex], date);

        orders.Add(order);

        return orders.Count - 1;
    }

    public void AddLineToOrder(int orderId, int productId, int quantity)
    {
        int orderIndex = FindOrderIndexById(orderId);

        if (orderIndex == -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        Order order = orders[orderIndex];

        if (order.GetIsPaid())
        {
            Console.WriteLine("ERROR: cannot change a paid order.");
            return;
        }

        if (order.GetLines().Count >= MAX_LINES_PER_ORDER)
        {
            Console.WriteLine("ERROR: order has too many lines.");
            return;
        }

        int productIndex = FindProductIndexById(productId);

        if (productIndex == -1)
        {
            Console.WriteLine($"ERROR: product id {productId} not found.");
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("ERROR: quantity must be positive.");
            return;
        }

        Product product = products[productIndex];

        if (product.GetStock() < quantity)
        {
            Console.WriteLine($"ERROR: not enough stock for product #{productId}.");
            return;
        }

        product.SetStock(product.GetStock() - quantity);

        order.GetLines().Add(new OrderLine(product, quantity));
    }

    public void MarkOrderPaid(int orderId)
    {
        int orderIndex = FindOrderIndexById(orderId);

        if (orderIndex == -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        if (orders[orderIndex].GetLines().Count == 0)
        {
            Console.WriteLine("ERROR: cannot pay an empty order.");
            return;
        }

        orders[orderIndex].SetIsPaid(true);
    }

    public void PrintOrder(int orderId)
    {
        int orderIndex = FindOrderIndexById(orderId);

        if (orderIndex == -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        orders[orderIndex].PrintOrder();
    }

    public void PrintAllOrders()
    {
        Console.WriteLine($"\n=== ALL ORDERS ({orders.Count}) ===");

        for (int i = 0; i < orders.Count; i++)
        {
            PrintOrder(orders[i].GetId());
        }
    }

    public double TotalSalesPaidOnly()
    {
        double sum = 0.0;

        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i].GetIsPaid())
            {
                sum += orders[i].CalculateTotal();
            }
        }

        return sum;
    }

    public void SeedSampleData()
    {
        AddCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);
        AddCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);
        AddCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

        AddProduct(101, "USB Cable", 50.0, 100);
        AddProduct(102, "Wireless Mouse", 250.0, 40);
        AddProduct(103, "Mechanical Keyboard", 1200.0, 15);
        AddProduct(104, "Laptop Stand", 400.0, 25);
    }

    public void RunDemoScenario()
    {
        CreateOrder(1001, 1, "2026-09-15");
        AddLineToOrder(1001, 101, 2);
        AddLineToOrder(1001, 102, 1);
        MarkOrderPaid(1001);

        CreateOrder(1002, 2, "2026-09-15");
        AddLineToOrder(1002, 103, 1);
        AddLineToOrder(1002, 104, 1);

        CreateOrder(1003, 3, "2026-09-16");
        AddLineToOrder(1003, 101, 5);
        MarkOrderPaid(1003);
    }
}
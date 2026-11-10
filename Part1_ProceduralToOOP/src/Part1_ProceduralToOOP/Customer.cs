

public class Customer
{
    private int id;
    private string name;
    private string email;
    private string city;
    private bool isVip;

    public Customer(int id, string name, string email, string city, bool isVip)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.city = city;
        this.isVip = isVip;
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

    public string GetEmail()
    {
        return email;
    }

    public void SetEmail(string email)
    {
        this.email = email;
    }

    public string GetCity()
    {
        return city;
    }

    public void SetCity(string city)
    {
        this.city = city;
    }

    public bool GetIsVip()
    {
        return isVip;
    }

    public void SetIsVip(bool isVip)
    {
        this.isVip = isVip;
    }
}
namespace BuilderPattern;

internal class Program
{

    //Example usage of the InvoiceBuilder class to create an Invoice object
    static void Main(string[] args)
    {
        Invoice invoice = new InvoiceBuilder(
    "Omar",
    "Street 1",
    "Cairo",
    "Egypt",
    "Credit Card",
    "USD",
    1000m
)
.SetCustomerEmail("omar7655@email.com")
.SetCustomerPhone("0000000000000")
.SetBillingState("Cairo")
.SetBillingZipCode("12345")
.SetShippingAddress("Street 2", "Giza", "Egypt")
.SetShippingState("Giza")
.SetDiscountAmount(100m)
.SetTaxAmount(50m)
.Build();


        
    }
}

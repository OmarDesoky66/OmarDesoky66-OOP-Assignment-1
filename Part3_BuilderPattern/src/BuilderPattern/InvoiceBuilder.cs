using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern;
 
internal class InvoiceBuilder
{
   
    private readonly string customerName;
    private readonly Address billingAddress;
    private readonly Order order;

    private string? customerEmail;
    private string? customerPhone;

    private Address? shippingAddress;

    public InvoiceBuilder(
        string customerName,
        Address billingAddress,
        Order order)
    {
        this.customerName = customerName;
        this.billingAddress = billingAddress;
        this.order = order;
    }

    public InvoiceBuilder SetCustomerEmail(string email)
    {
        customerEmail = email;
        return this;
    }

    public InvoiceBuilder SetCustomerPhone(string phone)
    {
        customerPhone = phone;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(Address address)
    {
        shippingAddress = address;
        return this;
    }

    public Invoice Build()
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Customer name is required.");

        return new Invoice(
            customerName,
            customerEmail,
            customerPhone,
            billingAddress,
            shippingAddress,
            order
        );
    }
}

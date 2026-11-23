using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern;

internal class Invoice
{
    public Guid InvoiceId { get; }

    public string CustomerName { get; }
    public string? CustomerEmail { get; }
    public string? CustomerPhone { get; }

    public Address BillingAddress { get; }
    public Address? ShippingAddress { get; }

    public Order Order { get; }

    public Invoice(
        string customerName,
        string? customerEmail,
        string? customerPhone,
        Address billingAddress,
        Address? shippingAddress,
        Order order)
    {
        InvoiceId = Guid.NewGuid();

        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;

        BillingAddress = billingAddress;
        ShippingAddress = shippingAddress;

        Order = order;
    }
}

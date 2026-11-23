using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern;

internal class OrderBuilder
{
    private readonly string paymentMethod;
    private readonly string currency;
    private readonly decimal subTotal;

    private DateTime orderDate = DateTime.Now;
    private decimal discountAmount = 0;
    private decimal taxAmount = 0;

    public OrderBuilder(
        string paymentMethod,
        string currency,
        decimal subTotal)
    {
        this.paymentMethod = paymentMethod;
        this.currency = currency;
        this.subTotal = subTotal;
    }

    public OrderBuilder SetOrderDate(DateTime orderDate)
    {
        this.orderDate = orderDate;
        return this;
    }

    public OrderBuilder SetDiscountAmount(decimal amount)
    {
        discountAmount = amount;
        return this;
    }

    public OrderBuilder SetTaxAmount(decimal amount)
    {
        taxAmount = amount;
        return this;
    }

    public Order Build()
    {
        if (string.IsNullOrWhiteSpace(paymentMethod))
            throw new ArgumentException("Payment method is required.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency is required.");

        if (subTotal < 0)
            throw new ArgumentException("Invalid subtotal.");

        if (discountAmount < 0 || discountAmount > subTotal)
            throw new ArgumentException("Invalid discount.");

        if (taxAmount < 0)
            throw new ArgumentException("Invalid tax.");

        return new Order(
            orderDate,
            paymentMethod,
            currency,
            subTotal,
            discountAmount,
            taxAmount
        );
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern;
// Mandatory fields: CustomerName, BillingStreet, BillingCity, BillingCountry, PaymentMethod, Currency, SubTotal
// optional fields: BillingState, BillingZipCode, ShippingStreet, ShippingCity, ShippingState, ShippingZipCode, ShippingCountry, TaxRate, TaxAmount, TotalAmount 
internal class InvoiceBuilder
{
    // Mandatory fields
    private readonly string customerName;

    private readonly string billingStreet;
    private readonly string billingCity;
    private readonly string billingCountry;

    private readonly string paymentMethod;
    private readonly string currency;
    private readonly decimal subTotal;



    // Optional fields

    private string? customerEmail;
    private string? customerPhone;

    private string? billingState;
    private string? billingZipCode;

    private string? shippingStreet;
    private string? shippingCity;
    private string? shippingState;
    private string? shippingZipCode;
    private string? shippingCountry;

    private DateTime orderDate = DateTime.Now;

    private decimal discountAmount = 0;
    private decimal taxAmount = 0;




    //Constructor for mandatory fields
    public InvoiceBuilder(
    string customerName,
    string billingStreet,
    string billingCity,
    string billingCountry,
    string paymentMethod,
    string currency,
    decimal subTotal)
    {
        this.customerName = customerName;

        this.billingStreet = billingStreet;
        this.billingCity = billingCity;
        this.billingCountry = billingCountry;

        this.paymentMethod = paymentMethod;
        this.currency = currency;
        this.subTotal = subTotal;
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



    public InvoiceBuilder SetBillingState(string state)
    {
        billingState = state;
        return this;
    }

    public InvoiceBuilder SetBillingZipCode(string zipCode)
    {
        billingZipCode = zipCode;
        return this;
    }






    public InvoiceBuilder SetShippingAddress(
    string street,
    string city,
    string country)
    {
        shippingStreet = street;
        shippingCity = city;
        shippingCountry = country;

        return this;
    }




    public InvoiceBuilder SetShippingState(string state)
    {
        shippingState = state;
        return this;
    }

    public InvoiceBuilder SetShippingZipCode(string zipCode)
    {
        shippingZipCode = zipCode;
        return this;
    }





    public InvoiceBuilder SetOrderDate(DateTime date)
    {
        orderDate = date;
        return this;
    }

    public InvoiceBuilder SetDiscountAmount(decimal amount)
    {
        discountAmount = amount;
        return this;
    }

    public InvoiceBuilder SetTaxAmount(decimal amount)
    {
        taxAmount = amount;
        return this;
    }


    public Invoice Build()
    {
        if (subTotal < 0)
            throw new ArgumentException("Subtotal cannot be negative.");

        if (discountAmount < 0 || discountAmount > subTotal)
            throw new ArgumentException("Invalid discount amount.");

        if (taxAmount < 0)
            throw new ArgumentException("Tax cannot be negative.");

        if (!string.IsNullOrWhiteSpace(shippingStreet) &&
            (string.IsNullOrWhiteSpace(shippingCity) ||
             string.IsNullOrWhiteSpace(shippingCountry)))
        {
            throw new InvalidOperationException(
                "Shipping address must be complete.");
        }

        decimal totalAmount =
            subTotal - discountAmount + taxAmount;

        return new Invoice
        {
            InvoiceId = 1,

            CustomerName = customerName,
            CustomerEmail = customerEmail,
            CustomerPhone = customerPhone,

            BillingStreet = billingStreet,
            BillingCity = billingCity,
            BillingState = billingState,
            BillingZipCode = billingZipCode,
            BillingCountry = billingCountry,

            ShippingStreet = shippingStreet,
            ShippingCity = shippingCity,
            ShippingState = shippingState,
            ShippingZipCode = shippingZipCode,
            ShippingCountry = shippingCountry,

            OrderDate = orderDate,

            PaymentMethod = paymentMethod,
            Currency = currency,

            SubTotal = subTotal,
            DiscountAmount = discountAmount,
            TaxAmount = taxAmount,
            TotalAmount = totalAmount
        };
    }
}

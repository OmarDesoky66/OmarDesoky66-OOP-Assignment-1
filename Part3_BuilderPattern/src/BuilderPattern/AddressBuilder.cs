using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern;

internal class AddressBuilder
{
    private readonly string street;
    private readonly string city;
    private readonly string country;

    private string? state;
    private string? zipCode;

    public AddressBuilder(
        string street,
        string city,
        string country)
    {
        this.street = street;
        this.city = city;
        this.country = country;
    }

    public AddressBuilder SetState(string state)
    {
        this.state = state;
        return this;
    }

    public AddressBuilder SetZipCode(string zipCode)
    {
        this.zipCode = zipCode;
        return this;
    }

    public Address Build()
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street is required.");

        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required.");

        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country is required.");

        return new Address(
            street,
            city,
            state,
            zipCode,
            country
        );
    }
}

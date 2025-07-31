using System.Collections.Generic;
using System.Text;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    private float _shippingCost;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
        _shippingCost = 0;
        
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public float GetProductsCost()
    {
        float total = 0;
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }
        return total;
    }
    
    public float GetShippingCost(Address address)
    {
        if (_customer.IsInUS(address))
        {
            _shippingCost = 5.00f;
        }
        else
        {
            _shippingCost = 35.00f;
        }
        return _shippingCost;
    }
    public float GetTotalPrice()
    {
        return GetProductsCost() + GetShippingCost(_customer.GetAddressObject());
    }
    public string GetPackingLabel()
    {

        StringBuilder label = new StringBuilder();
        label.AppendLine("------Package-Contents------ ");
        foreach (Product p in _products)
        {
            label.AppendLine($"{p.GetProductName()} {p.GetProductID()}");

        }
        return label.ToString();
    }
      public string GetShippingLabel()
    {

        StringBuilder label = new StringBuilder();
        label.AppendLine("------Shipping-Label------");
        label.AppendLine($"{_customer.GetName()}");
        label.AppendLine($"{_customer.GetAddress()}");
        return label.ToString();

    }
}
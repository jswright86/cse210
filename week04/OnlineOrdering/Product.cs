class Product
{
    private string _productName;
    private string _productID;
    private float _productPrice;
    private int _productQuantity;

    public Product(string productName, string productID, float productPrice, int productQuantity)
    {
        _productName = productName;
        _productID = productID;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
    }
    public int GetProductQuantity()
    {
        return _productQuantity;
    }
    public float GetTotalCost()
    {
        return _productPrice * _productQuantity;
    }
    public string GetProductID()
    {
        return _productID;
    }
    public string GetProductName()
    {
        return _productName;
    }
}
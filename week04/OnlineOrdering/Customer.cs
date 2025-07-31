class Customer
{
    private string _fName;
    private string _lName;
    private Address _address;

    public Customer(string fName, string lName, Address address)
    {
        _fName = fName;
        _lName = lName;
        _address = address;
    }
    
    public string GetName()
    {
        return _fName + " " + _lName;

    }

    public Address GetAddressObject()
    {
        return _address;
    }
    public string GetAddress()
    {
        return _address.GetStreetAddress() + "," + " " + _address.GetCity() + "," + " " + _address.GetState() + "," + " " + _address.GetCountry();
    }
    public bool IsInUS(Address address)
    {

        return address.IsUS();
    }
}
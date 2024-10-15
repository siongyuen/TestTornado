public class Address
{
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
}

public class CorpEntity
{
    public Address Address { get; set; }
}

public class MainCorpAppt
{
    public CorpEntity CorpEntity { get; set; }
}

public class IndEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FormerName { get; set; }
    public Address ResidentialAddress { get; set; }
}

public class MainIndAppt
{
    public IndEntity IndEntity { get; set; }
}

public class Client
{
    public string CompanyNo { get; set; }
    public string CompanyName { get; set; }
    public MainCorpAppt MAINCORPAPPT { get; set; }
    public MainIndAppt MAININDAPPT { get; set; }
}

public class ServiceAddressOrResidentialAddress
{
    public string BuildingName { get; set; }
    public string StreetLine1 { get; set; }
    public string StreetLine2 { get; set; }
    public string StreetLine3 { get; set; }
    public string StreetLine4 { get; set; }
    public string PostTown { get; set; }
    public string CountryRegion { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
}

public class Individual
{
    public string Title { get; set; }
    public string DOB { get; set; }
    public string Nationality { get; set; }
    public string Occupation { get; set; }
}

public class Director
{
    public string Title { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FormerName { get; set; }
    public string Country { get; set; }
    public string Nationality { get; set; }
    public string DOB { get; set; }
    public string Occupation { get; set; }
    public string BuildingName { get; set; }
    public string StreetLine1 { get; set; }
    public string StreetLine2 { get; set; }
    public string StreetLine3 { get; set; }
    public string StreetLine4 { get; set; }
    public string PostTown { get; set; }
    public string CountryRegion { get; set; }
    public string PostCode { get; set; }
}

public class Presenter
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PostTown { get; set; }
    public string CountryRegion { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
    public string Telephone { get; set; }
}

public class RegisteredOffice
{
    public string BuildingName { get; set; }
    public string StreetLine4 { get; set; }
}

public class FullRecord
{
    public Client CLIENT { get; set; }
    public RegisteredOffice RegisteredOfficeOfMasterFileOrRegisteredOfficeOfCompany { get; set; }
    public string FullName { get; set; }
    public string PlaceOfRegistration { get; set; }
    public string PassportOrIncorporationNo { get; set; }
    public Individual Individual { get; set; }
    public ServiceAddressOrResidentialAddress ServiceAddressOrResidentialAddress { get; set; }
    public List<Director> Directors { get; set; }
    public Presenter Presenter { get; set; }
}

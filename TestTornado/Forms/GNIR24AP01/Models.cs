using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Forms.GNIR24AP01
{
    public class RootObject
    {
        public Client CLIENT { get; set; }
        public Individual Individual { get; set; }
        public Address ServiceAddress { get; set; }
        public Address ResidentialAddress { get; set; }
        public Presenter Presenter { get; set; }
    }

    public class Client
    {
        public string CompanyNo { get; set; }
        public string CompanyName { get; set; }
        public MainCorpAppt MAINCORPAPPT { get; set; }
        public MainIndAppt MAININDAPPT { get; set; }
    }

    public class MainCorpAppt
    {
        public string DateAppointed { get; set; }
        public CorporationEntity CorpEntity { get; set; }
    }

    public class CorporationEntity
    {
        public Address Address { get; set; }
    }

    public class MainIndAppt
    {
        public IndividualEntity IndEntity { get; set; }
    }

    public class IndividualEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Address ResidentialAddress { get; set; }
    }

    public class Individual
    {
        public string Title { get; set; }
        public string FormerGivenNames { get; set; }
        public string FormerSurName { get; set; }
        public string Nationality { get; set; }
        public string DOB { get; set; }
        public string Occupation { get; set; }
    }

    public class Address
    {
        public string BuildingName { get; set; }
        public string StreetLine2 { get; set; }
        public string StreetLine3 { get; set; }
        public string StreetLine4 { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
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

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTornado.Forms.GNIR24AP01;

namespace TestTornado.Forms.GI19FDMS01
{
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
        public CorpEntity CorpEntity { get; set; }
    }

    public class CorpEntity
    {
        public Address Address { get; set; }
    }

    public class MainIndAppt
    {
        public IndEntity IndEntity { get; set; }
    }

    public class IndEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ResidentialAddress ResidentialAddress { get; set; }
        public CorrespondenceAddress CorrespondenceAddress { get; set; }
    }

    public class ResidentialAddress
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }

    public class CorrespondenceAddress
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }

    public class Presenter
    {
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }

    public class Individual
    {
        public string Title { get; set; }
        public string DOB { get; set; }
        public string FormerGivenNames { get; set; }
        public string FormerSurName { get; set; }
        public string Nationality { get; set; }
        public string Occupation { get; set; }
    }

    public class RegisteredOfficeOfMasterFile
    {
        public string BuildingName { get; set; }
    }

    public class ServiceAddressOrResidentialAddress
    {
        public string CountryRegion { get; set; }
    }

    public class Building
    {
        public string NameNumber { get; set; }
    }

    public class FullData
    {
        public Client CLIENT { get; set; }
        public string FullName { get; set; }
        public Presenter Presenter { get; set; }
        public Individual Individual { get; set; }
        public ResidentialAddress ResidentialAddress { get; set; }
        public string NationalityOfOrigin { get; set; }
        public RegisteredOfficeOfMasterFile RegisteredOfficeOfMasterFile { get; set; }
        public ServiceAddressOrResidentialAddress ServiceAddressOrResidentialAddress { get; set; }
        public Building Building { get; set; }
        public string DateResigned { get; set; }

        public string OFTYPE {  get; set; }
    }

}

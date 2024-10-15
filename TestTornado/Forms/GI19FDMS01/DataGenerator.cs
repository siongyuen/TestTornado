using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTornado.Forms.GNIR24AP01;

namespace TestTornado.Forms.GI19FDMS01
{
    public class DataGenerator
    {
            public static  FullData GetData()
            {

            return new FullData
            {
                CLIENT = new Client
                {
                    CompanyNo = "COMP12345",
                    CompanyName = "Sample Company Ltd.",
                    MAINCORPAPPT = new MainCorpAppt
                    {
                        DateAppointed = "2024-01-01",
                        CorpEntity = new CorpEntity
                        {
                            Address = new Address
                            {
                                AddressLine1 = "123 Main Street",
                                City = "Kuala Lumpur",
                                PostCode = "50000",
                                Country = "Malaysia"
                            }
                        }
                    },
                    MAININDAPPT = new MainIndAppt
                    {
                        IndEntity = new IndEntity
                        {
                            LastName = "Doe",
                            FirstName = "John",
                            ResidentialAddress = new ResidentialAddress
                            {
                                AddressLine1 = "456 Oak Avenue",
                                City = "Petaling Jaya",
                                State = "Selangor",
                                PostCode = "46000",
                                Country = "Malaysia"
                            },
                            CorrespondenceAddress = new CorrespondenceAddress
                            {
                                AddressLine1 = "789 Pine Road",
                                City = "Shah Alam",
                                State = "Selangor",
                                PostCode = "40000",
                                Country = "Malaysia"
                            }
                        }
                    }
                },
                OFTYPE ="NIM",
                FullName = "John Doe",
                Presenter = new Presenter
                {
                    Address = "123 Presenter Street",
                    Telephone = "+60 12 345 6789",
                    Email = "john.doe@example.com"
                },
                Individual = new Individual
                {
                    Title = "Mr.",
                    DOB = "1980-02-03",
                    FormerGivenNames = "Johnny",
                    FormerSurName = "Smith",
                    Nationality = "Malaysian",
                    Occupation = "Software Architect"
                },
                ResidentialAddress = new ResidentialAddress
                {
                    AddressLine1 = "Residential Building Name",
                    City = "Subang Jaya",
                    State = "Selangor",
                    PostCode = "47500",
                    Country = "Malaysia"
                },
                NationalityOfOrigin = "Malaysian",
                RegisteredOfficeOfMasterFile = new RegisteredOfficeOfMasterFile
                {
                    BuildingName = "Registered Office Building"
                },
                ServiceAddressOrResidentialAddress = new ServiceAddressOrResidentialAddress
                {
                    CountryRegion = "MY"
                },
                Building = new Building
                {
                    NameNumber = "Building Name 101"
                },
                DateResigned = "2023-12-31"
                
            };
        }

    }
}


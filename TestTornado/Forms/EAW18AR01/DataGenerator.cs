using System;
using System.Collections.Generic;
using System.Linq;


namespace TestTornado.Forms.EAW18AR01
{

    public class DataGenerator
{
    private static Random random = new Random();

    public static FullRecord GetData()
    {
        return new FullRecord
        {
            CLIENT = new Client
            {
                CompanyNo = GenerateRandomString(8),
                CompanyName = "Tech Solutions Ltd",
                MAINCORPAPPT = new MainCorpAppt
                {
                    CorpEntity = new CorpEntity
                    {
                        Address = new Address
                        {
                            AddressLine1 = "123 Corporate Ave",
                            AddressLine2 = "Suite 400",
                            AddressLine3 = "Corporate Plaza",
                            City = "London",
                            State = "London",
                            PostCode = "EC1A 1BB",
                            Country = "UK"
                        }
                    }
                },
                MAININDAPPT = new MainIndAppt
                {
                    IndEntity = new IndEntity
                    {
                        LastName = "Doe",
                        FirstName = "John",
                        FormerName = "Smith",
                        ResidentialAddress = new Address
                        {
                            Country = "UK"
                        }
                    }
                }
            },
            RegisteredOfficeOfMasterFileOrRegisteredOfficeOfCompany = new RegisteredOffice
            {
                BuildingName = "Registered Office",
                StreetLine4 = "King's Road"
            },
            FullName = "John Doe",
            PlaceOfRegistration = "London",
            PassportOrIncorporationNo = GenerateRandomString(10),
            Individual = new Individual
            {
                Title = "Mr",
                DOB = "1979-02-03",
                Nationality = "British",
                Occupation = "Software Architect"
            },
            ServiceAddressOrResidentialAddress = new ServiceAddressOrResidentialAddress
            {
                BuildingName = "Doe House",
                StreetLine1 = "101 Baker Street",
                StreetLine2 = "Suite 2A",
                StreetLine3 = "Central London",
                StreetLine4 = "Downtown",
                PostTown = "London",
                CountryRegion = "UK",
                PostCode = "W1U 8EX",
                Country = "UK"
            },
            Directors = new List<Director>
            {
                new Director
                {
                    Title = "Mr",
                    LastName = "Doe",
                    FirstName = "John",
                    FormerName = "Smith",
                    Country = "UK",
                    Nationality = "British",
                    DOB = "1979-02-03",
                    Occupation = "Software Architect",
                    BuildingName = "Tech Hub",
                    StreetLine1 = "1 Tech Street",
                    StreetLine2 = "Block B",
                    StreetLine3 = "Floor 3",
                    StreetLine4 = "Office 45",
                    PostTown = "London",
                    CountryRegion = "UK",
                    PostCode = "EC1A 4HJ"
                },
                new Director
                {
                    Title = "Ms",
                    LastName = "Doe",
                    FirstName = "Jane",
                    FormerName = "Johnson",
                    Country = "UK",
                    Nationality = "British",
                    DOB = "1982-05-12",
                    Occupation = "Chief Financial Officer",
                    BuildingName = "Finance Tower",
                    StreetLine1 = "202 Money Street",
                    StreetLine2 = "Penthouse",
                    StreetLine3 = "Floor 8",
                    StreetLine4 = "Office 99",
                    PostTown = "London",
                    CountryRegion = "UK",
                    PostCode = "EC2V 5AF"
                }
            },
            Presenter = new Presenter
            {
                Name = "Jane Doe",
                Address = "123 Presenter Ave",
                PostTown = "London",
                CountryRegion = "UK",
                PostCode = "W1U 8EX",
                Country = "UK",
                Telephone = "+44 123 4567 890"
            }
        };
    }

    private static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
}
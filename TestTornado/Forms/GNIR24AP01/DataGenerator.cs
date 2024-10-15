using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Forms.GNIR24AP01
{
    public class DataGenerator
    {
        public static object GetData()
        {
            var root = new RootObject
            {
                CLIENT = new Client
                {
                    CompanyNo = "12345678",
                    CompanyName = "Tech Innovations Ltd",
                    MAINCORPAPPT = new MainCorpAppt
                    {
                        DateAppointed = "2023-01-15",
                        CorpEntity = new CorporationEntity
                        {
                            Address = new Address
                            {
                                AddressLine1 = "123 Innovation Drive",
                                City = "London",
                                State = "Greater London",
                                PostCode = "SW1A 1AA",
                                Country = "United Kingdom"
                            }
                        }
                    },
                    MAININDAPPT = new MainIndAppt
                    {
                        IndEntity = new IndividualEntity
                        {
                            LastName = "Doe",
                            FirstName = "John",
                            ResidentialAddress = new Address
                            {
                                Country = "United Kingdom",
                                AddressLine1 = "45 King's Road",
                                AddressLine2 = "Apt 12",
                                City = "Birmingham",
                                State = "West Midlands",
                                PostCode = "B15 1QA"
                            }
                        }
                    }
                },
                Individual = new Individual
                {
                    Title = "Mr.",
                    FormerGivenNames = "Jonathan",
                    FormerSurName = "Smith",
                    Nationality = "British",
                    DOB = "1985-04-10",
                    Occupation = "Software Architect"
                },
                ServiceAddress = new Address
                {
                    BuildingName = "Innovation Tower",
                    StreetLine2 = "Silicon Street",
                    StreetLine3 = "Tech District",
                    StreetLine4 = "Central London"
                },
                ResidentialAddress = new Address
                {
                    BuildingName = "The Residences",
                    StreetLine3 = "Queensway",
                    StreetLine4 = "Notting Hill"
                },
                Presenter = new Presenter
                {
                    Name = "Jane Roe",
                    Address = "789 Corporate Avenue, Manchester",
                    PostTown = "Manchester",
                    CountryRegion = "North West England",
                    PostCode = "M1 2AB",
                    Country = "United Kingdom",
                    Telephone = "+44 161 123 4567"
                }
            };

            return root;

        }
    }
}

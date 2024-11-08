using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Forms.NMVIM12
{
    public class DataGenerator
    {
        public static RootObject GetData()
        {

            var rootObject = new RootObject
            {
                BusinessEntity = new BusinessEntity
                {
                    RegistrationNumber = "BE123456",
                    Name = "Tech Innovations Ltd",
                    Appointments = new List<Appointment>
                {
                    new Appointment
                    {
                        DateAppointed = "2022-01-15",
                        NatureOfDirector = "Managing Director",
                        Individual = new Individual
                        {
                            FullName = "John Doe",
                            Addresses = new Address
                            {
                                UnitNumber = "12A",
                                FloorNumber = "7",
                                Block = "B1",
                                BuildingName = "Tech Towers",
                                Street = "Innovation Road",
                                Village = "Tech Village",
                                District = "Business District",
                                City = "Kuala Lumpur",
                                Region = "Central Region",
                                CountryName = "Malaysia"
                            }
                        }
                    },
                    new Appointment
                    {
                        DateAppointed = "2023-03-10",
                        NatureOfDirector = "Finance Director",
                        Individual = new Individual
                        {
                            FullName = "Jane Smith",
                            Addresses = new Address
                            {
                                UnitNumber = "3B",
                                FloorNumber = "5",
                                Block = "A2",
                                BuildingName = "Finance Plaza",
                                Street = "Money Street",
                                Village = "Finance Village",
                                District = "Financial District",
                                City = "Kuala Lumpur",
                                Region = "Central Region",
                                CountryName = "Malaysia"
                            }
                        }
                    },
                    new Appointment
                    {
                        DateAppointed = "2024-02-20",
                        NatureOfDirector = "Operations Director",
                        Individual = new Individual
                        {
                            FullName = "Emily Johnson",
                            Addresses = new Address
                            {
                                UnitNumber = "8C",
                                FloorNumber = "2",
                                Block = "C3",
                                BuildingName = "Ops Center",
                                Street = "Operations Lane",
                                Village = "Ops Village",
                                District = "Operations District",
                                City = "Kuala Lumpur",
                                Region = "Central Region",
                                CountryName = "Malaysia"
                            }
                        }
                    }
                }
                },
                Agent = new Agent
                {
                    Name = "Global Consulting Ltd",
                    AddressLine1 = "123 Business Park",
                    AddressLine2 = "Suite 400",
                    City = "Kuala Lumpur",
                    State = "Wilayah Persekutuan",
                    Country = "Malaysia",
                    PostCode = "50000"
                },
                EffectiveDate = "2024-11-01"
            };

            return rootObject;
        }
    }
}

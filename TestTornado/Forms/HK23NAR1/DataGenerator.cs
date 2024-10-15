using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Forms.HK23NAR1
{
    public class DataGenerator
    {
        public static DataModel GetData()
        {
            return new DataModel
            {
                CLIENT = new Client
                {
                    CompanyName = "Tech Innovations Ltd",
                    BusinessName = "Tech Innovations",
                    BusinessNatureCode = "5010",
                    BusinessNature = "Software Development",
                    MAININDAPPT = new MainIndAppt
                    {
                        IndEntity = new IndEntity
                        {
                            CorrespondenceAddress = new CorrespondenceAddress
                            {
                                AddressLine1 = "1234 Elm Street",
                                AddressLine2 = "Suite 500",
                                AddressLine3 = "Silicon Valley",
                                Country = "United States"
                            }
                        }
                    },
                    Email = "contact@techinnovations.com",
                    PhoneNo = "+1-800-123-4567"
                },
                Building = new Building
                {
                    NameNumber = "Building A1"
                },
                Presenter = new Presenter
                {
                    ChineseSurname = "Wong",
                    CompanyName = "Global Ventures Inc.",
                    Address = "4567 Oak Drive, London, UK",
                    Telephone = "+44-20-7890-1234",
                    Email = "john.wong@globalventures.com",
                    UserCodeFormQueueNumber = "GV1001"
                },
                Shares = new List<Share>
            {
                new Share
                {
                    ClassOfShare = "Common Stock",
                    Currency = "USD",
                    TotalNumber = "1000000",
                    TotalAmount = "1000000",
                    TotalPaidUp = "750000"
                },
                new Share
                {
                    ClassOfShare = "Preferred Stock",
                    Currency = "USD",
                    TotalNumber = "500000",
                    TotalAmount = "500000",
                    TotalPaidUp = "500000"
                },
                new Share
                {
                    ClassOfShare = "Employee Stock Options",
                    Currency = "USD",
                    TotalNumber = "200000",
                    TotalAmount = "200000",
                    TotalPaidUp = "150000"
                }
            },
                FullName = "John Wong",
                AnnualReturnDate = "2018-01-10T06:14:00Z"
            };
        }
    }
}

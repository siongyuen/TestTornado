
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
                    CompanyName = "科技創新有限公司",
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
                    PhoneNo = "+1-800-123-4567",
                    FirstSecretary = new Secretary
                    {
                        SecretaryType = "Corporate",
                        ChineseName = "李婉",
                        EnglishName = "Emily Lee",
                        PreviousChineseName = "李静",
                        PreviousEnglishName = "Ember Lee",
                        AliasEnglish = "Emy",
                        AliasChinese = "婉儿",
                        AddressLine1 = "172 Jalan Bukit Bintang",
                        AddressLine2 = "Suite 1200",
                        AddressLine3 = "Kuala Lumpur",
                        EmailAddress = "evelynlee@example.com"
                    },
                    NumberOfIndividualSecretaries = "3"
                    ,
                    IndividualSecretaries = new List<Secretary>
                    {

                        new Secretary {
                            SecretaryType = "Individual",
                            ChineseName = "张小芳",
                            EnglishName = "Sophia Zhang",
                            PreviousChineseName = "张芳",
                            PreviousEnglishName = "Fanny Zhang",
                            AliasEnglish = "Soph",
                            AliasChinese = "小芳",
                            AddressLine1 = "5 Persiaran Residen",
                            AddressLine2 = "Unit 5",
                            AddressLine3 = "Desa Parkcity",
                            EmailAddress = "sophiaz@example.com"
                        },
                        new Secretary {
                            SecretaryType = "Individual",
                            ChineseName = "林瑞君",
                            EnglishName = "Rachel Lim",
                            PreviousChineseName = "林君",
                            PreviousEnglishName = "June Lim",
                            AliasEnglish = "Rach",
                            AliasChinese = "瑞儿",
                            AddressLine1 = "22 Mont Kiara",
                            AddressLine2 = "Apartment 2204",
                            AddressLine3 = "Mont Kiara",
                            EmailAddress = "rachell@example.com"
                        },
                        new Secretary {
                            SecretaryType = "Individual",
                            ChineseName = "陈大为",
                            EnglishName = "David Chen",
                            PreviousChineseName = "陈伟",
                            PreviousEnglishName = "Wei Chen",
                            AliasEnglish = "Dave",
                            AliasChinese = "大伟",
                            AddressLine1 = "33 Taman Tun Dr Ismail",
                            AddressLine2 = "Villa 33",
                            AddressLine3 = "Kuala Lumpur",
                            EmailAddress = "davidc@example.com"
                        } },
                    CorporateSecretaries = new List<Secretary>
                    {
                        new Secretary {
                            SecretaryType = "Corporate",
                            ChineseName = "李婉容",
                            EnglishName = "Evelyn Lee",
                            PreviousChineseName = "李静婷",
                            PreviousEnglishName = "Janet Lee",
                            AliasEnglish = "Evie",
                            AliasChinese = "婉儿",
                            AddressLine1 = "12 Jalan Bukit Bintang",
                            AddressLine2 = "Suite 1200",
                            AddressLine3 = "Kuala Lumpur",
                            EmailAddress = "evelynlee@example.com"
                        },
                        new Secretary {
                            SecretaryType = "Corporate",
                            ChineseName = "王美丽",
                            EnglishName = "Melissa Wang",
                            PreviousChineseName = "王丽",
                            PreviousEnglishName = "Lily Wang",
                            AliasEnglish = "Mel",
                            AliasChinese = "美美",
                            AddressLine1 = "88 Desa Parkcity",
                            AddressLine2 = "Block B",
                            AddressLine3 = "Kuala Lumpur",
                            EmailAddress = "melissaw@example.com"
                        }
                     ,
                    },
                    ParticularMember1 = "Y",
                    ParticularMember2 = "N",
                    ParticularMember3 = "Y",
                    FirstTwoCompanyRecords = new List<CompanyRecord>
                    {
                        new CompanyRecord
                        {
                            CompanyName = "Tech Innovations Ltd.",
                            CompanyAddressLine1 = "123 Tech Road",
                            CompanyAddressLine2 = "Tech Park",
                            CompanyAddressLine3 = "Innovation City",
                            CompanyAddressLine4 = "TechState 01011"
                        },
                        new CompanyRecord
                        {
                            CompanyName = "Creative Solutions Inc.",
                            CompanyAddressLine1 = "456 Creative Ave",
                            CompanyAddressLine2 = "Suite 200",
                            CompanyAddressLine3 = "Creativity Town",
                            CompanyAddressLine4 = "SolutionState 02222"
                        }
                    },



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
                AnnualReturnDate = "2018-01-10T06:14:00Z",
                Pages = new List<Page>
                            { new Page
                                    { CLIENT = new Client {
                                        TheRestOfCompanyRecords = new List<CompanyRecord>
                                        {
                                            new CompanyRecord
                                            {
                                                CompanyName = "Tech 1 Innovations Ltd.",
                                                CompanyAddressLine1 = "123 Tech Road",
                                                CompanyAddressLine2 = "Tech Park",
                                                CompanyAddressLine3 = "Innovation City",
                                                CompanyAddressLine4 = "TechState 01011",
                                                ContinuationSheetE = "Y"
                                            },
                                            new CompanyRecord
                                            {
                                                CompanyName = "Creative 2 Solutions Inc.",
                                                CompanyAddressLine1 = "456 Creative Ave",
                                                CompanyAddressLine2 = "Suite 200",
                                                CompanyAddressLine3 = "Creativity Town",
                                                CompanyAddressLine4 = "SolutionState 02222",
                                                ContinuationSheetE = "Y"
                                            },
                                                new CompanyRecord
                                            {
                                                CompanyName = "Tech 3 Innovations Ltd.",
                                                CompanyAddressLine1 = "123 Tech Road",
                                                CompanyAddressLine2 = "Tech Park",
                                                CompanyAddressLine3 = "Innovation City",
                                                CompanyAddressLine4 = "TechState 01011"
                                            }
                                        }


                                    }


                            },
                            { new Page
                                    { CLIENT = new Client {
                                        TheRestOfCompanyRecords = new List<CompanyRecord>
                                        {
                                            new CompanyRecord
                                            {
                                                CompanyName = "Tech 4 Innovations Ltd.",
                                                CompanyAddressLine1 = "123 Tech Road",
                                                CompanyAddressLine2 = "Tech Park",
                                                CompanyAddressLine3 = "Innovation City",
                                                CompanyAddressLine4 = "TechState 01011",
                                                ContinuationSheetE = "Y"
                                            },
                                            new CompanyRecord
                                            {
                                                CompanyName = "Creative 5 Solutions Inc.",
                                                CompanyAddressLine1 = "456 Creative Ave",
                                                CompanyAddressLine2 = "Suite 200",
                                                CompanyAddressLine3 = "Creativity Town",
                                                CompanyAddressLine4 = "SolutionState 02222",
                                                ContinuationSheetE = "Y"
                                            },
                                                new CompanyRecord
                                            {
                                                CompanyName = "Tech 6 Innovations Ltd.",
                                                CompanyAddressLine1 = "123 Tech Road",
                                                CompanyAddressLine2 = "Tech Park",
                                                CompanyAddressLine3 = "Innovation City",
                                                CompanyAddressLine4 = "TechState 01011"
                                            }
                                            
                                        }


                                    }


                            }

                    }
                }
            };
        }
    } 
}
        
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Forms.HK23NAR1
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public string CompanyName { get; set; }
        public string BusinessName { get; set; }
        public string BusinessNatureCode { get; set; }
        public string BusinessNature { get; set; }
        public MainIndAppt MAININDAPPT { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }

    public class MainIndAppt
    {
        public IndEntity IndEntity { get; set; }
    }

    public class IndEntity
    {
        public CorrespondenceAddress CorrespondenceAddress { get; set; }
    }

    public class CorrespondenceAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Country { get; set; }
    }

    public class Building
    {
        public string NameNumber { get; set; }
    }

    public class Presenter
    {
        public string ChineseSurname { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string UserCodeFormQueueNumber { get; set; }
    }

    public class Share
    {
        public string ClassOfShare { get; set; }
        public string Currency { get; set; }
        public string TotalNumber { get; set; }
        public string TotalAmount { get; set; }
        public string TotalPaidUp { get; set; }
    }

    public class DataModel
    {
        public Client CLIENT { get; set; }
        public Building Building { get; set; }
        public Presenter Presenter { get; set; }
        public List<Share> Shares { get; set; }
        public string FullName { get; set; }

        public string AnnualReturnDate { get; set; }
    }

}

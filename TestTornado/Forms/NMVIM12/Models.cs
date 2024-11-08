using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Forms.NMVIM12
{
    public record Address
    {
        public string? UnitNumber { get; init; }
        public string? FloorNumber { get; init; }
        public string? Block { get; init; }
        public string? BuildingName { get; init; }
        public string? Street { get; init; }
        public string? Village { get; init; }
        public string? District { get; init; }
        public string? City { get; init; }
        public string? Region { get; init; }
        public string? Postcode { get; init; }
        public string? CountryName { get; init; }
    }

    public record Individual
    {
        public string? FullName { get; init; }
        public Address? Addresses { get; init; }
    }

    public record Appointment
    {
        public string? DateAppointed { get; init; }
        public string? NatureOfDirector { get; init; }
        public string? OfficerType { get; init; }
        public Individual? Individual { get; init; }
    }

    public record BusinessEntity
    {
        public string? RegistrationNumber { get; init; }
        public string? Name { get; init; }
        public List<Appointment>? Appointments { get; init; }
    }

    public record Agent
    {
        public string? Name { get; init; }
        public string? AddressLine1 { get; init; }
        public string? AddressLine2 { get; init; }
        public string? City { get; init; }
        public string? State { get; init; }
        public string? Country { get; init; }
        public string? PostCode { get; init; }
    }

    public record RootObject
    {
        public BusinessEntity? BusinessEntity { get; init; }
        public Agent? Agent { get; init; }
        public string? EffectiveDate { get; init; }
    }

}

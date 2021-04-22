namespace Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.ApiClient
{
    public class CreatePersonRequest
    {
        public string PersonId { get; set; }
        public string CategoryId { get; set; }
        public string UifObligatedSubject { get; set; }
        public string Alias { get; set; }
        public NaturalPerson NaturalPerson { get; set; }
        public Addresses Adresses { get; set; }
        public Email Email { get; set; }
        public IdentificationDocuments IdentificationDocuments { get; set; }
        public Phones Phones { get; set; }
        public Roles Roles { get; set; }
        public TaxCategories TaxCategoriess { get; set; }
        public TaxRates TaxRates { get; set; }
    }

    public class NaturalPerson
    {
        public string FirstName { get; set; }
        public string LastNamePrefix { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string BirthCountry { get; set; }
    }

    public class Addresses
    {
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string AddressType { get; set; }
        public string PostalCode { get; set; }
        public string StateCode { get; set; }
        public string CityCode { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string AddressLine { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PostOfficeBoxCode { get; set; }
        public string PoboxPostalCode { get; set; }
        public string Coname { get; set; }
        public string Neighborhood { get; set; }
        public CustomFields CustomFields { get; set; }
    }

    public class Email
    {
        //public string ValidFrom { get; set; }
        //public string ValidTo { get; set; }
        public string EmailAdress { get; set; }
        public string EmailAddressValidated { get; set; }
    }

    public class IdentificationDocuments
    {
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string CountryID { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentNumber { get; set; }
        public string IssuingDate { get; set; }
        public string IssuingAuthority { get; set; }
        public string ExpiryDate { get; set; }
        public CustomFields CustomFields { get; set; }
    }

    public class Phones
    {
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string PhoneType { get; set; }
        public string CountryCallingCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public CustomFields CustomFields { get; set; }
    }

    public class Roles
    {
        public string RoleType { get; set; }
        public string BusinessUnitID { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
    }


    public class TaxCategories
    {
        public string TaxType { get; set; }
        public string TaxCategory { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
    }

    public class TaxRates
    {
        public string TaxType { get; set; }
        public string StateCode { get; set; }
        public string PercentRate { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
    }

    public class CustomFields
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
    }
}


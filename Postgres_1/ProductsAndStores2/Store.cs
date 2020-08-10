using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class Store
    {
        public int StoreId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int BusinessEntityId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string BrandStoreNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public int ZipOrPostalCode { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Zone { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string ExtensionProperty { get; set; }
    }
}

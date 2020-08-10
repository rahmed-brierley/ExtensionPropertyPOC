using System;
using System.Collections.Generic;

namespace Postgres_1.ProductsAndStores
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int BusinessEntityId { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }
        public string ExtensionProperty { get; set; }
    }
}

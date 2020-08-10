using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class ProductGroup
    {
        public int ProductGroupId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Criteria { get; set; }
    }
}

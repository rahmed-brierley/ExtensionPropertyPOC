using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class ProductDefinitions
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int ProductDefinitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProgramEntityId { get; set; }
    }
}

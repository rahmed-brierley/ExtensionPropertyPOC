using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class ExtensionPropertyEntity
    {
        public int ExtensionPropertyEntityId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int BusinessEntityId { get; set; }
        public Guid? ExtensionPropertySchemaGuid { get; set; }
        public int? ExtensionPropertySchemaId { get; set; }

        public virtual ExtensionPropertySchema ExtensionPropertySchema { get; set; }
    }
}

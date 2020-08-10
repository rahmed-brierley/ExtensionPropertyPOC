using System;
using System.Collections.Generic;

namespace Postgres_1.ExProp
{
    public partial class ExtensionPropertySchema
    {
        public int ExtensionPropertySchemaId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string TargetTableName { get; set; }
        public string DisplayText { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public string Alias { get; set; }
        public string JsonSchema { get; set; }
        public int? ExtensionPropertyId { get; set; }
        public Guid? ExtensionPropertyGuid { get; set; }

        public virtual ExtensionProperty ExtensionProperty { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class ExtensionProperty
    {
        public int ExtensionPropertyId { get; set; }
        public string ColumnName { get; set; }
        public int ExtensionDomainId { get; set; }
        public string DisplayText { get; set; }
        public string Description { get; set; }
        public string DataType { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool IsDsar { get; set; }
        public bool IsRtbf { get; set; }
        public string DefaultValue { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsEncrypted { get; set; }

        public virtual ExtensionDomain ExtensionDomain { get; set; }
    }
}

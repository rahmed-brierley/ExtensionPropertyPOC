using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class ExtensionProperty1
    {
        public ExtensionProperty1()
        {
            ExtensionPropertySchema = new HashSet<ExtensionPropertySchema>();
            InverseParentExtensionProperty = new HashSet<ExtensionProperty1>();
        }

        public int ExtensionPropertyId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public bool IsRequired { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool IsUnique { get; set; }
        public string EncryptionType { get; set; }
        public bool IsDsar { get; set; }
        public bool IsRtbf { get; set; }
        public string DisplayText { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public Guid? ParentExtensionPropertyGuid { get; set; }
        public int? ParentExtensionPropertyId { get; set; }

        public virtual ExtensionProperty1 ParentExtensionProperty { get; set; }
        public virtual ICollection<ExtensionPropertySchema> ExtensionPropertySchema { get; set; }
        public virtual ICollection<ExtensionProperty1> InverseParentExtensionProperty { get; set; }
    }
}

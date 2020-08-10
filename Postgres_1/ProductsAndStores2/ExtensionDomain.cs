using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class ExtensionDomain
    {
        public ExtensionDomain()
        {
            ExtensionProperty = new HashSet<ExtensionProperty>();
        }

        public int ExtensionDomainId { get; set; }
        public string TargetTableName { get; set; }
        public int OwnerId { get; set; }
        public string DisplayText { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual ICollection<ExtensionProperty> ExtensionProperty { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Postgres_1
{
    public partial class CoreAttributesMetaData
    {
        public int AttributeId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string AttributeMetadataJson { get; set; }
        public string Key { get; set; }
    }
}

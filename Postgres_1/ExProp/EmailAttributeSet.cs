using System;
using System.Collections.Generic;

namespace Postgres_1.ExProp
{
    public partial class EmailAttributeSet
    {
        public int EmailAttributeSetId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string AttributeSet { get; set; }
        public int EmailTemplateId { get; set; }
        public Guid EmailTemplateGuid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual EmailTemplate EmailTemplate { get; set; }
    }
}

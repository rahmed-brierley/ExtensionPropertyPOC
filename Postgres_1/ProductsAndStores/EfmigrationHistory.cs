using System;
using System.Collections.Generic;

namespace Postgres_1.ProductsAndStores
{
    public partial class EfmigrationHistory
    {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DF_Project_APIs.Models
{
    public partial class AstitvaAccountHolderTable
    {
        public AstitvaAccountHolderTable()
        {
            AstitvaNomineeTables = new HashSet<AstitvaNomineeTable>();
        }

        public int AccountholderId { get; set; }
        public string? AccountholderName { get; set; }
        public string? AccountType { get; set; }
        public string? AccountNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<AstitvaNomineeTable> AstitvaNomineeTables { get; set; }
    }
}

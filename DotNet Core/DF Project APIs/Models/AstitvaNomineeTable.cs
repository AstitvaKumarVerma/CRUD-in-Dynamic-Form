using System;
using System.Collections.Generic;

namespace DF_Project_APIs.Models
{
    public partial class AstitvaNomineeTable
    {
        public int NomineeId { get; set; }
        public string? NomineeName { get; set; }
        public int? NomineeAge { get; set; }
        public string? AddressType { get; set; }
        public string? Address { get; set; }
        public int? AccountHolderId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual AstitvaAccountHolderTable? AccountHolder { get; set; }
    }
}

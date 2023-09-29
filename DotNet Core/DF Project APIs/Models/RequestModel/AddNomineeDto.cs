using System.ComponentModel;

namespace DF_Project_APIs.Models.RequestModel
{
    public class AddNomineeDto
    {
        public int NomineeId { get; set; }
        public string? NomineeName { get; set; }
        public int? NomineeAge { get; set; }
        public string? AddressType { get; set; }
        public string? Address { get; set; }
        public int? AccountHolderId { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
    }
}

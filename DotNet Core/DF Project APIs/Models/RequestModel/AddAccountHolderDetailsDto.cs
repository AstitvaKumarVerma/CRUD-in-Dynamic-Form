using System.ComponentModel;

namespace DF_Project_APIs.Models.RequestModel
{
    public class AddAccountHolderDetailsDto
    {
        public string? AccountholderName { get; set; }
        public string? AccountType { get; set; }
        public string? AccountNumber { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
        public List<AddNomineeDto> Nominees { get; set; } = new List<AddNomineeDto>();
    }
}

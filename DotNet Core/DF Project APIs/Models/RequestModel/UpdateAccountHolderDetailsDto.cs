using System.ComponentModel;

namespace DF_Project_APIs.Models.RequestModel
{
    public class UpdateAccountHolderDetailsDto
    {
        public int AccountholderId { get; set; }
        public string? AccountholderName { get; set; }
        public string? AccountType { get; set; }
        public string? AccountNumber { get; set; }
        public List<AddNomineeDto> Nominees { get; set; } = new List<AddNomineeDto>();
    }
}

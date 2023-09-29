using DF_Project_APIs.Models;
using DF_Project_APIs.Models.ReponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DF_Project_APIs.Feature.Customer.Command
{
    public class DeleteAccountHolderDetailsCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }
        public class DeleteAccountHolderDetailsCommandHandler : IRequestHandler<DeleteAccountHolderDetailsCommand, ResponseDto>
        {
            private readonly sdirectdbContext _dbContext;
            public DeleteAccountHolderDetailsCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(DeleteAccountHolderDetailsCommand request, CancellationToken cancellationToken)
            {
                ResponseDto obj = new ResponseDto();

                var data = _dbContext.AstitvaAccountHolderTables.FirstOrDefault(l => l.AccountholderId == request.Id);

                if (data != null)
                {
                    data.IsActive = false;
                    data.IsDeleted = true;

                    _dbContext.SaveChanges();

                    obj.StatusCode = 200;
                    obj.Message = "Delete Successfully.";
                    return obj;
                }
                else
                {
                    obj.StatusCode = 404;
                    obj.Message = "Id Does not Exist.";
                    return obj;
                }
            }
        }
    }
}

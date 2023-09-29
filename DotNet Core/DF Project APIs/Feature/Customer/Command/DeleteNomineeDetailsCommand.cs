using DF_Project_APIs.Models;
using DF_Project_APIs.Models.ReponseModel;
using MediatR;

namespace DF_Project_APIs.Feature.Customer.Command
{
    public class DeleteNomineeDetailsCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }
        public class DeleteNomineeDetailsCommandHandler : IRequestHandler<DeleteNomineeDetailsCommand, ResponseDto>
        {
            private readonly sdirectdbContext _dbContext;
            public DeleteNomineeDetailsCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(DeleteNomineeDetailsCommand request, CancellationToken cancellationToken)
            {
                ResponseDto obj = new ResponseDto();

                var nomineeData = _dbContext.AstitvaNomineeTables.FirstOrDefault(n => n.NomineeId == request.Id);
                
                if (nomineeData != null)
                {
                    nomineeData.IsActive = false;
                    nomineeData.IsDeleted = true;

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

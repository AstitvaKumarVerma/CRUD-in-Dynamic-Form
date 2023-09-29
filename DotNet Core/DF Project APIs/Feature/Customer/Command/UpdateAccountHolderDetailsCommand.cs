using DF_Project_APIs.Models;
using DF_Project_APIs.Models.ReponseModel;
using DF_Project_APIs.Models.RequestModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DF_Project_APIs.Feature.Customer.Command
{
    public class UpdateAccountHolderDetailsCommand: UpdateAccountHolderDetailsDto, IRequest<ResponseDto>
    {
        public class UpdateAccountHolderDetailsCommandHandler : IRequestHandler<UpdateAccountHolderDetailsCommand, ResponseDto>
        {
            private readonly sdirectdbContext _dbContext;
            public UpdateAccountHolderDetailsCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(UpdateAccountHolderDetailsCommand request, CancellationToken cancellationToken)
            {
                ResponseDto resObj = new ResponseDto();

                AstitvaNomineeTable obj = new AstitvaNomineeTable();

                try
                {
                    var data = _dbContext.AstitvaAccountHolderTables.Where(a => a.AccountholderId == request.AccountholderId).FirstOrDefault();

                    if (data != null)
                    {
                        data.AccountholderId = request.AccountholderId;
                        data.AccountholderName = request.AccountholderName;
                        data.AccountType = request.AccountType;
                        data.AccountNumber = request.AccountNumber;

                        _dbContext.SaveChanges();

                        foreach (var nomineesData in request.Nominees)
                        {
                            var existnomineesData = _dbContext.AstitvaNomineeTables.Where(n => n.NomineeId == nomineesData.NomineeId).FirstOrDefault();

                            if (existnomineesData != null)
                            {
                                existnomineesData.NomineeName = nomineesData.NomineeName;
                                existnomineesData.NomineeAge = nomineesData.NomineeAge;
                                existnomineesData.AddressType = nomineesData.AddressType;
                                existnomineesData.Address = nomineesData.Address;
                                _dbContext.SaveChanges();
                            }
                            else
                            {
                                if (nomineesData.NomineeId == 0)
                                {
                                    obj.AccountHolderId = data.AccountholderId;
                                    obj.NomineeName = nomineesData.NomineeName;
                                    obj.NomineeAge = nomineesData.NomineeAge;
                                    obj.AddressType = nomineesData.AddressType;
                                    obj.Address = nomineesData.Address;
                                    _dbContext.AstitvaNomineeTables.Add(obj);
                                    _dbContext.SaveChanges();
                                }
                            }
                        }
                        resObj.StatusCode = 200;
                        resObj.Message = "Update Succcessfully";

                        return resObj;
                    }

                    resObj.StatusCode = 403;
                    resObj.Message = "Id Not FoundCode";

                    return resObj;
                }
                catch (Exception ex)
                {
                    resObj.StatusCode = 500;
                    resObj.Message = ex.Message;

                    return resObj;
                }
            }
        }
    }
}

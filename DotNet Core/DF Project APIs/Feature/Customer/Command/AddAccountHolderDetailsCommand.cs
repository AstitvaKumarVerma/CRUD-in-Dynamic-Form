using DF_Project_APIs.Models;
using DF_Project_APIs.Models.ReponseModel;
using DF_Project_APIs.Models.RequestModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DF_Project_APIs.Feature.Customer.Command
{
    public class AddAccountHolderDetailsCommand : AddAccountHolderDetailsDto, IRequest<ResponseDto>
    {
        public class AddAccountHolderDetailsCommandHandler : IRequestHandler<AddAccountHolderDetailsCommand, ResponseDto>
        {
            private readonly sdirectdbContext _dbContext;
            public AddAccountHolderDetailsCommandHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(AddAccountHolderDetailsCommand request, CancellationToken cancellationToken)
            {
                ResponseDto res = new ResponseDto();

                try
                {
                    var data = _dbContext.AstitvaAccountHolderTables.FirstOrDefault(x => x.AccountholderName == request.AccountholderName);
                    if (data != null)
                    {
                        res.StatusCode = 203;
                        res.Message = "Already Exits";
                        return res;
                    }
                    else
                    {
                        var AccountholderData = new AstitvaAccountHolderTable()
                        {
                            AccountholderName = request.AccountholderName,
                            AccountType = request.AccountType,
                            AccountNumber = request.AccountNumber,
                            IsActive = true,
                            IsDeleted = false,
                        };

                        _dbContext.AstitvaAccountHolderTables.Add(AccountholderData);
                        _dbContext.SaveChanges();


                        List<AstitvaNomineeTable> obj = new List<AstitvaNomineeTable>();
                        foreach (var n in request.Nominees)
                        {
                            var NomineeData = new AstitvaNomineeTable()
                            {
                                NomineeName = n.NomineeName,
                                NomineeAge = n.NomineeAge,
                                AddressType = n.AddressType,
                                Address = n.Address,
                                AccountHolderId = AccountholderData.AccountholderId,
                                IsActive = true,
                                IsDeleted = false,
                            };

                            obj.Add(NomineeData);
                        }

                        _dbContext.AstitvaNomineeTables.AddRange(obj);
                        _dbContext.SaveChanges();
                        res.Message = "Add Succcessfully";
                        res.StatusCode = 200;
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    res.Message = ex.Message;
                    res.StatusCode = 500;
                    return res;
                }
            }
        }
    }
}

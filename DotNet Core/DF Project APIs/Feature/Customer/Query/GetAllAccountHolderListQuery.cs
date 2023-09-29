using DF_Project_APIs.Models;
using DF_Project_APIs.Models.RequestModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DF_Project_APIs.Feature.Customer.Query
{
    public class GetAllAccountHolderListQuery: IRequest<List<GetAllAccountHolderListDto>>
    {
        public class GetAllAccountHolderListQueryHandler : IRequestHandler<GetAllAccountHolderListQuery, List<GetAllAccountHolderListDto>>
        {
            private readonly sdirectdbContext _dbContext;
            public GetAllAccountHolderListQueryHandler(sdirectdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<List<GetAllAccountHolderListDto>> Handle(GetAllAccountHolderListQuery request, CancellationToken cancellationToken)
            {
                var data = (from acc in _dbContext.AstitvaAccountHolderTables
                            where acc.IsActive == true & acc.IsDeleted == false
                            orderby acc.AccountholderId descending
                            select new GetAllAccountHolderListDto()
                            {
                                AccountholderId = acc.AccountholderId,
                                AccountholderName = acc.AccountholderName,
                                AccountType = acc.AccountType,
                                AccountNumber = acc.AccountNumber,
                                Nominees = _dbContext.AstitvaNomineeTables.Where(n => n.AccountHolderId == acc.AccountholderId & n.IsActive == true & n.IsDeleted == false).ToList()
                            }).ToList();

                return data;
            }
        }
    }
}

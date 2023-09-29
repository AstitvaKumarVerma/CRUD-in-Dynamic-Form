using DF_Project_APIs.Feature.Customer.Command;
using DF_Project_APIs.Feature.Customer.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DF_Project_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("GetAllAccountHolderList")]
        public async Task<IActionResult> GetAllAccountHolderList()
        {
            var data = await Mediator.Send(new GetAllAccountHolderListQuery());
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAllAccountHolderbyId")]
        public async Task<IActionResult> GetAllAccountHolderbyId(int AccountHolderId)
        {
            var data = await Mediator.Send(new GetAccountHolderByIdQuery { Id = AccountHolderId });
            return Ok(data);
        }

        [HttpPost]
        [Route("AddAccountHolderDetails")]
        public async Task<IActionResult> AddAccountHolderDetails(AddAccountHolderDetailsCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPut]
        [Route("UpdateAccountHolderDetails")]
        public async Task<IActionResult> UpdateAccountHolderDetails(UpdateAccountHolderDetailsCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpDelete]
        [Route("DeleteAccountHolderDetailsById")]

        public async Task<IActionResult> DeleteAccountHolderDetails(int AccountHolderId)
        {
            var data = await Mediator.Send(new DeleteAccountHolderDetailsCommand { Id = AccountHolderId });
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteNomineeDetailsById")]

        public async Task<IActionResult> DeleteNomineeDetailsById(int NomineeId)
        {
            var data = await Mediator.Send(new DeleteNomineeDetailsCommand { Id = NomineeId });
            return Ok(data);
        }
    }
}

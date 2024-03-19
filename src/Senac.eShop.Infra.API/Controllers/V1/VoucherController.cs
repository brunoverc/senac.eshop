using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Application.Interfaces;
using Senac.eShop.Application.ViewModel;

namespace Senac.eShop.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/voucher")]
    public class VoucherController : Controller
    {
        private readonly IVoucherAppService _voucherAppService;

        public VoucherController(IVoucherAppService voucherAppService)
        {
            _voucherAppService = voucherAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VoucherViewModel>> Get()
        {
            var result = _voucherAppService.Search(a => true);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<VoucherViewModel> Get(Guid id)
        {
            var result = _voucherAppService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult PostAsync([FromBody] VoucherViewModel model)
        {
            var result = _voucherAppService.Add(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] VoucherViewModel model)
        {
            return Ok(_voucherAppService.Update(model));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _voucherAppService.Remove(id);
            return Ok();
        }
    }
}

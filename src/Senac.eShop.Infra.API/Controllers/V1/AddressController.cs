using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Application.Interfaces;
using Senac.eShop.Application.ViewModel;

namespace Senac.eShop.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/address")]
    public class AddressController : Controller
    {
        private readonly IAddressAppService _addressAppService;

        public AddressController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        [HttpGet]
        // Traz todos os endereços cadastrados no sistema
        public ActionResult<IEnumerable<AddressViewModel>> Get()
        {
            var result = _addressAppService.Search(a => true);

            return Ok(result);
        }

        [HttpGet("{id}")]
        // Traz um Endereço de acordo com o seu ID
        public ActionResult<AddressViewModel> Get(Guid id)
        {
            var result = _addressAppService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        //Insere um endereço no banco de dados
        public ActionResult PostAsync([FromBody] AddressViewModel model)
        {
            var result = _addressAppService.Add(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] AddressViewModel model)
        {
            return Ok(_addressAppService.Update(model));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _addressAppService.Remove(id);
            return Ok();
        }
    }
}

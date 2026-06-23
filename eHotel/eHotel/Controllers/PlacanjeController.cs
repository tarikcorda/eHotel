
using eHotel.Dto.Placanje;
using eHotel.eHotel.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eHotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacanjaController : ControllerBase
    {
        private readonly IPlacanjeService _service;

        public PlacanjaController(IPlacanjeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<PlacanjeDto>> Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<PlacanjeDto> GetById(int id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("by-rezervacija/{rezervacijaId}")]
        public ActionResult<List<PlacanjeDto>> GetByRezervacijaId(int rezervacijaId)
        {
            return Ok(_service.GetByRezervacijaId(rezervacijaId));
        }

        [HttpPost]
        public ActionResult<PlacanjeDto> Insert([FromBody] PlacanjeInsertRequest request)
        {
            return Ok(_service.Insert(request));
        }

        [HttpPut("{id}")]
        public ActionResult<PlacanjeDto> Update(int id, [FromBody] PlacanjeUpdateRequest request)
        {
            return Ok(_service.Update(id, request));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}
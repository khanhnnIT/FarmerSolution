using BusinessObject;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private IFarmerRepository repository = new FarmerRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Farmer>> GetFarmers()
        {
            return (List<Farmer>)repository.GetFarmers();
        }

        [HttpGet("{id}")]
        public ActionResult<Farmer?> GetFarmerById([FromQuery] Guid id)
        {
            return repository.FindFarmerById(id);
        
        }

        [HttpGet("by-code")]
        public async Task<Farmer?> GetFarmerByCode([FromQuery] string code)
        {
            return repository.FindFarmerByCode(code);
        }


        [HttpPost]
        public IActionResult CreateFarmer(Farmer c)
        {
            repository.AddFarmer(c);
            return NoContent();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateFarmer(Guid id, [FromBody] Farmer c)
        {
            if (id != c.FarmerId)
            {
                return BadRequest("Farmer ID mismatch.");
            }

            var cus = repository.FindFarmerById(id);
            if (cus == null)
            {
                return NotFound();
            }
            repository.UpdateFarmer(c);
            return Ok(c);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFarmer(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("Farmer ID is missing.");
            }

            var Farmer = repository.FindFarmerById(id);
            if (Farmer == null)
            {
                return NotFound();
            }

            repository.DeleteFarmer(Farmer);
            return Ok(id);
        }
    }
}

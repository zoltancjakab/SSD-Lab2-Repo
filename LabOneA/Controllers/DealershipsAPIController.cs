using System.Linq;
using LabOneA.Models;
using LabOneA.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabOneA.Controllers
{
    [Produces("application/json")]
    [Route("api/DealershipsApi")]
    public class DealershipsApiController : Controller
    {
        private readonly IDealershipManager _dealershipManager;
        public DealershipsApiController(IDealershipManager dealershipManager)
        {
            _dealershipManager = dealershipManager;
        }

        // GET: api/DealershipsAPI
        [HttpGet]
        public IActionResult Get()
        {
            //returns type of IEnumerable<Dealership>
            return Ok(_dealershipManager.GetDealerships());
        }

        // GET: api/DealershipsAPI/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_dealershipManager.GetDealership(id));
        }

        // POST: api/DealershipsAPI
        [HttpPost]
        public IActionResult Post([FromBody]Dealership value)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
            }

            var success = _dealershipManager.CreateDealership(value);
            if (success)
            {
                return Ok("Success");
            }
            return BadRequest("Something went wrong");

        }

        // PUT: api/DealershipsAPI/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Dealership value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
            }
            var success = _dealershipManager.UpdateDealership(id, value);

            if (success)
            {
                return Ok("Success");
            }
            return BadRequest("Something went wrong");


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _dealershipManager.DeleteDealership(id);

            if (success)
            {
                return Ok("Success");
            }
            return BadRequest("Something went wrong");
        }


    }
}

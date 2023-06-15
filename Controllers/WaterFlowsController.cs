using Microsoft.AspNetCore.Mvc;
using WaterFlowApiRest.Repositories;
using WaterFlowApiRest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterFlowApiRest.Controllers
{
    //ALL swagger methods working as should
    [Route("api/[controller]")]
    [ApiController]
    public class WaterFlowsController : ControllerBase
    {
        private readonly WaterFlowsRepository _repository;
        public WaterFlowsController(WaterFlowsRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<WaterFlowsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<WaterFlow>> Get()
        {
            List<WaterFlow> WaterFlows = _repository.GetAll();
            if (WaterFlows == null) return NotFound("No WaterFlows exist");
            return Ok(WaterFlows);
        }

        // GET api/<WaterFlowsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<WaterFlow> Get(int id)
        {
            WaterFlow WaterFlow = _repository.GetById(id);
            if (WaterFlow == null) return NotFound("No such id" + id);
            return Ok(WaterFlow);
        }

        // POST api/<WaterFlowsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<WaterFlow> Post([FromBody] WaterFlow value)
        {
            try
            {
                WaterFlow createdWaterFlow = _repository.Add(value);
                return Created($"api/WaterFlowsController/{createdWaterFlow.Id}", createdWaterFlow);
            }
            catch (ArgumentException n)
            {
                return BadRequest(n.Message);
            }
        }
    }

}

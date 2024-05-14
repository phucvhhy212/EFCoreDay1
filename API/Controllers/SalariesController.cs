using Application.Dtos;
using Application.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        private readonly IMapper _mapper;

        public SalariesController(ISalaryService salaryService, IMapper mapper)
        {
            _salaryService = salaryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_salaryService.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var employee = _salaryService.Find(id);
                if (employee == null)
                {
                    return BadRequest("Salary not found");
                }
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(SalaryRequest salaryRequest)
        {
            try
            {
                _salaryService.Add(salaryRequest);
                return Ok("Created successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, SalaryRequest salaryRequest)
        {
            try
            {
                _salaryService.Update(id, salaryRequest);
                return Ok("Edit successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _salaryService.Delete(id);
                return Ok($"Delete salary {id} successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

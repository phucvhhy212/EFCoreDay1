using Application.Dtos;
using Application.IServices;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_departmentService.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(DepartmentRequest department)
        {
            try
            {
                _departmentService.Add(_mapper.Map<Department>(department));
                return Ok("Created successfully");
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
                var department = _departmentService.Find(id);
                if (department == null)
                {
                    return BadRequest("Department not found");
                }
                return Ok(department);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, DepartmentRequest department)
        {
            try
            {
                _departmentService.Update(id, _mapper.Map<Department>(department));
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
                _departmentService.Delete(id);
                return Ok($"Delete department {id} successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

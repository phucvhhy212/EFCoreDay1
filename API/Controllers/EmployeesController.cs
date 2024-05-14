using Application.Dtos;
using Application.IServices;
using Application.Services;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_employeeService.Get());
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
                var employee = _employeeService.Find(id);
                if (employee == null)
                {
                    return BadRequest("Employee not found");
                }
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(EmployeeRequest employeeRequest)
        {
            try
            {
                _employeeService.Add(employeeRequest);
                return Ok("Created successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, EmployeeRequest employeeRequest)
        {
            try
            {
                _employeeService.Update(id, employeeRequest);
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
                _employeeService.Delete(id);
                return Ok($"Delete employee {id} successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetWithDepartment")]
        public IActionResult GetWithDepartment()
        {
            try
            {
                var result = _employeeService.GetEmployeeWithDepartmentName();
                return Ok(_mapper.Map<List<EmployeeDepartmentResponse>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetWithProjects")]
        public IActionResult GetWithProjects()
        {
            try
            {
                return Ok(_employeeService.GetEmployeeWithProjects());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetFilterBySalaryAndJoinedDate")]
        public IActionResult GetFilterBySalaryAndJoinedDate()
        {
            try
            {
                return Ok(_employeeService.GetEmployeeBySalaryAndJoinedDate());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

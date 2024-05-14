using Application.Dtos;
using Application.IServices;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projectService.Get());
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
                var employee = _projectService.Find(id);
                if (employee == null)
                {
                    return BadRequest("Project not found");
                }
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ProjectRequest projectRequest)
        {
            try
            {
                _projectService.Add(_mapper.Map<Project>(projectRequest));
                return Ok("Created successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ProjectRequest projectRequest)
        {
            try
            {
                _projectService.Update(id, _mapper.Map<Project>(projectRequest));
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
                _projectService.Delete(id);
                return Ok($"Delete employee {id} successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

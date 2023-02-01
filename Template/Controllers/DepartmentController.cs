using AutoMapper;
using DTO;
using IService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;
        IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        [Route("GetAllDepartments")]
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {

                return Ok(await _departmentService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all Departments:{ex.Message}"
                });
            }
        }
        [Route("CreateDepartment")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentDTO departmentDTO)
        {
            try
            {
                if (departmentDTO == null) { return BadRequest(); }
                var _departmentDTO = _mapper.Map<Department>(departmentDTO);
                var isSuccess = _departmentService.CreateAsync(_departmentDTO);
                if (isSuccess)
                {

                    return Ok(_departmentDTO);
                }
                return Ok(_departmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all Students:{ex.Message}"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DepartmentDTO departmentDTO)
        {
            try
            {

                if (departmentDTO == null) { return BadRequest(); }

                var _departmentDTO = await _departmentService.GetByIdAsync(departmentDTO.Id);

                if (_departmentDTO == null)
                {
                    return NotFound();
                }
                _mapper.Map(departmentDTO, _departmentDTO);
                var isSuccess = _departmentService.UpdateAsync(_departmentDTO);

                return Ok(_departmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in updating division:{ex.Message}"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {



                var _departmentDTO = await _departmentService.GetByIdAsync(id);

                if (_departmentDTO == null)
                {
                    return NotFound();
                }
                var isSuccess = _departmentService.DeleteAsync(_departmentDTO);

                if (isSuccess)
                {
                    return Ok(isSuccess);
                }

                return Ok(!isSuccess);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in posting division:{ex.Message}"
                });
            }
        }

    }
}

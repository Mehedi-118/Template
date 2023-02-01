using AutoMapper;
using DTO;
using IService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.ComponentModel;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _courseService;
        IMapper _mapper;
        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        [Route("GetAllCourse")]
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            try
            {

                return Ok(await _courseService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all Departments:{ex.Message}"
                });
            }
        }
        [Route("GetAllCourseByDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetAllCourseByDepartment(int id)
        {
            try
            {

                return Ok(await _courseService.GetAllCourseByDepartment(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all Departments:{ex.Message}"
                });
            }
        }
        [Route("CreateCourse")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO courseDTO)
        {
            try
            {
                if (courseDTO == null) { return BadRequest(); }
                var _courseDTO = _mapper.Map<Course>(courseDTO);
                var isSuccess = _courseService.CreateAsync(_courseDTO);
                if (isSuccess)
                {

                    return Ok(_courseDTO);
                }
                return Ok(_courseDTO);
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
        public async Task<IActionResult> Update([FromBody] CourseDTO courseDTO)
        {
            try
            {

                if (courseDTO == null) { return BadRequest(); }

                var _courseDTO = await _courseService.GetByIdAsync(courseDTO.Id);

                if (_courseDTO == null)
                {
                    return NotFound();
                }
                _mapper.Map(courseDTO, _courseDTO);
                var isSuccess = _courseService.UpdateAsync(_courseDTO);

                return Ok(_courseDTO);
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



                var _courseDTO = await _courseService.GetByIdAsync(id);

                if (_courseDTO == null)
                {
                    return NotFound();
                }
                var isSuccess = _courseService.DeleteAsync(_courseDTO);

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

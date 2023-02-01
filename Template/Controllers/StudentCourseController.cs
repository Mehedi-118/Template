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
    public class StudentCourseController : ControllerBase
    {
        IStudentCourseService _studentCourseService;
        IMapper _mapper;
        public StudentCourseController(IStudentCourseService studentCourseService, IMapper mapper)
        {
            _studentCourseService = studentCourseService;
            _mapper = mapper;
        }
        [Route("GetAllDepartments")]
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {

                return Ok(await _studentCourseService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all Departments:{ex.Message}"
                });
            }
        }
        [Route("CreateStudent")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCoursesDTO studentCoursesDTO)
        {
            try
            {
                if (studentCoursesDTO == null) { return BadRequest(); }
                var _studentCoursesDTO = _mapper.Map<StudentCourses>(studentCoursesDTO);
                var isSuccess = _studentCourseService.CreateAsync(_studentCoursesDTO);
                if (isSuccess)
                {

                    return Ok(_studentCoursesDTO);
                }
                return Ok(_studentCoursesDTO);
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
        public async Task<IActionResult> Update([FromBody] CourseDTO studentCoursesDTO)
        {
            try
            {

                if (studentCoursesDTO == null) { return BadRequest(); }

                var _studentCoursesDTO = await _studentCourseService.GetByIdAsync(studentCoursesDTO.Id);

                if (_studentCoursesDTO == null)
                {
                    return NotFound();
                }
                _mapper.Map(studentCoursesDTO, _studentCoursesDTO);
                var isSuccess = _studentCourseService.UpdateAsync(_studentCoursesDTO);

                return Ok(_studentCoursesDTO);
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



                var _studentCoursesDTO = await _studentCourseService.GetByIdAsync(id);

                if (_studentCoursesDTO == null)
                {
                    return NotFound();
                }
                var isSuccess = _studentCourseService.DeleteAsync(_studentCoursesDTO);

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

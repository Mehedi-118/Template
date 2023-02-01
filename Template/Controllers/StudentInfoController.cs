using AutoMapper;
using DTO;
using IService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Model;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        IStudentService _studentService;
        IMapper _mapper;
        public StudentInfoController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [Route("GetAllStudents")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {

                return Ok(await _studentService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all Students:{ex.Message}"
                });
            }
        }
        [Route("CreateStudent")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentInfoDTO studentInfoDTO)
        {
            try
            {
                if (studentInfoDTO == null) { return BadRequest(); }
                var _studentInfoDTO = _mapper.Map<StudentInfo>(studentInfoDTO);
                var isSuccess = _studentService.CreateAsync(_studentInfoDTO);
                if (isSuccess)
                {

                    return Ok(_studentInfoDTO);
                }
                return Ok(_studentInfoDTO);
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
        public async Task<IActionResult> Update([FromBody] StudentInfoDTO studentInfoDTO)
        {
            try
            {
                
                if (studentInfoDTO == null) { return BadRequest(); }
               
                var _studentInfoDTO = await _studentService.GetByIdAsync(studentInfoDTO.Id);

                if (_studentInfoDTO == null)
                {
                    return NotFound();
                }
                _mapper.Map(studentInfoDTO, _studentInfoDTO);
                var isSuccess=_studentService.UpdateAsync(_studentInfoDTO);
                
                return Ok(_studentInfoDTO);
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
               

               
                var _studentInfoDTO = await _studentService.GetByIdAsync(id);

                if (_studentInfoDTO == null)
                {
                    return NotFound();
                }
                var isSuccess=_studentService.DeleteAsync(_studentInfoDTO);

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


        [Route("GetStudentsByCode")]
        [HttpGet]
        public async Task<IActionResult> GetStudentsByCode(string code)
        {
            try
            {
                var result = await _studentService.GetByCode(code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining Students By Code:{ex.Message}"
                });
            }
        }
    }
}

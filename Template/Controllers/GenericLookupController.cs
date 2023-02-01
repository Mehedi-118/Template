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
    public class GenericLookupController : ControllerBase
    {
        IGenericLookupService _genericLookupService;
        IMapper _mapper;
        public GenericLookupController(IGenericLookupService genericLookupService, IMapper mapper)
        {
            _genericLookupService = genericLookupService;
            _mapper = mapper;
        }
        [Route("GetAllGenericLookup")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenericLookup()
        {
            try
            {

                return Ok(await _genericLookupService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error obtaining all Departments:{ex.Message}"
                });
            }
        }
        [Route("CreateGenericLookup")]
        [HttpPost]
        public async Task<IActionResult> CreateGenericLookup([FromBody] GenericLookupDTO genericLookupDTO)
        {
            try
            {
                if (genericLookupDTO == null) { return BadRequest(); }
                var _genericLookupDTO = _mapper.Map<GenericLookup>(genericLookupDTO);
                var isSuccess = _genericLookupService.CreateAsync(_genericLookupDTO);
                if (isSuccess)
                {

                    return Ok(_genericLookupDTO);
                }
                return Ok(_genericLookupDTO);
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
        public async Task<IActionResult> Update([FromBody] DepartmentDTO genericLookupDTO)
        {
            try
            {

                if (genericLookupDTO == null) { return BadRequest(); }

                var _genericLookupDTO = await _genericLookupService.GetByIdAsync(genericLookupDTO.Id);

                if (_genericLookupDTO == null)
                {
                    return NotFound();
                }
                _mapper.Map(genericLookupDTO, _genericLookupDTO);
                var isSuccess = _genericLookupService.UpdateAsync(_genericLookupDTO);

                return Ok(_genericLookupDTO);
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



                var _genericLookupDTO = await _genericLookupService.GetByIdAsync(id);

                if (_genericLookupDTO == null)
                {
                    return NotFound();
                }
                var isSuccess = _genericLookupService.DeleteAsync(_genericLookupDTO);

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

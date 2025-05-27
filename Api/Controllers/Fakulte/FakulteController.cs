using BusinessLayer.DTOs.Fakulte;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers.Fakulte
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakulteController : ControllerBase
    {
        private readonly IFakulteService _fakulteService;
        public FakulteController(IFakulteService fakulteService)
        {
            _fakulteService = fakulteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFakulteler(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _fakulteService.GetAllAsync(cancellationToken);
                if (result == null)
                {
                    return NotFound("Fakülteler bulunamadı.");
                }
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }

        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFakulteById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _fakulteService.GetByIdAsync(id, cancellationToken);
                if (result == null)
                {
                    return NotFound("Fakülte bulunamadı.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }



        }

        [HttpPost]
        public async Task<IActionResult> CreateFakulte([FromBody] CreateFakulteDTO createFakulteDto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _fakulteService.AddAsync(createFakulteDto, cancellationToken);
                return CreatedAtAction(nameof(GetFakulteById), new { id = result.ID }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateFakulte(Guid id, [FromBody] UpdateFakulteDTO updateFakulteDto, CancellationToken cancellationToken)
        {
            try
            {
                await _fakulteService.UpdateAsync(id, updateFakulteDto, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFakulte(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _fakulteService.Remove(id, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }


        [HttpGet("universite/{universiteId:guid}")]
        public async Task<IActionResult> GetFakulteByUniversiteId(Guid universiteId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _fakulteService.GetFakulteByUniversiteAsync(universiteId, cancellationToken);

                if (result == null)
                {
                    return NotFound("Fakülteler bulunamadı.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

    }
}

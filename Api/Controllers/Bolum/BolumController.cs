using BusinessLayer.DTOs.Bolum;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers.Bolum
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolumController : ControllerBase
    {
        private readonly IBolumService _bolumService;
        public BolumController(IBolumService bolumService)
        {
            _bolumService = bolumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBolumler(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bolumService.GetAllAsync(cancellationToken);
                if (result == null)
                {
                    return NotFound("Bölümler bulunamadı.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBolumById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bolumService.GetByIdAsync(id, cancellationToken);
                if (result == null)
                {
                    return NotFound("Bölüm bulunamadı.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBolum([FromBody] CreateBolumDTO createBolumDto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bolumService.AddAsync(createBolumDto, cancellationToken);
                if (result == null)
                {
                    return BadRequest("Bölüm oluşturulamadı.");
                }
                return CreatedAtAction(nameof(GetBolumById), new { id = result.ID }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBolum(Guid id, [FromBody] UpdateBolumDTO updateBolumDto, CancellationToken cancellationToken)
        {
            try
            {
                await _bolumService.UpdateAsync(id, updateBolumDto, cancellationToken);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBolum(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _bolumService.Remove(id, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }


        }

        [HttpGet("fakulte/{fakulteId:guid}")]
        public async Task<IActionResult> GetBolumByFakulteId(Guid fakulteId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bolumService.GetBolumByFakulteId(fakulteId, cancellationToken);
                if (result == null)
                {
                    return NotFound("Bölümler bulunamadı.");
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

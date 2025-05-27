using BusinessLayer.DTOs.Odalar;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers.Oda
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdaController : ControllerBase
    {
        private readonly IOdaService _odaService;
        public OdaController(IOdaService odaService)
        {
            _odaService = odaService;
        }
        [HttpGet]
        public async Task<ActionResult> GetOda(CancellationToken cancellationToken)
        {
            try
            {
                var oda = await _odaService.GetAllAsync(cancellationToken);
                return Ok(oda);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetOdaID(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var odaDto = await _odaService.GetByIdAsync(id, cancellationToken);
                return Ok(odaDto);
            }
            catch (Exception ex) when (ex.Message.Contains("bulunamadı"))
            {
                return NotFound($"Hata: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddOda([FromBody] CreateOdaDTO createOdaDto, CancellationToken cancellationToken)
        {
            try
            {
                var oda = await _odaService.AddAsync(createOdaDto, cancellationToken);
                return CreatedAtAction(nameof(GetOdaID), new { id = oda.OdaID }, oda);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateOda(Guid id, [FromBody] UpdateOdaDTO updateOdaDto, CancellationToken cancellationToken)
        {
            try
            {
                await _odaService.UpdateAsync(id, updateOdaDto, cancellationToken);
                return Ok();
            }
            catch (Exception ex) when (ex.Message.Contains("bulunamadı"))
            {
                return NotFound($"Hata: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteOda(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _odaService.Remove(id, cancellationToken);
                return NoContent();
            }
            catch (Exception ex) when (ex.Message.Contains("bulunamadı"))
            {
                return NotFound($"Hata: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpGet("GetOdaByBolumID{bolumId:guid}")]
        public async Task<ActionResult> GetByBolumID(Guid bolumId, CancellationToken cancellationToken)
        {
            try
            {
                var oda = await _odaService.GetAllAsync(cancellationToken);
                var odaByBolumId = oda.Where(x => x.BolumID == bolumId).ToList();
                return Ok(odaByBolumId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
using BusinessLayer.DTOs.Mesaj;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers.Mesaj
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesajController : ControllerBase
    {
        private readonly IMesajService _mesajService;
        public MesajController(IMesajService mesajService)
        {
            _mesajService = mesajService;
        }


        [HttpGet]
        public async Task<ActionResult> GetMesaj(CancellationToken cancellationToken)
        {
            try
            {
                var mesaj = await _mesajService.GetAllAsync(cancellationToken);
                return Ok("Mesajlar");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetMesajID(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var mesajDto = await _mesajService.GetByIdAsync(id, cancellationToken);
                return Ok(mesajDto);
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
        public async Task<ActionResult> AddMesaj([FromBody] CreateMesajDTO createMesajDto, CancellationToken cancellationToken)
        {
            try
            {
                var mesaj = await _mesajService.AddAsync(createMesajDto, cancellationToken);
                return CreatedAtAction(nameof(GetMesajID), new { id = mesaj.OdaMesajID }, mesaj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }

        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateMesaj(Guid id, [FromBody] UpdateMesajDTO updateMesajDto, CancellationToken cancellationToken)
        {
            try
            {
                 await _mesajService.UpdateAsync(id, updateMesajDto, cancellationToken);
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
        public async Task<ActionResult> DeleteMesaj(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _mesajService.Remove(id, cancellationToken);
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

        [HttpGet("GetByOdaID/{odaId:guid}")]
        public async Task<ActionResult> GetByOdaID(Guid odaId, CancellationToken cancellationToken)
        {
            try
            {
                var mesajlar = await _mesajService.GetAllAsync(cancellationToken);
                var filteredMesajlar = mesajlar.Where(m => m.OdaID == odaId).ToList();
                return Ok(filteredMesajlar);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
        [HttpGet("GetByUserID/{userId:guid}")]
        public async Task<ActionResult> GetByUserID(Guid userId, CancellationToken cancellationToken)
        {
            try
            {
                var mesajlar = await _mesajService.GetAllAsync(cancellationToken);
                var filteredMesajlar = mesajlar.Where(m => m.UserID == userId).ToList();
                return Ok(filteredMesajlar);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}

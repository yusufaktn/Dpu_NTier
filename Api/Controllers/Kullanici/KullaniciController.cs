using BusinessLayer.DTOs.Kullanici;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers.Kullanici
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;
        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }



        [HttpPost("login/{email}/{password}")]
        public async Task<ActionResult> Login(string email, string password, CancellationToken cancellationToken)
        {
            try
            {
                var kullanici = await _kullaniciService.login(email, password, cancellationToken);
                if (kullanici == null)
                {
                    return NotFound("Kullanıcı bulunamadı");
                }
                return Ok(kullanici);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }




        [HttpGet]
        public async Task<ActionResult> GetKullanici(CancellationToken cancellationToken)
        {
            try
            {
                var kullanici = await _kullaniciService.GetAllAsync(cancellationToken);
                return Ok(kullanici);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetKullaniciID(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var kullaniciDto = await _kullaniciService.GetByIdAsync(id, cancellationToken);
                return Ok(kullaniciDto);
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
        public async Task<ActionResult> AddKullanici([FromBody] CreateKullaniciDTO createKullaniciDto, CancellationToken cancellationToken)
        {
            try
            {
                var kullanici = await _kullaniciService.AddAsync(createKullaniciDto, cancellationToken);
                return CreatedAtAction(nameof(GetKullaniciID), new { id = kullanici.Id }, kullanici);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateKullanici(Guid id, [FromBody] UpdateKullaniciDTO updateKullaniciDto, CancellationToken cancellationToken)
        {
            try
            {
                await _kullaniciService.UpdateAsync(id, updateKullaniciDto, cancellationToken);
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

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteKullanici(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _kullaniciService.Remove(id, cancellationToken);
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


    }
}

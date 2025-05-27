using BusinessLayer.DTOs.Dersler;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApiLayer.Controllers.Ders
{
    [Route("api/[controller]")] 
    [ApiController]             
    public class DersController : ControllerBase 
    {
        private readonly IDersService _dersService;
        public DersController(IDersService dersService)
        {
            _dersService = dersService;
            
        }

        // GET: api/Ders -> Tüm dersleri getirir
        [HttpGet]
        public async Task <ActionResult> GetDersler(CancellationToken cancellationToken)
        {
            try
            {
                var dersler = await _dersService.GetAllAsync(cancellationToken);
                return Ok(dersler); 
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Bir hata oluştu: {ex.Message}");
            }
        }

        // GET: api/Ders/{id} -> Belirli bir ID'ye sahip dersi getirir
        [HttpGet("{id:guid}")] 
        public async Task<ActionResult> GetDersID(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var dersDto = await _dersService.GetByIdAsync(id, cancellationToken);
                
                return Ok(dersDto); 
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

        // POST: api/Ders -> Yeni bir ders ekler
        [HttpPost]
        public async Task<ActionResult> AddDers([FromBody] CreateDersDTO createDersDto, CancellationToken cancellationToken)
        {
            

            try
            {
                var createdDers = await _dersService.AddAsync(createDersDto, cancellationToken);
                
                return CreatedAtAction(nameof(AddDers), new { id = createdDers.DersID }, createdDers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ders eklenirken bir hata oluştu: {ex.Message}");
            }
        }

        
        [HttpPut("{id:guid}")] 
        public async Task<IActionResult> UpdateDers(Guid id, [FromBody] UpdateDersDTO updateDersDto, CancellationToken cancellationToken)
        {     

            try
            {
                
                await _dersService.UpdateAsync(id, updateDersDto, cancellationToken);
                return NoContent(); 
            }
            catch (Exception ex) when (ex.Message.Contains("bulunamadı"))
            {
                return NotFound($"Güncelleme hatası: {ex.Message}"); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ders güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        // DELETE: api/Ders/{id} -> Belirli bir dersi siler
        [HttpDelete("{id:guid}")] 
        public async Task<IActionResult> DeleteDers(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                
                await _dersService.Remove(id, cancellationToken);
                return NoContent(); 
            }
            catch (Exception ex) when (ex.Message.Contains("bulunamadı"))
            {
                return NotFound($"Silme hatası: {ex.Message}"); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ders silinirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
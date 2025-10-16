using Microsoft.AspNetCore.Mvc;
using criptoAPI.Services;
using criptoAPI.DTOs;

namespace criptoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecryptController : ControllerBase
    {
        private readonly VernamService _vernamService;

        public DecryptController(VernamService decryptService)
        {
            _vernamService = decryptService;
        }

        [HttpPost]
        public IActionResult Decrypt([FromBody] DecryptRequestDto data)
        {
            try
            {
                var decryptedMessage = _vernamService.Decrypt(data.Message, data.Key);
                var response = new DecryptResponseDto { Decrypted = decryptedMessage };
                return Ok(response);
            }
            catch (Exception error)
            {
                return BadRequest(new { Error = error.Message });
            }
        }
    }
}

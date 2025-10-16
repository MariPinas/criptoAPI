using Microsoft.AspNetCore.Mvc;
using criptoAPI.Services;
using criptoAPI.DTOs;

namespace criptoAPI.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class EncryptController : ControllerBase
    {
        private readonly VernamService _vernamService;

        public EncryptController(VernamService encryptService)
        {
            _vernamService = encryptService;
        }

        [HttpPost]
        public IActionResult Encrypt([FromBody] EncryptRequestDto data)
        {
            try
            {
                var encryptedMessage = _vernamService.Encrypt(data.Message, data.Key);
                var response = new EncryptResponseDto { Encrypted = encryptedMessage };
                return Ok(response);
            }
            catch (Exception Error)
            {
                return BadRequest(new { message = Error.Message });
            }
        }
    }
}


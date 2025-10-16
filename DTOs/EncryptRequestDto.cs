namespace criptoAPI.DTOs
{
    public class EncryptRequestDto
    {
        public string Message { get; set; }= string.Empty;
        public string Key { get; set; } = string.Empty;
    }
}

namespace Seguimientos.Models
{
    public class Password
    {
        public int Length { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSymbols { get; set; }
        public string GeneratedPassword { get; set; }
    }
}

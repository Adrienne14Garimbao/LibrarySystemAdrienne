using System.ComponentModel.DataAnnotations;

namespace LibrarySystemAdrienne.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
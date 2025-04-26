using System.ComponentModel.DataAnnotations;

namespace CoreFuels.Model
{
    public class AuthorizationModel
    {
        [Required(ErrorMessage = "Пароль обязателен.")]
        [MinLength(4, ErrorMessage = "Пароль должен содержать минимум 4 символа.")]
        public string pass { get; set; }

        [Required(ErrorMessage = "Логин обязателен.")]
        [StringLength(50, ErrorMessage = "Логин не может превышать 50 символов.")]
        public string login { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NanniFlix.ViewModels;
public class RegisterVM
{
    [Display(Name = "Nome de Usuário")]
    [Required(ErrorMessage = "Por favor, informe seu nome de usuário")]
    [StringLength(30, ErrorMessage = "O nome deve possuir no máximo 30 caracteres")]
    public string Name { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Por favor, informe seu email")]
    public string Email { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "Por favor, informe a Data de Nascimento")]
    public DateTime Birthday { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Senha de Acesso")]
    [Required(ErrorMessage = "Por favor, informe sua senha")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirme sua senha")]
    [Required(ErrorMessage = "As senhas não se coincidem")]
    public string ConfirmPassword { get; set; }
}
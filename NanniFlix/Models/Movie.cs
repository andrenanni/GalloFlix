using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanniFlix.Models;

[Table("Movie")]
public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public sbyte Id { get; set; }
    
    [Display(Name = "Titulo Original")]
    [Required(ErrorMessage = "Favor informar o Titulo Original")]
    [StringLength(100, ErrorMessage ="O Titulo Original deve possuir no máximo 30 caracteres")]
    public string OriginalTitle { get; set; }
}

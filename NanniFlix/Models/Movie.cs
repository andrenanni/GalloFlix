using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanniFlix.Models;

[Table("Movie")]
public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }
    
    [Display(Name = "Titulo Original")]
    [Required(ErrorMessage = "Favor informar o Titulo Original")]
    [StringLength(100, ErrorMessage ="O Titulo Original deve possuir no máximo 30 caracteres")]
    public string OriginalTitle { get; set; }

    [Display(Name = "Titulo")]
    [Required(ErrorMessage = "Favor informar o Titulo Original")]
    [StringLength(100, ErrorMessage ="O Titulo Original deve possuir no máximo 30 caracteres")]
    public string Title { get; set; }

    [Display(Name = "Resumo")]
    [StringLength(8000, ErrorMessage ="O Titulo Original deve possuir no máximo 30 caracteres")]
    public string Synopsis { get; set; }

    [Column(TypeName = "Year")]
    [Display(Name = "Ano de Estreia")]
    public Int16 MovieYear { get; set; }

    [Display(Name = "Duração (em minutos)")]
    [Required(ErrorMessage = "Por favor, informe a Duração")]
    public Int16 Duration { get; set; }

    [Display(Name = "Classificação Etária")]
    [Required(ErrorMessage = "Por favor, informe a Classificação Etária")]
    public sbyte AgeRating { get; set; } = 0;

    [StringLength(200)]
    [Display(Name = "Foto")]
    public string Image { get; set; }

    [NotMapped]
    [Display(Name = "Duração")]
    public string HourDuration { get{
        return TimeSpan.FromMinutes(Duration).ToString(@"%h'h 'mm");
    } }

    public ICollection<MovieGenre> Genres { get; set; }
}

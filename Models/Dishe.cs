#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Assignment_CRUDelicious.Models;

public class Dishe
{
    [Key]
    public int DisheId {get;set;}
    
    [Required(ErrorMessage = "The Name field is required")]
    public string Name {get;set;}

    [Required(ErrorMessage = "The Chef field is required")]
    public string Chef {get;set;}

    [Required(ErrorMessage = "The Tastiness field is required")]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int Tastiness {get;set;}

    [Required(ErrorMessage = "The Calories field is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0")]
    public int Calories {get;set;}

    [Required(ErrorMessage = "The Description field is required")]
    [DataType(DataType.Text)]
    public string Description {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}
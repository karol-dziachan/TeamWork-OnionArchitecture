using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamWorkMVC.Domain.Models;

public class Address
{
     public int Id { get; set; }
     
     [DefaultValue(null)]
     public string? Apartment { get; set; }
   
     [Required]
     public string Building { get; set; }
   
     [Required]
     public string Street { get; set; }
   
     [Required]
     public string City { get; set; }
   
     [Required]
     public string ZipCode { get; set; }
   
     [Required]
     public string Country { get; set; }
     
     public string? AppUserId { get; set; }
     
     public virtual AppUser AppUser { get; set; }
}
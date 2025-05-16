using System.ComponentModel.DataAnnotations;

namespace KolokwiumABPD.Models;

public class Patient
{
    [Required]
    public int PatientId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }
    
    [StringLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
}
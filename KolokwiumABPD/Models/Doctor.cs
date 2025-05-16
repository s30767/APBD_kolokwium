using System.ComponentModel.DataAnnotations;

namespace KolokwiumABPD.Models;

public class Doctor
{
    [Required]
    public int DoctorId { get; set; }
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(100)]
    public string LastName { get; set; }
    [Required]
    public string PWZ { get; set; }
}
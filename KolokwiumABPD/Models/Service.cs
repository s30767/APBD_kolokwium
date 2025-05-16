using System.ComponentModel.DataAnnotations;

namespace KolokwiumABPD.Models;

public class Service
{
    [Required]
    public int ServiceId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name{get;set;}
    
    [Required]
    public decimal BaseFee {get;set;}
}
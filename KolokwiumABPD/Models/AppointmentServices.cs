using System.ComponentModel.DataAnnotations;

namespace KolokwiumABPD.Models;

public class AppointmentServices
{
    [Required]
    public int AppointmentId { get; set; }
    [Required]
    public int service_id{get;set;}
    [Required]
    public decimal serviceFee{get;set;}
}
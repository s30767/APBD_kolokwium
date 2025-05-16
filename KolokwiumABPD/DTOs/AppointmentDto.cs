using KolokwiumABPD.Models;

namespace KolokwiumABPD.DTOs;

public class AppointmentDto
{
    public DateTime Date { get; set; }
    public Patient Patient { get; set; }
    public DoctorDto Doctor { get; set; }
    public List<AppointmentServicesDto> AppointmentServices { get; set; }
}
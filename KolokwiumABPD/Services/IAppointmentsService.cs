using KolokwiumABPD.DTOs;

namespace KolokwiumABPD.Services;

public interface IAppointmentsService
{
    Task<IEnumerable<AppointmentDto>> GetAppointment(int id, CancellationToken cancellationToken);
    
}
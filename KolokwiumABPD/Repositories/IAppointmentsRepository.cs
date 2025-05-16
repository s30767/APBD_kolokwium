using KolokwiumABPD.DTOs;

namespace KolokwiumABPD.Repositories;

public interface IAppointmentsRepository
{
    Task<IEnumerable<AppointmentDto>> GetAppointment(int id, CancellationToken cancellationToken);
}
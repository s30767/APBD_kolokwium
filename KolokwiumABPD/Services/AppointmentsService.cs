using KolokwiumABPD.DTOs;
using KolokwiumABPD.Models;
using KolokwiumABPD.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace KolokwiumABPD.Services;

public class AppointmentsService : IAppointmentsService
{
    
    private readonly IAppointmentsRepository _appointmentsRepository;
    private readonly string _connectionString;
        
    
    public AppointmentsService(IAppointmentsRepository appointmentsRepository)
    {
        _appointmentsRepository = appointmentsRepository;
        _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=apbd;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
    
    public async Task<IEnumerable<AppointmentDto>> GetAppointment(int id, CancellationToken cancellationToken)
    {
        await using (var connect = new SqlConnection(_connectionString))
        {
            await connect.OpenAsync(cancellationToken);
            await using var sqlCommand = new SqlCommand("SELECT 1 FROM Appointment where appoitment_id = 1;");
            sqlCommand.Connection = connect;
            sqlCommand.Parameters.AddWithValue("@id", id);
            
            var exists = await sqlCommand.ExecuteScalarAsync(cancellationToken);
            if (exists == null)
            {
                return null;
            }
            var result = await _appointmentsRepository.GetAppointment(id, cancellationToken);
            
            return result;

        }
        
    }
}
using KolokwiumABPD.DTOs;
using KolokwiumABPD.Models;
using Microsoft.Data.SqlClient;

namespace KolokwiumABPD.Repositories;

public class AppointmentsRepository : IAppointmentsRepository
{
    
    private readonly string _connectionString;
    
    public AppointmentsRepository()
    {
        _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=apbd;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
    
    public async Task<IEnumerable<AppointmentDto>> GetAppointment(int id, CancellationToken cancellationToken)
    {
        List<AppointmentDto> appointments = new List<AppointmentDto>();
        await using (var connect = new SqlConnection(_connectionString))
        {
            await connect.OpenAsync(cancellationToken);
            await using var sqlCommand = new SqlCommand();
            sqlCommand.CommandText =
                @"SELECT a.date, p.first_name, p.last_name, p.date_of_birth, d.doctor_id, d.PWZ, s.name, aps.service_fee
                FROM Appointment a
                JOIN Patient p ON a.patient_id = p.patient_id
                JOIN Doctor d ON a.doctor_id = d.doctor_id
                JOIN Appointment_Service aps ON a.appoitment_id = aps.appoitment_id
                JOIN Service s On aps.service_id = s.service_id
                WHERE a.appoitment_id = @id;
                ";
            sqlCommand.Connection = connect;
            sqlCommand.Parameters.AddWithValue("@id", id);
            
            var reader = await sqlCommand.ExecuteReaderAsync(cancellationToken);

            AppointmentDto appointment = null;
            while (await reader.ReadAsync(cancellationToken))
            {   
                if (!reader.IsDBNull(0))
                {
                    appointment = new AppointmentDto
                    {
                        Date = reader.GetDateTime(reader.GetOrdinal("date")),
                        Patient = new Patient
                        {
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("date_of_birth"))
                        },
                        Doctor = new DoctorDto
                        {
                            DoctorID = reader.GetInt32(reader.GetOrdinal("doctor_id")),
                            PWZ = reader.GetString(reader.GetOrdinal("PWZ"))
                        },
                        AppointmentServices = new List<AppointmentServicesDto>()
                    };
                    appointments.Add(appointment);
                }
                
                appointment.AppointmentServices.Add(new AppointmentServicesDto()
                {
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    ServiceFee = reader.GetDecimal(reader.GetOrdinal("service_fee"))
                });
            }
        }
        return appointments;
    }
}
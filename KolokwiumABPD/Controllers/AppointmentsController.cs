using KolokwiumABPD.Models;
using KolokwiumABPD.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumABPD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentsService _service;
    
    public AppointmentsController(IAppointmentsService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppoinment(int id, CancellationToken cancellationToken)
    {
        
        var dane = await _service.GetAppointment(id, cancellationToken);

        if (dane == null)
        {
            return NotFound();
        }
        
        return Ok(dane);
    }
    
}
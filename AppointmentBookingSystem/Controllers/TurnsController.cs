using AppointmentBookingSystem.Context;
using AppointmentBookingSystem.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TurnsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public ActionResult GenerateTurns(DateTime startDate, DateTime endDate, int idService)
        {
            // Validar los parámetros de entrada
            if (startDate > endDate)
            {
                return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }

            // Obtener el servicio correspondiente al Id de Servicio
            var service = _dataContext.Services.SingleOrDefault(s => s.Id == idService);
            if (service == null)
            {
                return BadRequest("No existe un servicio con el Id especificado.");
            }

            // Generar los turnos correspondientes al servicio y fechas indicados
            var turns = GenerateTurns(service, startDate, endDate);


            // Guardar los turnos en la base de datos
            _dataContext.Turns.AddRange(turns);
            _dataContext.SaveChanges();

            return Ok(turns);
        }

        private List<Turn> GenerateTurns(Service service, DateTime startDate, DateTime endDate)
        {
            var turns = new List<Turn>();
            var serviceDuration = TimeSpan.FromMinutes(service.Duration);

            // Generar turnos para cada día en el rango de fechas
            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                // Calcular la hora de inicio del primer turno
                var startHour = service.OpeningHour;
                if (startHour < date.TimeOfDay)
                {
                    startHour = date.TimeOfDay;
                }

                // Generar turnos hasta la hora de cierre del servicio
                for (var endhour = startHour.Add(serviceDuration); endhour <= service.ClosingTime; endhour = endhour.Add(serviceDuration))
                {
                    turns.Add(new Turn
                    {
                        ServiceId = service.Id,
                        Date = date,
                        StartTime = startHour,
                        EndTime = endhour
                    });

                    startHour = endhour;
                }
            }

            return turns;
        }
    }
}

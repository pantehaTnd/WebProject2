using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalDoctors : ControllerBase
    {

        private readonly ILogger<HospitalDoctors> _logger;

        public HospitalDoctors(ILogger<HospitalDoctors> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public bool Get()
        {
            return true; 
        }
    }
}
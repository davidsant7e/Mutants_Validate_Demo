using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoLibre_MYSQL.Data.Repositories;
using Microsoft.AspNetCore.Http;



namespace MercadoLibre_Muntantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsRepository _StastsRepository;

        public StatsController(IStatsRepository vparStastsRepository)
        {
            _StastsRepository = vparStastsRepository;
        }

        /// <summary>
        /// Servicio de consulta de stats
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStats()
        {
            try
            {
                return Ok(await _StastsRepository.GetStats());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
        }
    }
}

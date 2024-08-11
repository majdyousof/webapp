using Microsoft.AspNetCore.Mvc;
using WebAppServer.Services;
using WebAppServer.Models;

namespace WebAppServer.Controllers
{
    /// <summary>
    /// Represents a controller for TFL API.
    /// </summary>
    public class TflApiController : ControllerBase
    {
        private readonly ITflService _tflService;
        private readonly ILogger<TflApiController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiController"/> class.
        /// </summary>
        /// <param name="tflService">The TFL service.</param>
        /// <param name="logger">The logger.</param>
        public TflApiController(ITflService tflService, ILogger<TflApiController> logger)
        {
            _tflService = tflService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the accident statistics.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the accident statistics.</returns>
        [HttpGet("GetAccidentData")]
        public async Task<ActionResult<List<AccidentStatsDetail>>> GetAccidentStats()
        {
            try
            {
                var accidentStats = await _tflService.GetAccidentData();
                return Ok(accidentStats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving accident data.");
                throw;
            }
        }

        /// <summary>
        /// Gets the bike point data.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the bike point data.</returns>
        [HttpGet("GetBikePoint")]
        public async Task<ActionResult<List<Place>>> GetBikePoint()
        {
            try
            {
                var bikePoint = await _tflService.GetBikePoint();
                return Ok(bikePoint);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving bike point data.");
                throw;
            }
        }
    }
}

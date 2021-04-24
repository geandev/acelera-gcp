using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using survey_server.Model;
using survey_server.Service;

namespace survey_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SurveyEntity model)
        {

            await _surveyService.Create(model);

            return Ok();
        }
    }
}

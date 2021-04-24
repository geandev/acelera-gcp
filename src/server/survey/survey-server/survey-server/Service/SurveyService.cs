using survey_server.Infra;
using survey_server.Model;
using System.Threading.Tasks;

namespace survey_server.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyContext _surveyContext;

        public SurveyService(SurveyContext surveyContext)
        {
            _surveyContext = surveyContext;
        }

        public async Task Create(SurveyEntity model)
        {
            await _surveyContext
                .Set<SurveyEntity>()
                .AddAsync(model);

            await _surveyContext.SaveChangesAsync();
        }
    }
}

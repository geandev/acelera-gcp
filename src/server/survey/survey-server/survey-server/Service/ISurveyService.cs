using survey_server.Model;
using System.Threading.Tasks;

namespace survey_server.Service
{
    public interface ISurveyService
    {
        Task Create(SurveyEntity model);
    }
}

namespace survey_server.Model
{
    public class SurveyEntity
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Estado { get; set; }
        public string AreaAtuacao { get; set; }
        public bool TrabalhouAzure { get; set; }
        public bool TrabalhouAws{ get; set; }
        public bool TrabalhouGoogleCloud { get; set; }
        public int NivelInteresseGoogleCloud { get; set; }
    }
}

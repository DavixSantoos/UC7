namespace apiAutenticacao.Models.DTO
{
    public class AlteracaoEmailDTO
    {
        public string EmailAtual { get; set; } = string.Empty;

        public string NovoEmail { get; set; } = string.Empty;

        public string ConfirmarNovoEmail { get; set; } = string.Empty;
    }
}

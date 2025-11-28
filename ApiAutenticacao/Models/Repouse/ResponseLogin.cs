namespace apiAutenticacao.Models.Repouse
{
    public class ResponseLogin
    {

        public bool Erro { get; set; }

        public string Mensage { get; set; } = string.Empty;

        public Usuario? Usuario { get; set; } = new Usuario();

    }
}

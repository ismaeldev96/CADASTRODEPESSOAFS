namespace CADASTRODEPESSOAFS.Classes
{
    public class Endereco
    {
        public string? logradouro { get; set; }
        public int numero { get; set; }
        public int cep { get; set; }
        public string? complemento { get; set; }
        public bool endComercial { get; set; }
    }
}
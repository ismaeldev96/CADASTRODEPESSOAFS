using CADASTRODEPESSOAFS.Interfaces;

namespace CADASTRODEPESSOAFS.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string? nome { get; set; }
        public float rendimento { get; set; }
        public Endereco? endereco { get; set; }

        public abstract float PagarImposto(float rendimento);
    }
}
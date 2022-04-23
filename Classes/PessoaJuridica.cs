using System.Text.RegularExpressions;
using CADASTRODEPESSOAFS.Interfaces;

namespace CADASTRODEPESSOAFS.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? cnpj { get; set; }
        public string? razaoSocial { get; set; }

        public override float PagarImposto(float rendimento)
        {
            if(rendimento > 10000)
            {
                return (rendimento / 100) * 9;
            }
            else if (rendimento <= 10000 && rendimento > 6000)
            {
                return (rendimento / 100) * 7;
            }
            else if(rendimento <= 6000 && rendimento > 3000)
            {
                return (rendimento / 100) * 5;
            }
            else
            {
                return (rendimento / 100) * 3;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)")){
                if (cnpj.Length == 18)
                {
                    if (cnpj.Substring(11, 4) == "0001")
                    {
                        return true;
                    }

                } else if (cnpj.Length == 14)
                {
                    if (cnpj.Substring(8, 4) == "0001")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
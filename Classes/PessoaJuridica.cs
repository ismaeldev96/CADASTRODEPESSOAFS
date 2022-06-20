using System.Text.RegularExpressions;
using CADASTRODEPESSOAFS.Interfaces;

namespace CADASTRODEPESSOAFS.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? cnpj { get; set; }
        public string? razaoSocial { get; set; }
        public string caminho { get; private set;} = "Database/PessoaJuridica.csv";

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
        public void inserir(PessoaJuridica pj){
            VerificarPastaArquivo(caminho);
            string[] pjItem = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial},{pj.endereco.logradouro},{pj.endereco.numero},{pj.endereco.cep},{pj.endereco.endComercial},{pj.rendimento}"};
            File.AppendAllLines(caminho, pjItem);
        }

        public List<PessoaJuridica> LerArquivo(){

            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach(string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPj = new PessoaJuridica();
                Endereco endPj = new Endereco();

                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];
                endPj.logradouro = atributos[3];
                endPj.numero = int.Parse(atributos[4]);
                endPj.cep = int.Parse(atributos[5]);
                endPj.endComercial = bool.Parse(atributos[6]);
                cadaPj.rendimento = float.Parse(atributos[7]);
                
                cadaPj.endereco = endPj;

                listaPj.Add(cadaPj);
            }
            return listaPj;
        }
    }
}
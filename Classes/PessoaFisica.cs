using System.Text.RegularExpressions;
using CADASTRODEPESSOAFS.Interfaces;

namespace CADASTRODEPESSOAFS.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf {get; set;}
        public string? dataNasc {get; set;}

        public override float PagarImposto(float rendimento)
        {
            if(rendimento > 6000)
            {
                return (rendimento / 100) * 5;
            }
            else if (rendimento <= 6000 && rendimento > 3500)
            {
                return (rendimento / 100) * 3.5f;
            }
            else if(rendimento <= 3500 && rendimento > 1500)
            {
                return (rendimento / 100) * 2;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Para validar a dataNasc, e necessario passar o metodo DateTime no formato ano, mes, dia.
        /// </summary>
        /// <param name="dataNasc"></param>
        /// <returns></returns>
        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if(anos >= 18){
                return true;
            }

            return false;
        }

        public bool ValidarDataNascimento(string dataNasc){

            DateTime dataConvertida;

            if(DateTime.TryParse(dataNasc, out dataConvertida)){
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays / 365;
                
                if(anos >= 18){
                    return true;
                }
            }
            return false;
        }

        public bool ValidarCpf(string cpf)
        {
            if (Regex.IsMatch(cpf, @"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)")){
                if (cpf.Length == 14)
                {
                    return true;

                } else if (cpf.Length == 11)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
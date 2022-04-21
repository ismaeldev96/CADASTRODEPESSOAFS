using System.Text.RegularExpressions;
using CADASTRODEPESSOAFS.Interfaces;

namespace CADASTRODEPESSOAFS.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf {get; set;}
        public DateTime dataNasc {get; set;}

        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
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
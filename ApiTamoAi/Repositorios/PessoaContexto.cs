using ApiTamoAi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ApiTamoAi.Repositorios
{
    public class PessoaContexto
    {
        private static readonly List<PessoaFisica> _pessoasF = new List<PessoaFisica>
        {
            new PessoaFisica(1,"Pessoa Fisica 1","123.123.123-11"),
            new PessoaFisica(2,"Pessoa Fisica 2","321.546.321-22"),
            new PessoaFisica(3,"Pessoa Fisica 3", GerarCpf())
        };

        private static readonly List<PessoaJuridica> _pessoasJ = new List<PessoaJuridica>
        {
            new PessoaJuridica(1,"Pessoa Juridica 1","12.321.321/0001-01"),
            new PessoaJuridica(2,"Pessoa Juridica 2","54.555.127/0002-02")
        };

        public static bool AddPessoaFisica(PessoaFisica pessoa)
        {
            var codigo = 0;
            if (_pessoasF != null && _pessoasF.Any())
                codigo = _pessoasF.LastOrDefault().Id;

            pessoa.Id = ++codigo;

            if (CpfValido(pessoa.Cpf))
            {
                _pessoasF.Add(pessoa);
                return true;
            }
            else
                return false;
        }

        public static bool AddPessoaJuridica(PessoaJuridica pessoa)
        {
            var codigo = 0;
            if (_pessoasJ != null && _pessoasJ.Any())
                codigo = _pessoasJ.LastOrDefault().Id;

            pessoa.Id = ++codigo;

            if (CnpjValido(pessoa.Cnpj))
            {
                _pessoasJ.Add(pessoa);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        public static List<PessoaFisica> ConsultarPessoasFisica()
        {
            return _pessoasF;
        }

        public static List<PessoaJuridica> ConsultarPessoasJuridica()
        {
            return _pessoasJ;
        }

        public static string GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;

            return semente;
        }

        public static bool CpfValido(string cpf)

            {

                if (cpf.Length == 0)

                    return false;

                if (contemLetras(cpf))

                    return false;
                
                switch (cpf)

                {

                    case "11111111111":

                        return false;

                    case "00000000000":

                        return false;

                    case "2222222222":

                        return false;

                    case "33333333333":

                        return false;

                    case "44444444444":

                        return false;

                    case "55555555555":

                        return false;

                    case "66666666666":

                        return false;

                    case "77777777777":

                        return false;

                    case "88888888888":

                        return false;

                    case "99999999999":

                        return false;

                }

                // Calcula Validade do CPF

                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                string tempCpf;

                string digito;

                int soma;

                int resto;

                if (cpf.Length != 11)

                    return false;

                tempCpf = cpf.Substring(0, 9);

                soma = 0;

                for (int i = 0; i < 9; i++)

                    soma +=

                    int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)

                    resto = 0;

                else

                    resto = 11 - resto;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;

                for (int i = 0; i < 10; i++)

                    soma +=

                    int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)

                    resto = 0;

                else

                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);

        }

        public static bool contemLetras(string letras)

        {

            if (letras.Where(c => char.IsLetter(c)).Count() > 0)

                return true;

            else

                return false;

        }

        public static bool CnpjValido(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            if (contemLetras(cnpj))
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }

}

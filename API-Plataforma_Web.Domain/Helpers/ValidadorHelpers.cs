using API_Plataforma_Web.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Plataforma_Web.Domain.Helpers
{
    public static class ValidadorHelpers
    {
        public static List<string> Validar(this int codigo, string descricao, long[] valoresValidos, bool permiteZero = false)
        {
            return Validar((long)codigo, descricao, valoresValidos, permiteZero);
        }

        public static List<string> Validar(this decimal codigo, string descricao, long[] valoresValidos, bool permiteZero = false)
        {
            return Validar((long)codigo, descricao, valoresValidos, permiteZero);
        }

        public static List<string> Validar(this long codigo, string descricao, long[] valoresValidos, bool permiteZero = false)
        {
            List<string> retorno = new();
            if (codigo <= 0 && valoresValidos == null && !permiteZero)
            {
                retorno.Add($"Favor informar o {descricao}, precisa ser maior que zero");
            }

            if (valoresValidos != null && !valoresValidos.Contains(codigo))
            {
                retorno.Add($"Favor informar um valor válido para {descricao}, precisa ser um destes valores {string.Join(',', valoresValidos)}.");
            }

            return retorno;
        }

        public static List<string> Validar(this string codigo, string descricao)
        {
            List<string> retorno = new();
            if (string.IsNullOrEmpty(codigo?.Trim()))
            {
                retorno.Add($"Favor informar {descricao}, não pode ser vazio");
            }

            return retorno;
        }

        public static List<string> Validar(this DateTime data, string descricao)
        {
            List<string> retorno = new();
            if (data == DateTime.MinValue || data == DateTime.MaxValue)
            {
                retorno.Add($"Favor informar {descricao} válida");
            }

            return retorno;
        }

        public static List<string> ValidarPaginacao(this Paginacao paginacao)
        {
            List<string> retorno = new();

            if (paginacao == null)
            {
                retorno.Add("Favor informar dados de paginação");
            }
            else
            {
                if (paginacao.Limite <= 0)
                {
                    retorno.Add("Favor informar limite de linhas de paginação");
                }
                if (paginacao.Pagina <= 0)
                {
                    retorno.Add("Favor informar número da página de paginação");
                }
            }

            return retorno;
        }
    }
}

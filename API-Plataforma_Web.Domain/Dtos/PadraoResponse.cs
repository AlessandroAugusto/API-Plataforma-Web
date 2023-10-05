using API_Plataforma_Web.Domain.Enums;

namespace API_Plataforma_Web.Domain.Dtos
{
    public class PadraoResponse
    {
        /// <summary>
        /// Indica o código de retorno da solicitação
        /// Onde:
        ///     200 - Sucesso
        ///     204 - Não encontrado
        ///     500 - Erro
        /// </summary>
        public CodigoRetorno CodRetorno { get; set; }

        /// <summary>
        /// Lista de mensagens explicativa para o código ou resposta
        /// </summary>
        public List<string> Mensagem { get; set; } = new List<string>();
    }
}
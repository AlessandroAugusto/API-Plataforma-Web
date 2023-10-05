using API_Plataforma_Web.Domain.Dtos;

namespace API_Plataforma_Web.Domain.Interfaces.Services
{
    public interface ITarefaService
    {
        /// <summary>
        /// Gravar a tarefa enviado pela plataforma
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PadraoResponse> GravarDemandaAsync(TarefaRequest request);

        /// <summary>
        /// Lista de tarefas
        /// </summary>
        /// <returns></returns>
        Task<ListaTarefasResponse> ConsultaDemandaAsync();
    }
}

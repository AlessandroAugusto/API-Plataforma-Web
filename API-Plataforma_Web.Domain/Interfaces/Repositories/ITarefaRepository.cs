using API_Plataforma_Web.Domain.Dtos;

namespace API_Plataforma_Web.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        /// <summary>
        /// Lista as tarefas
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TarefaResponse>> BuscarTarefasAsync();

        /// <summary>
        /// Inclui a tarefa digitada na plataforma
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<object> IncluirDemandaAsync(TarefaRequest request);
    }
}

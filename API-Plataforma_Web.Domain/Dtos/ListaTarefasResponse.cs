using API_Plataforma_Web.Domain.Enums;

namespace API_Plataforma_Web.Domain.Dtos
{
    public class ListaTarefasResponse : PadraoResponse
    {
        public List<TarefaResponse>? ListaTarefas { get; set; }
        public int TotalLinhas { get; set; }
    }

    public class TarefaResponse
    {
        public string? Descricao { get; set; }
        public DateTime? Data { get; set; }
        public StatusTarefa? Status { get; set; }
    }
}

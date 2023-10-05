using API_Plataforma_Web.Domain.Helpers;

namespace API_Plataforma_Web.Domain.Dtos
{
    public class TarefaRequest
    {
        public string? Descricao { get; set; }
        public DateTime? Data { get; set; }
        public string? Status { get; set; }

        public List<string> ValidarCampos()
        {
            List<string> retorno = new();
            if(Descricao!= null)
            {
                retorno.AddRange(Descricao.Validar("Descricao da tarefa"));
            }
            if(Status != null)
            {
                retorno.AddRange(Status.Validar("Status da tarefa"));
            }
            return retorno;
        }
    }
}

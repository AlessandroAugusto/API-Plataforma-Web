using API_Plataforma_Web.Domain.Dtos;
using API_Plataforma_Web.Domain.Interfaces.Repositories;
using API_Plataforma_Web.Infra.Data.Contexts;
using System.Data;
using Dapper;

namespace API_Plataforma_Web.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TarefaRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public async Task<IEnumerable<TarefaResponse>> BuscarTarefasAsync()
        {
            using var conn = _databaseContext.GetConnection();

            var query = @"SELECT  DS_TAREFA, DT_STATUS, CD_STATUS
                          FROM    TB_TAREFA WITH (NOLOCK)";

            DynamicParameters param = new();
            var result = await conn.QueryAsync<TarefaResponse>(query, param);

            return result;

        }

        public async Task<object> IncluirDemandaAsync(TarefaRequest request)
        {
            var sql = @"INSERT INTO TB_TAREFA (
                            DS_TAREFA,
                            DT_STATUS,
                            CD_STATUS
                            )
                           values(
                            @ds_tarefa,
                            @dt_status,
                            @cd_status)";
            DynamicParameters param = new();
            param.Add("@ds_tarefa", request.Descricao, DbType.AnsiString, size: 50);
            param.Add("@dt_status", request.Data, DbType.DateTime);
            param.Add("@cd_status", request.Status, DbType.AnsiString, size: 20);

            using var conn = _databaseContext.GetConnection();
            var retorno = await conn.ExecuteAsync(sql);
            return retorno;
        }
    }
}
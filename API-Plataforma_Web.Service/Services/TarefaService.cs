using API_Plataforma_Web.Domain.Dtos;
using API_Plataforma_Web.Domain.Enums;
using API_Plataforma_Web.Domain.Interfaces.Repositories;
using API_Plataforma_Web.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace API_Plataforma_Web.Service.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ILogger<TarefaService> _logger;
        private readonly IMapper _mapper;
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(
            ILogger<TarefaService> logger,
            ITarefaRepository tarefaRepository)
        {
            _logger = logger;
            _tarefaRepository = tarefaRepository;
        }
        public async Task<PadraoResponse> GravarDemandaAsync(TarefaRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Descricao))
            {
                throw new ArgumentException(nameof(request.Descricao));
            }

            PadraoResponse response = new()
            {
                CodRetorno = CodigoRetorno.Erro,
                Mensagem = request.ValidarCampos()
            };

            if (response.Mensagem.Any())
            {
                return response;
            }

            var retorno = await _tarefaRepository.IncluirDemandaAsync(request);
            if (retorno == null)
            {
                response.Mensagem.Add("Erro ao gravar os dados da Tarefa");
            }
            else
            {
                response.CodRetorno = CodigoRetorno.Sucesso;
            }

            return response;
        }

        public async Task<ListaTarefasResponse> ConsultaDemandaAsync()
        {
            ListaTarefasResponse response = new()
            {
                CodRetorno = CodigoRetorno.Erro,
                ListaTarefas = new List<TarefaResponse>()
            };

            if (response.Mensagem.Any())
            {
                return response;
            }
            else
            {
                response.CodRetorno = CodigoRetorno.Sucesso;
            }
            var listaTarefas = await _tarefaRepository.BuscarTarefasAsync();
            if (listaTarefas != null && listaTarefas.Any())
            {
                response.ListaTarefas.AddRange(_mapper.Map<List<TarefaResponse>>(listaTarefas));

                response.TotalLinhas = listaTarefas.Count();
            }
            return response;

        }
    }
}
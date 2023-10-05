using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Plataforma_Web.Domain.Enums
{
    public enum StatusTarefa
    {
        [Description("Concluído")]
        Concluido = 1,
        [Description("Em andamento")]
        andamento = 2,
        [Description("Encerrado")]
        encerrado = 3,
        [Description("Cancelado")]
        cancelado = 4,
    }
}

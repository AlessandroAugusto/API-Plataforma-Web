using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Plataforma_Web.Domain.Dtos
{
    public class Paginacao
    {
        public int Limite { get; set; }
        public int Pagina { get; set; }

        public int OffSet() => Limite * (Pagina - 1);
    }
}

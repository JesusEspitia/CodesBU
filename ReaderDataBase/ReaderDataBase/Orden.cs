using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderDataBase
{
    public class Orden
    {
        public int id { get; set; }
        public int id_catalogo { get; set; }
        public int cantidad { get; set; }

        public List<Orden> lstOrden = new List<Orden>();
    }
}

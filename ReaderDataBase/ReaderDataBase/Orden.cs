using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderDataBase
{
    public class Orden
    {
        public string references { get; set; }
        public string batch { get; set; }
        public int qty { get; set; }
        public DateTime date { get; set; }

        public List<Orden> lstOrden = new List<Orden>();
    }
}

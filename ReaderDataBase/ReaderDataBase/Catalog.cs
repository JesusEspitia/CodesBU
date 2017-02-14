using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderDataBase
{
    public class Catalog
    {
        public string NoCatalog { get; set; }
        public string NameCatalog { get; set; }

        public List<Catalog> lstCatalog = new List<Catalog>();
    }
}

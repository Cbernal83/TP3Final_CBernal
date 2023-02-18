using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class favoritos
    {
        public int Id { get; set; }
        public users IdUser { get; set; }
        public articulos IdArticulo { get; set; }
    }

}

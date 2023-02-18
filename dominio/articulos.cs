﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class articulos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }

        public int Orden { get; set; }

        public categorias Categoria { get; set; }
        public marcas Marca { get; set; }
    }
}
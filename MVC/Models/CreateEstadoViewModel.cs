using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CreateEstadoViewModel
    {
        public EstadoViewModel Estado { get; set; }
        public List<PaisViewModel> Paises { get; set; }
    }
}
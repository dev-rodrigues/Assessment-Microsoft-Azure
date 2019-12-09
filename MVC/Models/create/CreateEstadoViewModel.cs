using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class CreateEstadoViewModel
    {
        public EstadoViewModel Estado { get; set; }
        public ICollection<PaisViewModel> Paises { get; set; }
    }
}
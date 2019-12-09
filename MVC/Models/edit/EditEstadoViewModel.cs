using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.edit
{
    public class EditEstadoViewModel
    {
        public EstadoViewModel Estado { get; set; }
        public ICollection<PaisViewModel> Paises { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PaisViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public List<EstadoViewModel> Estados{ get; set; }
        public string FotoUrl { get; set; }
    }
}
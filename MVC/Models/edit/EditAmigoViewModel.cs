using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.edit
{
    public class EditAmigoViewModel
    {
        public FriendViewModel Amigo { get; set; }
        public ICollection<EstadoViewModel> Estados { get; set; }
        public ICollection<PaisViewModel> Paises { get; set; }
    }
}
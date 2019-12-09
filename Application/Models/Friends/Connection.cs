using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Friends {
    public class Connection {
        public int Id { get; set; }
        public virtual Friend Seguidor { get; set; }
        public virtual Friend Seguido { get; set; }
    }
}

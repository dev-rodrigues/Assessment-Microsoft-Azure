using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public interface ICountry {
        int Id { get; set; }
        string Name { get; set; }
        string URLImage { get; set; }
    }
}

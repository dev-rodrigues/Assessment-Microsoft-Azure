using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public interface ICountry {
        Object Salvar(Object objeto);
        Object Editar(Object objeto);
        void Excluir(int id);
        Object BuscarPorId(int id);
        List<Object> ListarPorId(int id);
    }
}

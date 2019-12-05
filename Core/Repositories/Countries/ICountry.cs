using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Countries {
    public interface ICountry {
        Task<Country> BuscarPorId(int id);
        Task<Country> Salvar(Country country);
        Task Deletar(int id);
        Task<Country> Editar(Country old);
        Task<List<Country>> Listar();
    }
}

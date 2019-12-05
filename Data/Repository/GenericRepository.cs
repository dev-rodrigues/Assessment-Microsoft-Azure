using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository {
    public class GenericRepository<T> where T : class {

        public T Salvar(T objeto) {
            throw new NotImplementedException();
        }

        public T Editar(T objeto) {
            throw new NotImplementedException();
        }

        public void Excluir(int id) {
            throw new NotImplementedException();
        }

        public T BuscarPorId(int id) {
            throw new NotImplementedException();
        }

        public List<T> ListarPorId(int id) {
            throw new NotImplementedException();
        }
    }
}
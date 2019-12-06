using Core.Models;
using Core.Models.State;
using Core.Repositories.Countries;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.States {
    public class StateRepository : RepositoryBase<State>, IStateRepository {
        public IQueryable<State> Index() {
            var lista = from p in base.FindAll() select p;
            return lista;
        }

        public State Show(State model, int id) {
            return base.Find(id);
        }

        public State Store(State model) {
            return base.Save(model);
        }

        public State Update(State model) {
            return base.Edit(model);
        }
    }
}

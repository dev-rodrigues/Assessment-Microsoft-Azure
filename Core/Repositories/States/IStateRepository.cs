using Core.Models;
using Core.Models.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.States {
    public interface IStateRepository {
        IQueryable<State> Index();
        State Show(int id);
        State Store(State model);
        State Update(State model);
    }
}

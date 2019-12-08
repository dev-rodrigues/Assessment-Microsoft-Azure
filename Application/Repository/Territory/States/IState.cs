using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Territory.States {
    public interface IState {
        Task<State> Save(State state);
        Task<State> Find(int id);
    }
}

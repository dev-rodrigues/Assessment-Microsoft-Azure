using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Territory.States;
using db = Application.Database.Database;

namespace Application.Repository.Territory.States {
    public class StateRepository : IState {
        public async Task<State> Find(int id) {
            try {
                return await db.GetInstance.States.FindAsync(id);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<State> Save(State state) {
            try {
                db.GetInstance.States.Add(state);
                await db.GetInstance.SaveChangesAsync();
                return state;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

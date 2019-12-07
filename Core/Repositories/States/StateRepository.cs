using Core.Models;
using Core.Models.States;
using Core.Repositories.Countries;
using Data.Context;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.States {
    public class StateRepository : RepositoryBase<State>, IStateRepository {

        private static string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Data.Context.DatabaseContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public CountryRepository CountryRepository;


        public StateRepository() {
            CountryRepository = new CountryRepository();
        }


        public IQueryable<State> Index() {
            var lista = from p in base.FindAll() select p;
            return lista;
        }

        public List<State> Listar() {
            return base.FindAll().ToList<State>();
        }

        public State BuscarPorId(int id) {
            return base.Find(id);
        }

        public State Show(int id) {

            using(SqlConnection conn = new SqlConnection(connection_string)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "State_Select";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_state", id);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read()) {
                    var state = new State() {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        URLImage = dr["URLImage"].ToString(),
                        Country = CountryRepository.Show(dr["Name"].ToString())
                    };
                    return state;
                }
            }
            return null;
        }

        public State Store(State model) {
            return base.Save(model);
        }

        public State Update(State model) {
            return base.Edit(model);
        }
    }
}

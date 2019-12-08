using System;
using System.Linq;
using db = Application.Database.Database;

namespace Application.NewRepository {
    class RepositoryGeneric<T> where T : class {

        //protected readonly DatabaseContext context = new DatabaseContext();

        public T Save(T model) {
            using(var conn = db.GetInstance) {
                try {
                    conn.Entry(model).State = System.Data.Entity.EntityState.Added;
                    conn.SaveChanges();
                    return model;
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public T Edit(T model) {
            using(var conn = db.GetInstance) {
                try {
                    conn.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    conn.SaveChanges();
                    return model;
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public bool Delete(T model) {
            using(var conn = db.GetInstance) {
                try {
                    conn.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    conn.SaveChanges();
                    return true;
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public T Find(object id) {
            using(var conn = db.GetInstance) {
                try {
                    return conn.Set<T>().Find(id);
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IQueryable<T> FindAll() {
            using(var conn = db.GetInstance) {
                try {

                    return conn.Set<T>();
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
    }
}
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Data.Repository {
    public class RepositoryBase<T> where T : class {

        protected readonly DatabaseContext context = new DatabaseContext();

        public T Save(T model) {
            using(var db = new DatabaseContext()) {
                try {
                    db.Entry(model).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return model;
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public T Edit(T model) {
            using(var db = new DatabaseContext()) {
                try {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return model;
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public bool Delete(T model) {
            using(var db = new DatabaseContext()) {
                try {
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public T Find(object id) {
            using(var db = new DatabaseContext()) {
                try {
                    return db.Set<T>().Find(id);
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IQueryable<T> FindAll() {
            using(var db = new DatabaseContext()) {
                try {
                    return context.Set<T>();
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
    }
}

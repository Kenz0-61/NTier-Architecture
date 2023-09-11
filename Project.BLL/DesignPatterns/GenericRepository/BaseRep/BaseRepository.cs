using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.Dll.Context;
using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext _db;

        public BaseRepository()
        {
            _db = DbTool.DbInstance;
        }

        void Save()
        {
            _db.SaveChanges();
        }


        public void Add(T item)
        {
            _db.Set<T>().Add(item);//entitiy framework "set" genric methodu ile "T" hangi entity ise ona göre abone ol set et kendini demiş oluyorz... Örneğin: _db.Set<T> = _db.Products
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }


        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = Entites.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
           return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return CustomWhere(x => x.Status != Entites.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetDeleteds()
        {
            return CustomWhere(x => x.Status == Entites.Enums.DataStatus.Deleted);
        }

        public List<T> GetModifeds()
        {
            return CustomWhere(x => x.Status == Entites.Enums.DataStatus.Updated);
        }

        public object ObjectSelect(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> CustomSelect<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public void Update(T item)
        {
            item.Status = Entites.Enums.DataStatus.Updated;
            item.ModifedDate = DateTime.Now;
            T unchangedEntity = Find(item.Id);
            _db.Entry(unchangedEntity).CurrentValues.SetValues(item); // Database git abonelik giriş gerçekleştir. Değişmemiş enttiy bul, onun mevcut değerlerini setvalues methodu ile verilen item paramatresi ile değiştir.
            Save();           
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list) 
            {
                Update(item);
            }
        }

        public List<T> CustomWhere(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        
    }
}

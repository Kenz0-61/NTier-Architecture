using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //List Commands

        List<T> GetAll();

        List<T> GetActives();

        List<T> GetModifeds();

        List<T> GetDeleteds();

        //Modify Commands

        void Add(T item);

        void AddRange(List<T> list);

        void Delete(T item);

        void DeleteRange(List<T> list);

        void Update(T item);

        void UpdateRange(List<T> list);

        void Destroy(T item);

        void DestroyRange(List<T> list);

        //Linq Commands
        // db.Products.Where(x=> x.ProductName.Contains("enes")).ToList;
        List<T> CustomWhere(Expression<Func<T,bool>> exp);

        bool Any(Expression<Func<T, bool>> exp);

        T FirstOrDefault(Expression<Func<T, bool>> exp);

        object Select(Expression<Func<T, object>> exp); //_db.Products.Select(x=> new{}) Anonymus object döndürmek için ideal yapıdır.

        IQueryable<X> Select<X>(Expression<Func<T, X>> exp); //_db.Products.Select(x=> new ProductDTO{})

        //Find Command

        T Find(int id);

    }
}

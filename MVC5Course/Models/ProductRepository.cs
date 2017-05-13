using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(x => x.ProductId == id);
        }
        public IQueryable<Product> Get���W�[�ӫ~��ID�ƧǥB���Q��(bool Active = true)
        {
            return this.All().OrderByDescending(x => x.ProductId).Where(x => x.Active.HasValue && x.Active == Active).Take(10);
        }

        public IQueryable<Product> ���o�Ҧ��W�[�ӫ~�è�ID�ϱƧ�(bool Active,bool showAll=false)
        {
            IQueryable<Product> all = this.All();
            if (showAll)
            {
                all = base.All();
            }
            return all
                .Where(p => p.Active.HasValue && p.Active.Value == Active)
                .OrderByDescending(p => p.ProductId).Take(10);
        }

        public void Update(Product product)
        {
            //db.Entry(product).State = EntityState.Modified;
            this.UnitOfWork.Context.Entry(product).State = EntityState.Modified;
        }
        //public void Delete(Product product)
        //{
        //    this.re
        //}
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}
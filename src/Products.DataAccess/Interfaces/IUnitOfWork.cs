using Products.DataAccess.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IProduct Product { get; }
        public int SaveChanges();
    }
}

using Products.Domain.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Interfaces
{
    public interface IPagination
    {
        public void Paginate(long itemsCount, PaginationParams @params);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DataAccess.Interfaces.Common
{
    public interface ISearch<TEntity>
    {
        public Task<(long IteamCount, List<TEntity>)> SearchingAsync(string search);
    }
}

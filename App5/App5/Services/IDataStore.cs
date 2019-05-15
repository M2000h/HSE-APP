using System.Collections.Generic;
using System.Threading.Tasks;

namespace App5.Services
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}

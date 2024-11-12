using WebAPIEFCoreCodeFir.Models;

namespace WebAPIEFCoreCodeFir.Repositories
{
    public interface IReceptionItem
    {
        Task<IEnumerable<Items>> GetItems();
        Task<Items> GetItem(int itemId);
        Task<Items> AddItem(Items item);
        Task<Items> UpdateItem(Items item);
        Task<bool> DeleteItem(int itemId);
    }
}

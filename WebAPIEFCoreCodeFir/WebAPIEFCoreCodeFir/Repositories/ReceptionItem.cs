using WebAPIEFCoreCodeFir.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIEFCoreCodeFir.Repositories
{
    public class ReceptionItem : IReceptionItem
    {
        private readonly ItemDbContext _context;

        public ReceptionItem(ItemDbContext context)
        {
                _context = context;
        }

        public async Task<Items> AddItem(Items item)
        {
            var result=await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteItem(int itemId)
        {
            var result= await _context.Items.FirstOrDefaultAsync(i => i.ItemId == itemId);

            if(result!=null)
            {
                _context.Items.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Items> GetItem(int itemId)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.ItemId == itemId);   
        }

        public async Task<IEnumerable<Items>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Items> UpdateItem(Items item)
        {
            var result = await _context.Items.FirstOrDefaultAsync(i => i.ItemId==item.ItemId);

            if(result!=null)
            {
                result.ItemName = item.ItemName;
                result.ItemDescription = item.ItemDescription;
                result.ItemQuantity = item.ItemQuantity;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

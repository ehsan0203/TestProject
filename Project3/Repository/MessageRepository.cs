using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Model;

namespace Project3.Repository
{
    public class MessageRepository
    {
        private readonly ApplicationdbContext _context;

        public MessageRepository(ApplicationdbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAll()
        {
          
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> Create(Message message)
        {
            if(message == null)
            {
                return null;
            }
           await _context.Messages.AddAsync(message);
           await _context.SaveChangesAsync();
            return message;
        }

        public async Task<Message> Delete(int id)
        {
            var result =await _context.Messages.FirstOrDefaultAsync(x=>x.Id==id);
            if (result!=null)
            {
                _context.Messages.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

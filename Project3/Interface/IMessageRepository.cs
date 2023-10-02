using Project3.Model;

namespace Project3.Interface
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllAsync();
        Task<Message> CreatAsync(Message message);

        Task<Message> DeleteAsync(int id);
    }
}

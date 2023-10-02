using Project3.Data;
using Project3.Interface;
using Project3.Model;
using Project3.Repository;

namespace Project3.Services
{
    public class MessageServices:IMessageRepository
    {
        private readonly MessageRepository _repository;

        public MessageServices(ApplicationdbContext repository)
        {
            _repository =new MessageRepository( repository);
        }

        public Task<Message> CreatAsync(Message message)
        {
            return _repository.Create(message);
        }

        public Task<Message> DeleteAsync(int id)
        {
            return _repository.Delete(id);
        }

        public Task<List<Message>> GetAllAsync()
        {
            return _repository.GetAll();
        }
    }
}

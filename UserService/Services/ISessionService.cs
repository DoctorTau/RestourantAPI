using UserService.Models;

namespace UserService.Services{
    public interface ISessionService{
        Task<Session> CreateSession(User user);
    }
}
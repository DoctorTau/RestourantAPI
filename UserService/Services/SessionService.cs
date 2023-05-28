using UserService.Database;
using UserService.Models;

namespace UserService.Services{
    public class SessionService : ISessionService{
        private readonly AppDbContext _dbContext;
        private readonly JWTCreator _jwtCreator;

        public SessionService(AppDbContext dbContext, JWTCreator jwtCreator){
            _dbContext = dbContext;
            _jwtCreator = jwtCreator;
        }

        public async Task<Session> CreateSession(User user)
        {
            // Create a jwt
            string jwt = _jwtCreator.CreateToken(user);

            Session session = new Session
            {
                UserId = user.Id,
                SessionToken = jwt,
                ExpiresAt = DateTime.Now.AddDays(7)
            }; 

            await _dbContext.Sessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();

            return session;
        }
    }
}
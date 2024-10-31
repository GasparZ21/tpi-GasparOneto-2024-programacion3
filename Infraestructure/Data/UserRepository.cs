using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context):base(context) 
        { 
        
            _context = context;
        
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(User user) 
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
        public User Delete(User user) 
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u=> u.Id == id);
        }

    }
}

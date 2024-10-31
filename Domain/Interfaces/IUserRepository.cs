using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Delete(int id);

    }
}

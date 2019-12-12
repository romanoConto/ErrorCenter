using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codenation.ErrorCenter.Models;
using Codenation.ErrorCenter.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.ErrorCenter.Services
{
    public class UserService : IUserService
    {
        private ErrorCenterContext context;

        public UserService(ErrorCenterContext context)
        {
            this.context = context;
        }

        public bool DeleteUserById(int id)
        {
            User user = context.Users.Find(id);
            if (user == null)
                return false;
            var state = EntityState.Deleted;
            context.Entry(user).State = state;
            context.SaveChanges();
            return true;
        }

        public IList<User> FindAll()
        {
            return context.Users.Select(x => x).ToList();
        }

        public User FindById(int id)
        {
            return context.Users.Find(id);
        }

        public User FindByUser(User user)
        {
            return context.Users.Find(user);
        }

        public User Save(User user)
        {
            var state = user.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(user).State = state;
            context.SaveChanges();
            return user;
        }
    }
}

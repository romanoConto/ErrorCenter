using Codenation.ErrorCenter.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.ErrorCenter.Services
{
    public interface IUserService
    {
        IList<User> FindAll();

        User FindById(int id);

        User FindByUser(User user);

        User Save(User user);

        Boolean DeleteUserById(int id);
    }
}

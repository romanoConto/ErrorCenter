using Codenation.ErrorCenter.Models.DTOs;
using Codenation.ErrorCenter.Models.Models;
using System;
using System.Collections.Generic;

namespace Codenation.ErrorCenter.Services
{
    public interface ILogService
    {
        IList<Log> FindAllLogs();

        IList<Log> FindByFilter(ErrorFilterDTO filter);

        Log FindById(int id);

        Log Save(Log log);

        Boolean Delete(int id);
    }
}

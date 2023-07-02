using PathDev.Core.Model.Interface.Service.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathDev.Core.Model.Dto.Log;

namespace PathDev.Core.Model.Interface.Service.Log
{
    public interface ILogDBService : IDBService<PathDevLogDto, string>
    {
    }
}

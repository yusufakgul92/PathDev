using PathDev.Core.Model.Interface.Service.Log;
using PathDev.Infrastructure.DataAccess.Service.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PathDev.Core.Model.Dto.Log;
using PathDev.Core.Model.Base.Mongo;

namespace PathDev.Infrastructure.DataAccess.Service.Log
{
    public class LogDBService : DBService<PathDevLogDto>, ILogDBService
    {
        public LogDBService(IOptions<PathDevSettings> options) : base(options)
        {
        }
    }
}

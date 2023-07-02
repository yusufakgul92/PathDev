using PathDev.Core.Model.Base.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Dto.Log
{
    public class PathDevLogDto : BaseMongoModel
    {

        public string Platform { get; set; }

        public string ControllerName { get; set; }

        public string MethodName { get; set; }

        public string Title { get; set; }

    }
}

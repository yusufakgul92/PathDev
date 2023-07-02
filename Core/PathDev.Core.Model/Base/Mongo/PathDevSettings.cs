using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Base.Mongo
{

    public class PathDevSettings : IPathDevSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IPathDevSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

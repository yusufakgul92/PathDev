using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Interface.Service.RabbitMQ
{
    public interface IRabbitMQService
    {
        public void PublishToQueu();
        public void SendOrder<T>(T message);
    }
}

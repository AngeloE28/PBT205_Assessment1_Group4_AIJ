using System;
using System.Collections.Generic;
using System.Text;

namespace PBT205_Assessment1_Group4_AIJ
{
    // Every system uses these functions
    public interface IRabbitMQ
    {
        void StartConsume();
        void Send(String message);
    }
}

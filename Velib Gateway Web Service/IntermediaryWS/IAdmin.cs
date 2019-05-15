using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    [ServiceContract]
    interface IAdmin
    {
        [OperationContract]
        Stat GetStat();

        [OperationContract]
        void SetTimer(TimeSpan timer);
    }

 
}

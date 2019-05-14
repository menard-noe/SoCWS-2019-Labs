using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    class Admin : IAdmin
    {
        private Stat stat;
        Admin()
        {
            stat = new Stat();
            stat.writeFile();

        }
        public Stat GetStat()
        {
            stat.AddClientRequestIWS();
            return stat;
        }
        public void SetTimer(TimeSpan timer)
        {
            stat.AddAverageDelayIWS(timer);
        }
    }
}

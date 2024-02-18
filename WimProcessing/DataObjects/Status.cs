using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wim.DataObjects
{
    public class Status
    {
        public bool isConnected { get; set; }
        public bool isLost { get; set; }
        public bool isError { get; set; }
        public string chError { get; set; }
        public string dateTime { get; set; }
    }
}

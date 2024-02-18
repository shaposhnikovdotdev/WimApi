using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wim.DataObjects
{
    public class Completed
    {
        public string dynWeight { get; set; }
        public List<bool> isDualTire { get; set; }
        public string getWeightV { get; set; }
        public List<string> AxInfo { get; set; }
        public List<string> getWeightAx { get; set; }
        public int getAx { get; set; }
        public string getSpeed { get; set; }
        public List<string> getDistTire { get; set; }
        public string dateTime { get; set; }
    }
}

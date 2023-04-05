using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXOit.Core.Models
{
    public class ProducerDTO
    {
        public string Producer { get; set; }
        public int Interval => folowingWin - folowingWin;
        public int previousWin { get; set; }
        public int folowingWin { get; set; }
    }

    public class IntervalDTO
    {
        public ProducerDTO Min { get; set;}
        public ProducerDTO Max { get; set;}
    }
}

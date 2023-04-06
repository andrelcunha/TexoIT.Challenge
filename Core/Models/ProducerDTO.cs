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
        public int Interval { get; set; }
        public int PreviousWin { get; set; }
        public int FollowingWin { get; set; }
    }

    public class IntervalDTO
    {
        public List<ProducerDTO> Min { get; set;}
        public List<ProducerDTO> Max { get; set;}
    }
}

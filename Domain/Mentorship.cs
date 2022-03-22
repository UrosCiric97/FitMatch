using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Mentorship
    {
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int TrainerId { get; set; }
        public User Trainer { get; set; }
    }
}

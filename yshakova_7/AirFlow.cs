using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yshakova_7
{
    public class AirFlow
    {
        public int id { get; set; }
        public int air_flow { get; set; }
        public int losses { get; set; }
        public int pipe_lenght { get; set; }

        public AirFlow(int id, int air_flow, int losses, int pipe_lenght)
        {
            this.id = id;
            this.air_flow = air_flow;
            this.losses = losses;
            this.pipe_lenght = pipe_lenght;
        }

        public AirFlow()
        {

        }
    }
}


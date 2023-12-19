using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yshakova_7
{
    public class Volume
    {
        public int id { get; set; }
        public string name_air { get; set; }
        public int volume { get; set; }

        public Volume(int id, string name_air, int volume)
        {
            this.id = id;
            this.name_air = name_air;
            this.volume = volume;
        }

        public Volume()
        {

        }
    }
}

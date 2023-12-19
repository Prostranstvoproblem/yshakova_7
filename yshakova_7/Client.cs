using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yshakova_7
{
    public class Client
    {
        public int id { get; set; }
        public string fio { get; set; }
        public string phone { get; set; }
        public string passport { get; set; }
        public Client(int id, string fio, string phone, string passport)
        {
            this.id = id;
            this.fio = fio;
            this.phone = phone;
            this.passport = passport;
        }

        public Client()
        {

        }
    }
}

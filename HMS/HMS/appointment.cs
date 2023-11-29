using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class appointment
    {
        public appointment(string type, DateTime date_time,string doc,string patient)
        {
            this.type = type;
            this.date_time = date_time;
            this.doc = doc;
            this.patient = patient;
        }

        public string _Id { get; set; }
        public string doc { get; set; }
        public string patient { get; set; }
        public string type { get; set; }
        public DateTime date_time { get; set; }
    }
}

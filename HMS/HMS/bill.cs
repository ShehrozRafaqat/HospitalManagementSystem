using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    class bill
    {
        public bill(string appointment,string amount)
        {
            this.appointment = appointment;
            this.amount = amount;
        }

        public string _Id { get; set; }
        public string appointment { get; set; }
        public string amount { get; set; }
    }
}

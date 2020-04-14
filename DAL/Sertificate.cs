using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Sertificate
    {
        public int Id { get; set; }
        public int SertificateNumber { get; set; }
        public Boolean Shown { get; set; }

        public Order Order { get; set; }
    }
}

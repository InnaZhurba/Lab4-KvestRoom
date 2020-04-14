using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order
    {
        [ForeignKey("Sertificate")]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int SertificateId { get; set; }
        public int NumberOfUsers { get; set; }

        public Sertificate Sertificate { get; set; }
        public Status Status { get; set; }
    }
}

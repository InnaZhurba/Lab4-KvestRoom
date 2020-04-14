using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Status
    {
        [ForeignKey("Order")]//OrdderId
        public int Id { get; set; }
        public int TimeCategoryId { get; set; }
        public int KvestRoomId { get; set; }
        public int OrderId { get; set; }

        public List<TimeCategory> TimeCategories { get; set; }
        public List<KvestRoom> KvestRooms { get; set; }
        public Order Order { get; set; }
    }
}

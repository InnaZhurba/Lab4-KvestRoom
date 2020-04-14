using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KvestRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersValueId { get; set; }
        public int AgeCategory { get; set; }
        public int PriceForOneUser { get; set; }

        public Status Status { get; set; }
        public List<AgeCategory> AgeCategories { get; set; }
        public List<UsersValue> UsersValues { get; set; }
    }
}

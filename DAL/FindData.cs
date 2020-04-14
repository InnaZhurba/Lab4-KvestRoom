using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FindData
    {
        
        public bool FindSertificateID(int sertNum)
        {
            BDContext db = new BDContext();
            using (db)
            {
               var val = db.Sertificates.Where(b => b.Id == sertNum)
                    .Select(b => b.Id).ToList();
                if (val.Contains(sertNum))
                    return true;
                else
                    return false;
            }
        }
        public int FindLastIdOrder()
        {
            BDContext db = new BDContext();
            List<Order> orders = db.Orders.ToList();
            int id = 0;
            foreach (Order order in orders)
                id = order.Id;
            return id;
        }
        public int FindLastIdStatus()
        {
            BDContext db = new BDContext();
            List<Status> statuses = db.Statuses.ToList();
            int id = 0;
            foreach (Status status in statuses)
                id = status.Id;
            return id;
        }
        public int FindLastIdKvestRoom()
        {
            BDContext db = new BDContext();
            List<KvestRoom> kvests = db.KvestRooms.ToList();
            int id = 0;
            foreach (KvestRoom kvest in kvests)
                id = kvest.Id;
            return id;
        }
        public int[] FindUsersVal(int ID)
        {
            BDContext db = new BDContext();
            int[] mm = new int[2];
            using (db)
            {
                var val = db.UsersValues.Find(ID);
                mm[0] = val.min;
                mm[1] = val.max;
            }
                return mm;
        }
        public int[] FindAge(int ID)
        {
            BDContext db = new BDContext();
            int[] mm = new int[2];
            using (db)
            {
                var val = db.AgeCategories.Find(ID);
                mm[0] = val.min;
                mm[1] = val.max;
            }
            return mm;
        }
        public string[] FindKvestNames(int usersID, int ageID, int price)
        {
            string[] names;
            BDContext db = new BDContext();
            using (db)
            {
                var val = db.KvestRooms
                   .Where(b => b.AgeCategory == ageID && b.UsersValueId == usersID && b.PriceForOneUser<=price)
                   .Select(b => b.Name).ToList();
                names = new string [val.Count];
                for(int i=0;i<val.Count;i++)
                {
                    names[i] = val.ElementAt(i);
                }
            }
            return names;
        }
    }
}

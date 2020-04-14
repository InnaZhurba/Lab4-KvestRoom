using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class ShowData
    {
        
        public int[,] ShowAllUsersValue()
        {
            BDContext db = new BDContext();
            int[,] usersVal = new int[3, 2];
            using (db)
            {
                UsersValue[] user = new UsersValue[5];
                user = db.UsersValues.ToArray();
                for (int i = 0; i < 3; i++)
                {
                    usersVal[i, 0] = user[i].min;
                    usersVal[i, 1] = user[i].max;
                }
            }
            return usersVal;
        }
        public int[,] ShowAllAgeCategories()
        {
            BDContext db = new BDContext();
            int[,] age = new int[3, 2];
            using (db)
            {
                AgeCategory[] Age = new AgeCategory[5];
                Age = db.AgeCategories.ToArray();
                for (int i = 0; i < 3; i++)
                {
                    age[i, 0] = Age[i].min;
                    age[i, 1] = Age[i].max;
                }
            }
            return age;
        }
        public string[,] ShowAllTimeCategories()
        {

            BDContext db = new BDContext();
            string[,] age = new string[15, 3];
            using (db)
            {
                TimeCategory[] Age = new TimeCategory[15];
                Age = db.TimeCategories.ToArray();
                for (int i = 0; i < age.GetLength(0); i++)
                {
                    age[i, 0] = Age[i].Day;
                    age[i, 1] = Convert.ToString(Age[i].Start);
                    age[i, 2] = Convert.ToString(Age[i].Finish);
                }
            }
            return age;
        }
        public string[,] ShowKvestRooms()
        {
            BDContext db = new BDContext();
            string[,] kvestRoom;
            using(db)
            {
                List<KvestRoom> kvest = new List<KvestRoom>();
                kvest = db.KvestRooms.ToList();
                kvestRoom = new string[kvest.Count(),4];
                for(int i=0;i<kvest.Count();i++)
                {
                    kvestRoom[i, 0] = kvest.ElementAt(i).Name;
                    kvestRoom[i, 1] = Convert.ToString(kvest.ElementAt(i).UsersValueId);
                    kvestRoom[i, 2] = Convert.ToString(kvest.ElementAt(i).AgeCategory);
                    kvestRoom[i, 3] = Convert.ToString(kvest.ElementAt(i).PriceForOneUser);
                }
            }
            return kvestRoom;
        }
    }
}

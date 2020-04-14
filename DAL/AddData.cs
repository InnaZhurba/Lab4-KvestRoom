using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddData
    {
        BDContext db = new BDContext();
        FindData find = new FindData();
        DeleteData delete = new DeleteData();
        public void AddAgeCategories(int Min, int Max)
        {
            using (db)
            {
                AgeCategory first = new AgeCategory();
                first.min = Min;
                first.max = Max;

                db.AgeCategories.Add(first);
                db.SaveChanges();
            }
        }
        public void AddUsersValues(int Min, int Max)
        {
            using (db)
            {
                UsersValue value = new UsersValue();
                value.min = Min;
                value.max = Max;

                db.UsersValues.Add(value);
                db.SaveChanges();
            }
        }
        public void AddTimeCategories(string day, int start, int finish)
        {
            using (db)
            {
                TimeCategory value = new TimeCategory();
                value.Day = day;
                value.Start = start;
                value.Finish = finish;

                db.TimeCategories.Add(value);
                db.SaveChanges();
            }
        }
        public void AddSertificate(int SertNum, Boolean shown)
        {
            using (db)
            {
                Sertificate value = new Sertificate();
                value.SertificateNumber = SertNum;
                value.Shown = shown;

                db.Sertificates.Add(value);
                db.SaveChanges();
            }
        }

        public int AddOrder(string userName, int IDSertifacate, int usersValue)
        {           
            using (db)
            {
                Order value = new Order();
                value.UserName = userName;
                //if (find.FindSertificateID(IDSertifacate))
                //{
                    value.SertificateId = IDSertifacate;
                    //delete.DeleteSertificate(IDSertifacate);
                //}
                //else
                //    value.SertificateId = 51;//value 1 means that this point is not used as a sertificate number
                value.NumberOfUsers = usersValue;

                db.Orders.Add(value);
                db.SaveChanges();
            }
            return find.FindLastIdOrder();
        }
        public void AddKvestRoom(string RoomName, int IDUsersValue, int IDAge, int OnePrice)
        {
            using (db)
            {
                KvestRoom value = new KvestRoom();
                value.Name = RoomName;
                value.UsersValueId = IDUsersValue;
                value.AgeCategory = IDAge;
                value.PriceForOneUser = OnePrice;

                db.KvestRooms.Add(value);
                db.SaveChanges();
            }
        }
        public void AddStatus(int IDOrder, int IDTime, int IDKvestRoom)
        {
            using (db)
            {
                Status value = new Status();
                value.TimeCategoryId = IDTime;
                value.OrderId = IDOrder;
                value.KvestRoomId = IDKvestRoom;

                db.Statuses.Add(value);
                db.SaveChanges();
            }
        }       
    }
}

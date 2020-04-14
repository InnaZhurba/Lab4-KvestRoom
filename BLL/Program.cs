using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Program
    {
        AddData addData = new AddData();
        ShowData show = new ShowData();
        CheckData check = new CheckData();
        FindData find = new FindData();
        public void AddTime()
        {
            addData.AddTimeCategories("Sunday", 8, 10);
            addData.AddTimeCategories("Sunday", 10, 12);
            addData.AddTimeCategories("Sunday", 12, 14);
            addData.AddTimeCategories("Monday", 8, 10);
            addData.AddTimeCategories("Monday", 10, 12);
            addData.AddTimeCategories("Monday", 12, 14);
            addData.AddTimeCategories("Tuesday", 8, 10);
            addData.AddTimeCategories("Tuesday", 10, 12);
            addData.AddTimeCategories("Tuesday", 12, 14);
            addData.AddTimeCategories("Wednesday", 8, 10);
            addData.AddTimeCategories("Wednesday", 10, 12);
            addData.AddTimeCategories("Wednesday", 12, 14);
            addData.AddTimeCategories("Thursday", 8, 10);
            addData.AddTimeCategories("Thursday", 10, 12);
            addData.AddTimeCategories("Thursday", 12, 14);
        }
        public void AddSertificate()
        {
            //for(int i=0;i<50;i++)
                addData.AddSertificate(1,false);
        }
        public bool AddKvestRoom(string Name, int IDUsersValue, int IDAge, int OnePrice)
        {
            addData.AddKvestRoom(Name, IDUsersValue, IDAge, OnePrice);
            return true;
        }
        public int[,] UsersValueShow()
        {            
            return show.ShowAllUsersValue();
        }
        public int[,] AgeCategoriesShow()
        {
            return show.ShowAllAgeCategories();
        }
        public bool CheckAdmin(string login, int password)
        {
            return check.CheckAdmin(login, password);
        }
        public string[,] ShowAllKvestRooms()
        {
            string[,] funkdata = show.ShowKvestRooms();
            string[,] data = new string[funkdata.GetLength(0),6];
            for(int i=0;i< funkdata.GetLength(0); i++)
            {
                data[i, 0] = funkdata[i, 0];
                data[i, 1] = Convert.ToString(find.FindUsersVal(Convert.ToInt32(funkdata[i,1]))[0]);
                data[i, 2] = Convert.ToString(find.FindUsersVal(Convert.ToInt32(funkdata[i, 1]))[1]);
                data[i, 3] = Convert.ToString(find.FindAge(Convert.ToInt32(funkdata[i, 2]))[0]);
                data[i, 4] = Convert.ToString(find.FindAge(Convert.ToInt32(funkdata[i, 2]))[1]);
                data[i, 5] = funkdata[i, 3];
            }
            return data;
        }
        public string[]  FindKvestNames(int usersID, int ageID, int price)
        {
            return find.FindKvestNames( usersID, ageID, price);
        }
        public string[,] TimeCategoriesShow()
        {
            return show.ShowAllTimeCategories();
        }
        public bool SaveStatusAndOrder(string name, int IDTime, int price, int SertNum, int IDKvest)
        {           
            int orderID = addData.AddOrder(name, SertNum, price);
            addData.AddStatus(orderID, IDTime, IDKvest);
            return true;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.AddSertificate();
            // p.AddTime();
            //p.AddKvestRoom();

            Console.Read();
        }
    }
}

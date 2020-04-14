using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CheckData
    {
        
        public bool CheckAdmin(string login, int password)
        {
            BDContext db = new BDContext();
            using (db)
            {
                var val = db.Administrators
                    .Where(b => b.Login == login)
                    .Select(b=>b.Password).ToList();
                if (val.Contains(password))
                    return true;
                else
                    return false;
            }
        }
    }
}

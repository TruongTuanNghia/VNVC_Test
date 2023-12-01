using Connect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        static ConnectSQL connectSQL = new ConnectSQL();
        static void Main(string[] args)
        {
            CreateResultSlot();
            UserResultSlot();
        }
        public static void  CreateResultSlot()
        {
            Random rand = new Random();
            int res = rand.Next(0, 9);
            var listParameter = new List<SqlParameter>
                {
                    new SqlParameter("@Date", DateTime.Now),
                    new SqlParameter("@Slot", DateTime.Now.Hour),
                    new SqlParameter("@Res", res),
                   
                };
            var result = connectSQL.ExecDataSetSP("CreateResultSlot", listParameter);
        }

        public static void UserResultSlot()
        {
            var date = DateTime.Now;
          
            if(DateTime.Now.Hour.ToString().Equals("00"))
            {
                date = DateTime.Now.AddDays(-1);                
            }    
            var listParameter = new List<SqlParameter>
                {
                    new SqlParameter("@Date", date),
                    new SqlParameter("@Slot", DateTime.Now.AddHours(-1).Hour),                   

                };            
            var result = connectSQL.ExecDataSetSP("UserResultSlot", listParameter);
        }
    }
}

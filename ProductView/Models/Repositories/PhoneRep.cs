using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Products_ASP.Models
{
    public class PhoneRep
    {
        static string connectionString = "Data Source=SQL5080.site4now.net;Initial Catalog=db_a7920a_mkonjibhu;User Id=db_a7920a_mkonjibhu_admin;Password=QwertyuioP123";

        public static void Create(Phone value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "EXEC [AddPhone] @manufacturer,  @model, @price  ";
                        var values = new { manufacturer = value.manufacturer, model = value.model,price = value.price };
                        db.Query(sql, values, transaction);
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

      
        public static IEnumerable<Phone> Select()
        {
            List<Phone> coll = new List<Phone>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                try
                {
                    db.Open();
                    var sql = "EXEC [GetPhones]";
                    coll = db.Query<Phone>(sql).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return coll;
        }
    }
}

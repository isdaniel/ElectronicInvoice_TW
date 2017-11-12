using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using ElectronicInvoice.Models.DBModel;
using System.Configuration;

namespace ElectronicInvoice.Dao
{
    /// <summary>
    /// 目前存取資料庫 比較簡單，所以沒有在多做其他事情
    /// </summary>
    public class CrypStoreDao
    {
        private string connstr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<CrypStoreModel> GetCrypStore()
        {
            string sqlStr = @"SELECT ParamterType,ParamterContent FROM  Department.dbo.CrypStore";

            using (IDbConnection conn = new SqlConnection(connstr))
            {
                return conn.Query<CrypStoreModel>(sqlStr);
            }
        }
    }
}
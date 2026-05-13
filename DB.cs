using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLhocphi
{
    internal class DB
    {

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(@"Data Sourcesss=DESKTOP-HCEVKLJ\BASROT;Initial Catalog=QuanLyHP;Integrated Security=TrueUser ID=sa;
        Password=0846316066");
            }
       }
  }


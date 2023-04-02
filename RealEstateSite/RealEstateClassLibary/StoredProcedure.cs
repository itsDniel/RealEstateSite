using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RealEstateClassLibary
{
    class StoredProcedure
    {
        SqlCommand command = new SqlCommand();
        DBConnect connect = new DBConnect();

        public StoredProcedure() { command.CommandType = CommandType.StoredProcedure; }

    }
}

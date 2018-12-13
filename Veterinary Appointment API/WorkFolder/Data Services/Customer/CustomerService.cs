using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Veterinary_Appointment_API.Thirdparty.Database;
using Veterinary_Appointment_API.Thirdparty.Extensions;

namespace Veterinary_Appointment_API.WorkFolder.Data_Services.Customer
{
    public class CustomerService : DataManager, ICustomerService
    {
        public void Create(string data)
        {
            using (SQLiteCommand command = Connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE IF NOT EXISTS {Enum.GetName(typeof(DatabaseTables), 1)}(MsgType varchar(50), customerId varchar(50), customerName  varchar(50), customerIdentityNo varchar(50))";
                command.ExecuteNonQuery();

                command.CommandText = $"INSERT INTO {Enum.GetName(typeof(DatabaseTables), 1)}(MsgType, customerId, customerName,customerIdentityNo) VALUES('{data.GetCPMsgType()}','{data.GetCPCustId()}','{data.GetCPCustomerName()}','{data.GetCPCustIdentityNo()}');";
                command.ExecuteNonQuery();
            }
        }
    }
}
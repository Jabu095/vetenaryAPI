using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Veterinary_Appointment_API.Thirdparty.Database;
using Veterinary_Appointment_API.Thirdparty.Extensions;

namespace Veterinary_Appointment_API.WorkFolder.Data_Services.Pets
{
    public class PetService : DataManager, IPetService
    {
        public void Create(string data)
        {
            using (SQLiteCommand command = Connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE IF NOT EXISTS {Enum.GetName(typeof(DatabaseTables), 2)}(MsgType varchar(50), petId varchar(50), custId  varchar(50), petName varchar(50))";
                command.ExecuteNonQuery();

                command.CommandText = $"INSERT INTO {Enum.GetName(typeof(DatabaseTables), 2)}(MsgType, petId, custId,petName) VALUES('{data.GetPetMsgType()}','{data.GetPetPetId()}','{data.GetPetCustId()}','{data.GetPetPetName()}')";
                command.ExecuteNonQuery();
            }
        }
    }
}
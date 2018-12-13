using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Helper;
using Veterinary_Appointment_API.Thirdparty.Database;
using Veterinary_Appointment_API.Thirdparty.Extensions;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Appointments;

namespace Veterinary_Appointment_API.WorkFolder.Data_Services
{
    public class AppointmentService : DataManager, IAppontment
    {
        public bool Cancel(string Id)
        {
            string InsertSql = string.Empty;
            using (SQLiteCommand command = Connection.CreateCommand())
            {
              
                command.CommandText = $"SELECT * FROM {Enum.GetName(typeof(DatabaseTables), 0)} WHERE apptId='{Id}'";
                
                using (var data = command.ExecuteReaderAsync().Result)
                {
                   
                   
                    while (data.Read())
                    {
                        InsertSql = $"INSERT INTO {Enum.GetName(typeof(DatabaseTables), 3)} VALUES('{data["MsgType"]}','{data["apptId"]}')";
                    }

                }

            }

            using(SQLiteCommand command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {Enum.GetName(typeof(DatabaseTables), 0)} WHERE apptId='{Id}'";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE TABLE IF NOT EXISTS {Enum.GetName(typeof(DatabaseTables), 3)}(MsgType varchar(50), apptId varchar(50))";
                command.ExecuteNonQuery();

                command.CommandText = InsertSql;
                command.ExecuteNonQuery();
            }
            return true;
        }

        public void Create(string data)
        {
            using (SQLiteCommand command = Connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE IF NOT EXISTS {Enum.GetName(typeof(DatabaseTables),0)}(MsgType varchar(50), apptId varchar(50), custId varchar(50), petId  varchar(50), time varchar(50))";
                command.ExecuteNonQuery();

                command.CommandText = $"INSERT INTO {Enum.GetName(typeof(DatabaseTables), 0)}(MsgType, apptId, custId, petId,time) VALUES('{data.GetMsgType()}','{data.GetApptId()}','{data.GetCustId()}','{data.GetPetId()}','{data.GetTime()}')";
                command.ExecuteNonQuery();
            }
        }

        public ICollection<AppontmentResponseViewModel> GetAllAppointments()
        {
            var Appointments = new List<AppontmentResponseViewModel>();
            using (SQLiteCommand command = Connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {Enum.GetName(typeof(DatabaseTables),0)} INNER JOIN {Enum.GetName(typeof(DatabaseTables),1)} ON {Enum.GetName(typeof(DatabaseTables), 0)}.custId == {Enum.GetName(typeof(DatabaseTables), 1)}.customerId";
                using (var data = command.ExecuteReaderAsync().Result)
                {
                    while (data.Read())
                    {
                        Appointments.Add(new AppontmentResponseViewModel { CustomerName = $"{data["customerName"]}", Time = $"{data["time"]}", Id = $"{data["apptId"]}"});
                    }
                }
                
                
            }
            var sorted = Appointments.OrderBy(x => x.Time).ToList();
            return sorted;
        }

        public AppointmentDetailViewModel GetAppointmentById(string Id)
        {
            var Appointment = new AppointmentDetailViewModel();
            using (SQLiteCommand command = Connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {Enum.GetName(typeof(DatabaseTables), 0)} INNER JOIN {Enum.GetName(typeof(DatabaseTables), 1)} ON {Enum.GetName(typeof(DatabaseTables), 0)}.custId == {Enum.GetName(typeof(DatabaseTables), 1)}.customerId INNER JOIN {Enum.GetName(typeof(DatabaseTables),2)} ON {Enum.GetName(typeof(DatabaseTables), 1)}.customerId == {Enum.GetName(typeof(DatabaseTables), 2)}.custId WHERE {Enum.GetName(typeof(DatabaseTables), 0)}.apptId == '{Id}'";
                using (var data = command.ExecuteReaderAsync().Result)
                {
                    while (data.Read())
                    {
                        Appointment.CustomerName = $"{data["customerName"]}";
                        Appointment.IdentityNumber = $"{data["customerIdentityNo"]}";
                        Appointment.PetName = $"{data["petName"]}";
                    }
                }


            }

            return Appointment;
        }
    }
}
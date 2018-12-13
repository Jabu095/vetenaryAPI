using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinary_Appointment_API.Thirdparty.Extensions
{
    public static class AppointmentProperties
    {
        public static string GetMsgType(this string msg)
        {
            return msg.Split('#')[0];
        }

        public static string GetApptId(this string msg)
        {
            return msg.Split('#')[1];
        }

        public static string GetCustId(this string msg)
        {
            return msg.Split('#')[2];
        }

        public static string GetPetId(this string msg)
        {
            return msg.Split('#')[3];
        }

        public static string GetTime(this string msg)
        {
            return msg.Split('#')[4];
        }
    }


    public static class CustomerProperties
    {
        public static string GetCPMsgType(this string msg)
        {
            return msg.Split('#')[0];
        }

        public static string GetCPCustId(this string msg)
        {
            return msg.Split('#')[1];
        }

        public static string GetCPCustomerName(this string msg)
        {
            return msg.Split('#')[2];
        }

        public static string GetCPCustIdentityNo(this string msg)
        {
            return msg.Split('#')[3];
        }
    }
    public static class PetProperties
    {
        public static string GetPetMsgType(this string msg)
        {
            return msg.Split('#')[0];
        }

        public static string GetPetPetId(this string msg)
        {
            return msg.Split('#')[1];
        }

        public static string GetPetCustId(this string msg)
        {
            return msg.Split('#')[2];
        }

        public static string GetPetPetName(this string msg)
        {
            return msg.Split('#')[3];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinary_Appointment_API.Thirdparty.Extensions;

namespace Veterinary_Appointment_API.Thirdparty.DataGeneration
{
    public class CreatePetData : IMessageData
    {
        public int MsgType { get; private set; } = 1;

        public CreatePetData()
        {

        }

        public IEnumerable<string> Create()
        {
            Random random = new Random();

            for (int i = 1; i <= 18; i++)
            {
                string petId = i.ToString();

                string custId = i.ToString();

                if (i == 17)
                    custId = (i - 1).ToString();
                if (i == 18)
                    custId = "0000";

                string petName = random.GetPetName();

                yield return $"{MsgType}#{petId}#{custId}#{petName}";
            }
        }
    }
}
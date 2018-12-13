using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class ResponseViewModel<T>
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }

    public class AppontmentResponseViewModel
    {
        public string IdentityNumber { get; set; }
        public string PetName { get; set; }
    }
}

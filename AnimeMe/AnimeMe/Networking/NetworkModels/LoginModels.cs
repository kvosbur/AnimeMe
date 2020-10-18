using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeMe.Networking.NetworkModels
{
    public class LoginData
    {
        public string authCode { get; set; }
        public int adminType { get; set; }
    }

    public class LoginResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    public class LoginReturn : LoginResponse
    {

        public LoginData data { get; set; }
    }

    public class LoginErrorResponse : LoginResponse
    {
        public string data { get; set; }
    }
}

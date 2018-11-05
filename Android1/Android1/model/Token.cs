using System;
using System.Collections.Generic;
using System.Text;

namespace Android1
{
    public class Token
    {
        public int Id { get; set; }
        public int access_token { get; set; }
        public int errorText { get; set; }
        public DateTime expiration { get; set; }

        public Token() { }
    }

}

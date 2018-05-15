using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Responses
{
    public class ValueWrapper
    {
        public long value { get; set; }
    }

    public class BaseSuccessResponse
    {
        public ValueWrapper success { get; set; }

        public bool IsSuccess
        {
            get
            {
                return success == null ? false : success.value == 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Common.Service4u2Lib.Json
{
    public interface IJSONSelfSerialize<TResult>
    {
        TResult SelfSerialize(string json);
    }
}

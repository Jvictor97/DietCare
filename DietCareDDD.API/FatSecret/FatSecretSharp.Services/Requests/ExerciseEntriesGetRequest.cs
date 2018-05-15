using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class ExerciseEntriesGetRequest : BaseUserDelegatedRequest
    {
        public DateTime DateUTC { get; set; }
    }
}

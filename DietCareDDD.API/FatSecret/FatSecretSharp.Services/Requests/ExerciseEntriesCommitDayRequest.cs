using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class ExerciseEntriesCommitDayRequest : BaseUserDelegatedRequest
    {
        public DateTime DateUTC { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;
using Service4u2.Json;

namespace FatSecretSharp.Services.Responses
{
    public class ExerciseEntryInfo
    {
        public int calories { get; set; }
        public long exercise_id { get; set; }
        public int minutes { get; set; }
        public string exercise_name { get; set; }
        public int is_template_value { get; set; }
    }

    public class ExerciseEntryWrapper<T>
    {
        public T exercise_entry { get; set; }
    }

    public class ExerciseEntriesGetResponse : IJSONSelfSerialize<ExerciseEntriesGetResponse>
    {
        public ExerciseEntryWrapper<List<ExerciseEntryInfo>> exercise_entries { get; set; }

        #region IJSONSelfSerialize<ExerciseEntriesGetResponse> Members

        public ExerciseEntriesGetResponse SelfSerialize(string json)
        {
            var single = JsonHelper.Deserialize<ExerciseEntriesSingleGetResponse>(json);
            if (single.HasValue)
            {
                return new ExerciseEntriesGetResponse()
                {
                    exercise_entries = new ExerciseEntryWrapper<List<ExerciseEntryInfo>>()
                    {
                        exercise_entry = new List<ExerciseEntryInfo>()
                        {
                            single.exercise_entries.exercise_entry
                        }
                    }
                };
            }

            return JsonHelper.Deserialize<ExerciseEntriesGetResponse>(json);
        }

        #endregion
    }

    public class ExerciseEntriesSingleGetResponse
    {
        public ExerciseEntryWrapper<ExerciseEntryInfo> exercise_entries { get; set; }

        public bool HasValue
        {
            get
            {
                return exercise_entries != null
                        && exercise_entries.exercise_entry != null
                        && exercise_entries.exercise_entry.exercise_name != null;
            }
        }
    }
}

using System.Collections.Generic;

namespace DietCareDDD.FatSecret
{
    public class SingleFoodGetResult
    {
        public int Food_id { get; set; }

        public string Food_name { get; set; }

        public string Food_type { get; set; }

        public Servings servings { get; set; }

        public class Servings
        {
            public Serving[] serving { get; set; }

            public class Serving
            {
                public string calories { get; set; }
                public string carbohydrate { get; set; }
                public string fat { get; set; }
                public string measurement_description { get; set; }
                public string metric_serving_amount { get; set; }
                public string metric_serving_unit { get; set; }
                public string number_of_units { get; set; }
                public string protein { get; set; }
                public string serving_description { get; set; }
            }
        }
    }
}



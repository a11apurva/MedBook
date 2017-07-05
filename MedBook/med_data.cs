using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_try_1
{
    class med_data
    {
    }

    public class Rootobject
    {
        public string status { get; set; }
        public Response response { get; set; }
    }

    public class Response
    {
        public Suggestion[] suggestions { get; set; }

        public Medicine_Alternatives[] medicine_alternatives { get; set; }
    }

    public class Suggestion
    {
        public string suggestion { get; set; }
    }

    public class Medicine_Alternatives
    {
        public string brand { get; set; }
        public string category { get; set; }
        public string d_class { get; set; }
        public int generic_id { get; set; }
        public int id { get; set; }
        public string manufacturer { get; set; }
        public float package_price { get; set; }
        public float package_qty { get; set; }
        public string package_type { get; set; }
        public float unit_price { get; set; }
        public float unit_qty { get; set; }
        public string unit_type { get; set; }
    }
}

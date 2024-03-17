using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Hooks
{
    // Data structure class for POST request scenarios
    internal class PostModelClass
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int userId { get; set; }
        public int id { get; set; }
    }
}

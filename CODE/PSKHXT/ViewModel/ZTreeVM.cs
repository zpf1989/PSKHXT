using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ZTreeVM
    {
        public double id { get; set; }

        public int? pId { get; set; }

        public string name { get; set; }
        //@用作关键字转义
        public bool @checked
        {
            get;
            set;
        }
        public bool isRoot { get; set; }

        public bool open { get; set; }
    }
}

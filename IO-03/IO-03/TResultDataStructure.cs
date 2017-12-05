using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_03
{
    //Zadanie12
    struct TResultDataStructure
    {
        private int iProperty { get; set; }
        private int taskInt { get; set; }

        public TResultDataStructure(int taskInt, int iProperty)
        {
            this.iProperty = iProperty;
            this.taskInt = taskInt;
        }

    }
}

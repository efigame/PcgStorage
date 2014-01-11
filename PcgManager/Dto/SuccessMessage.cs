using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class SuccessMessage
    {
        public bool Success { get; set; }

        public FailedType FailedType { get; set; }

        internal SuccessMessage()
        {
            FailedType = FailedType.NotSet;
        }
    }
}

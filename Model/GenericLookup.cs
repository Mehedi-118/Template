using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenericLookup
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public int GenericLookupTypeId { get; set; }
        public GenericLookupType GenericLookupType { get; set; }
    }
}

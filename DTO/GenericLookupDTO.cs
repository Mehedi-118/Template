using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class GenericLookupDTO
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public int GenericLookupTypeId { get; set; }
    }
}

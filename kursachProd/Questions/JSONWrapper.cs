using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd.Questions
{
    internal class JSONWrapper
    {
        public JSONWrapper() => Questions = new List<Question>();
        public List<Question> Questions { get; set; }
    }
}

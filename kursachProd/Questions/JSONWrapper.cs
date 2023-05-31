using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd.Questions
{
    internal class JSONWrapper
    {
        
        public List<Question> Questions { get; set; }
        /// <summary>
        /// Инициализирует контейнер с вопросами (главный элемент json)
        /// </summary>
        public JSONWrapper() => Questions = new List<Question>();
    }
}

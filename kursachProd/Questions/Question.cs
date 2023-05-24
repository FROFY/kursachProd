using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd.Questions
{
    internal class Question
    {
        public List<string> BodyQuestion { get; set; }
        public Question() => BodyQuestion = new List<string>();
    }
}
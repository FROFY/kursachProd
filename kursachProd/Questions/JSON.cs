using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd.Questions
{
    internal class JSON
    {
        public JSON() { }
        public void Write(object questions)
        {
            string questionObject = JsonConvert.SerializeObject(questions, Formatting.Indented);
            File.WriteAllText("file.json", questionObject);
        }
        public JSONWrapper Read()
        {
            string json = File.ReadAllText("file.json");
            return JsonConvert.DeserializeObject<JSONWrapper>(json);
        }
    }
}

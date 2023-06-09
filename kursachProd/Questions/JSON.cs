﻿using Newtonsoft.Json;
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
        /// <summary>
        /// Сериализация (запись в файл)
        /// </summary>
        /// <param name="questions"></param>
        public void Write(object questions)
        {
            string questionObject = JsonConvert.SerializeObject(questions, Formatting.Indented);
            File.WriteAllText("file.json", questionObject);
        }
        /// <summary>
        /// Десериализация (чтение файла)
        /// </summary>
        /// <returns></returns>
        public JSONWrapper Read()
        {
            try
            {
                return JsonConvert.DeserializeObject<JSONWrapper>(File.ReadAllText("file.json"));
            }
            catch (Exception)
            {
                MessageBox.Show("Не найден файл");
                return new JSONWrapper();
            }
        }
    }
}

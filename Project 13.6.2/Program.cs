using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Project_13._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string path = @"C:\Users\sevac\OneDrive\Рабочий стол\lms-cdn.skillfactory.ru_assets_courseware_v1_dc9cf029ae4d0ae3ab9e490ef767588f_asset-v1_SkillFactory+CDEV+2021+type@asset+block_Text1 (1).pdf";
            
            using (var sr = new StreamReader(path))
            {
                var text = sr.ReadToEnd().ToLower();
                
                text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

                string[] words = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var result = words.GroupBy(x => x)
                    .Where(x => x.Count() > 1)
                    .Select(x => new { Word = x.Key, Frequency = x.Count() });

                foreach (var item in result)
                {
                    if (item.Frequency > 1)
                    {
                        dictionary.Add(item.Word, item.Frequency);
                    }
                }

                var word = result.OrderByDescending(x => x.Frequency).Take(10).ToList();
                foreach (var wor in words)
                {
                    Console.WriteLine(wor);
                }
            }

            var orderedWords = dictionary.OrderByDescending(n => n.Value);

            foreach (var item in orderedWords)
                Console.WriteLine(item);
        }
    }
}
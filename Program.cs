using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_13_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string[] words;
            string path = @"C:\Users\ryche\Desktop\Text_13_6_2.txt";

            using (var sr = new StreamReader(path))
            {
                var text = sr.ReadToEnd().ToLower();

                text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

                words = text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }


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


            var orderedWords = dictionary.OrderByDescending(n => n.Value).Take(10);
            int i = 1;
            foreach (var item in orderedWords)
            {
                Console.WriteLine($"{i}) Слово \"{item.Key}\" встречается {item.Value} раз");
                i++;
            }

        }
    }
}
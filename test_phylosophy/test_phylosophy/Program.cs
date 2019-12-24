using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace test_phylosophy
{
    class Block_Question { 
        public string Question { set; get; }
        public List<string> Answers { set; get; }
        public int CorrectAnswer { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\stazher05\Desktop\testend\phyloshphy_test\test_phylosophy\test_phylosophy\test_final.txt");            List<Block_Question> block_Questions = new List<Block_Question>();
            Block_Question block_Question = new Block_Question();
            block_Question.Answers = new List<string>();
            int code = 0;
            foreach (string line in lines)
            {
                if (block_Question.Question == null || block_Question.Answers.Capacity < 5)
                {
                    if (Regex.IsMatch(line, @"[0-9][.]"))
                    {
                        block_Question.Question = line;
                        code = 0;
                    }


                    else
                    {
                        code++;
                        if (line.Contains("�"))
                        {
                            block_Question.Answers.Add(line);
                            block_Question.CorrectAnswer = code;
                            code = 0;
                        }
                        else
                        {
                            block_Question.Answers.Add(line);
                        }
                    }
                }
                if (block_Question.Question != "" && block_Question.Answers.Capacity >= 5)
                {
                    block_Questions.Add(block_Question);
                    block_Question = new Block_Question();
                    block_Question.Answers = new List<string>();
                }
                
            }
            Console.WriteLine("Test is readed");

            Random random = new Random();
            List<int> order = new List<int>();
            int i = 0;
           while(i < 191)
            {
                int rand = random.Next(0, 233);
                if (!order.Contains(rand)) {
                    order.Add(rand);
                    i++;
                }
            }
            Console.WriteLine("Test is ready");

            List<int> ans_order = null;
           
            foreach (var v in order)
            {
                int i_ans = 1;
                ans_order = new List<int>();
                while (i_ans < 6)
                {
                    int rand = random.Next(1, 6);
                    if (!ans_order.Contains(rand))
                    {
                        ans_order.Add(rand);
                        i_ans++;
                    }
                }

                Console.WriteLine(block_Questions[v].Question);

                foreach (var g in ans_order)
                {
                    if (block_Questions[v].Answers[g - 1].Contains("�"))
                        block_Questions[v].CorrectAnswer = ans_order.IndexOf(g) + 1;
                    Console.WriteLine(block_Questions[v].Answers[g - 1].Replace("�", "o"));
                    
                }
                Console.WriteLine("Your answer:" + Console.ReadLine());
                Console.WriteLine("Correct answer:" + block_Questions[v].CorrectAnswer);
            }

            //while (Console.ReadLine() != "end")
            //{
            //    int rand = random.Next(0, 191);
            //    Console.WriteLine(block_Questions[rand].Question);

            //    foreach (var g in block_Questions[rand].Answers)
            //        Console.WriteLine(g);

            //    Console.WriteLine("Your answer:" + Console.ReadLine());
            //    Console.WriteLine("Correct answer:" + block_Questions[rand].CorrectAnswer);
            //}



        }
    }
}

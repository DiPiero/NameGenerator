using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NickProducer producer = new NickProducer();
            Console.Write("Podaj ilość sylab w nicku: ");
            int syl_num = Convert.ToInt32(Console.ReadLine());

            //String nick = producer.nickGeneration("default_latin", syl_num);
            String nick,first_letter;
            for (int i = 0; i < 10; i++)
            {
                nick = producer.nickGeneration("advanced_english", syl_num);
                first_letter=nick.ElementAt(0).ToString().ToUpper();
                nick = nick.Substring(1);
                nick = first_letter + nick;
                Console.WriteLine(nick);
            } 

            //Console.WriteLine(Convert.ToString(FunctionCode(1)));

            Console.ReadKey();
        }

        static int FunctionCode(int arg1)
        {
            int Value;
            int[] Values = new int[10];
            int K;
            string S;
            S = "))";
            

            K = (int)Math.Floor(S.Length / 2.0);

            K = FindK(K, S);

            Value = K;
            return Value;
        }

        public static int FindK(int oldK, string S)
        {
            if (oldK == 0) return oldK;
            int numL, numR;
            numL = 0;
            numR = 0;
            for (int i = 0; i < oldK; i++) if (S[i] == '(') numL++;
            for (int i = oldK; i < S.Length; i++) if (S[i] == ')') numR++;

            int newK,newStep;
            newStep = ((int)Math.Floor(oldK / 2.0));
            if ((newStep == 0)&& (numL > numR)) return 0;
            else if ((newStep == 0) && (numL < numR)) return S.Length;
            else if (numL == numR) return oldK;
            else if (numL < numR)
            {
                newK = oldK + newStep;
                return FindK(newK, S);
            }
            else
            {
                newK = oldK - newStep;
                return FindK(newK, S);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace rekenmashine
{
    internal class Program
    {
        static void Main(string[] args)
        {       
            string inp1;
            string inp2 = "";
            string original_inp2 = inp2;
            float num1 = 0;
            float num2 = 0;
            string math_function;
            float output = 0;
            float memory = 0;
            while (true)
            {
                bool math_func_input = true;
                bool second_input = true;


                //taking input 1
                Console.Write("voer het eerste nummer in of andere functies(mrc, clear of c, exit):\t");
                inp1 = Console.ReadLine();
                if (inp1 == "mrc")
                {
                    Console.WriteLine(memory);
                    second_input = false;
                    math_func_input = false;
                }
                else if (inp1 == "clear" || inp1 == "c")
                {
                    memory = 0;
                    second_input = false;
                    math_func_input = false;
                    inp1 ="";
                    inp2 = "";
                    original_inp2 = inp2;
                    num1 = 0;
                    num2 = 0;
                    math_function = "";
                    output = 0;
                    memory = 0;
                    Console.Clear();
                }
                else if (inp1 == "exit")
                {
                    break;
                }
                else
                {
                    inp1 = inp1.Replace(".", ","); //zodat een punt werkt as komma
                    if (inp1 != "")
                    {
                        num1 = float.Parse(inp1);
                    }
                    else
                    {
                        second_input = false;
                        math_func_input = false;
                    }
                   
                }

                //math function
                if (math_func_input == true)
                { 
                    Console.Write("voer de wiskunde functie in(+, -, * of x, / of :, wortel of sqrt), je kan ook een andere functie invoeren(m+, m-, clear of c, exit):\t");
                    math_function = Console.ReadLine();
                    if (math_function == "+" || math_function == "-" || math_function == "*" || math_function == "x" || math_function == "*" || math_function == "/" || math_function == ":")
                    {
                        //input 2
                        Console.Write("voer het tweede nummer in, je kan er ook % achter zetten om met procenten te rekenen, je kan ook een andere functie invoeren(clear or c, exit):\t");
                        inp2 = Console.ReadLine();
                        inp2 = inp2.Replace(".", ","); //zodat een punt werkt as komma
                        original_inp2 = inp2; // orginele imput opslaan zodat bij het antwoord de % blijft
                        if (inp2.Contains("%"))
                        {
                            inp2 = inp2.Replace("%", ""); // zodat parse werkt
                            num2 = float.Parse(inp2);
                            num2 = num1 / 100 * num2; // wiskundig gezien beter dan windows, google en apple rekenmashine
                        }
                        else if (inp2 == "clear" || inp2 == "c")
                        {
                            memory = 0;
                            second_input = false;
                            math_func_input = false;
                            inp1 = "";
                            inp2 = "";
                            original_inp2 = inp2;
                            num1 = 0;
                            num2 = 0;
                            math_function = "";
                            Console.Clear();
                        }
                        else if (inp2 == "exit")
                        {
                            break;
                        }
                        else
                        {
                            num2 = float.Parse(inp2);
                        }
                        
                    }
                    else
                    {
                        second_input = false;
                    }
                    // geen 2e input voor math functie

                    //calculeren
                    if (math_function == "+")
                    {
                        output = num1 + num2;
                    }
                    else if (math_function == "-")
                    {
                        output = num1 - num2;
                    }
                    else if (math_function == "*" || math_function == "x")
                    {
                        output = num1 * num2;
                    }
                    else if (math_function == "/" || math_function == ":")
                    {
                        output = num1 / num2;
                    }
                    else if (math_function == "wortel" || math_function == "sqrt")
                    {
                        output = (float)Math.Sqrt(num1); //(float) is zodat de wortel een float is
                    }
                    else if (math_function == "m+")
                    {
                        memory += num1;
                    }
                    else if (math_function == "m-")
                    {
                        memory -= num1;
                    }

                    if (second_input == true)
                    {
                        Console.WriteLine(inp1 + " " + math_function + " " + original_inp2 + " = " + output);
                    }
                    else
                    {
                        if (math_function == "wortel" || math_function == "sqrt")
                        {
                            Console.WriteLine("sqrt(" + inp1 + ")" + " = " + output);
                        }
                        else if (math_function == "clear" || math_function == "c")
                        {
                            memory = 0;
                            second_input = false;
                            math_func_input = false;
                            inp1 = "";
                            inp2 = "";
                            original_inp2 = inp2;
                            num1 = 0;
                            num2 = 0;
                            math_function = "";
                            Console.Clear();
                        }
                        else if (math_function == "exit")
                        {
                            break;
                        }
                    }
                }
            }

        }
    }
}
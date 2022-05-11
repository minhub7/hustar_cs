/*
    Flie Name: Homework03_MinhoKim.cs
    File contents: Calculator Program, Book 대여 프로그램 작성
*/
using System;

namespace Homework03_Calculator
{
    class Hoemwork03_Calculator_MinhoKim
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            double x = 0, y = 0;

            Console.WriteLine("Start Calculate Program!\n");
            while (true){
                Console.WriteLine("Possible Operator ( + , - , * , / , % , ^, Abs )...");
                Console.Write("Input Data (종료는 Q): ");
                String Data = Console.ReadLine();
                if (Data == "Q") { break; }

                String[] splData = Data.Split(' ');
                if (!Array.Exists(c.GetOperator(), x => x == splData[1].ToLower())){
                    Console.WriteLine("Not Supported Operator...\n");
                    continue;
                }

                x = Convert.ToDouble(splData[0]);
                if (splData[1].ToLower() == "abs"){
                    Console.WriteLine($"Abs({x}) = {c.Abs(x)}\n");
                    continue;
                }
                y = Convert.ToDouble(splData[2]);

                switch(splData[1]){
                    case "+":
                        Console.WriteLine($"{x} {splData[1]} {y} = {c.Add(x,y)}");
                        break;
                    case "-":
                        Console.WriteLine($"{x} {splData[1]} {y} = {c.Sub(x,y)}");
                        break;
                    case "*":
                        Console.WriteLine($"{x} {splData[1]} {y} = {c.Mul(x,y)}");
                        break;
                    case "/":
                        Console.WriteLine($"{x} {splData[1]} {y} = {c.Div(x,y)}");
                        break;
                    case "%":
                        Console.WriteLine($"{x} {splData[1]} {y} = {c.Modular(x,y)}");
                        break;
                    case "^":
                        Console.WriteLine($"{x} {splData[1]} {y} = {c.Pow(x,y)}");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
    public class Calculator{
        protected String[] operate;

        public Calculator(){
            this.operate = new String[]{"+" , "-" , "*" , "/" , "%" , "^", "abs"};
        }
        public String[] GetOperator(){ return operate; }
        public double Add(double x, double y){ return x + y; }
        public double Sub(double x, double y){ return x - y; }
        public double Mul(double x, double y){ return x * y; }
        public double Div(double x, double y){ return x / y; }
        public double Modular(double x, double y){ return x % y; }
        public double Pow(double x, double y){
            double res = 1;
            for(int i = 0; i < y; i++){ res *= x; }
            return res;
        }
        public double Abs(double x){ return (x > 0)? x : -x; }
    }
}

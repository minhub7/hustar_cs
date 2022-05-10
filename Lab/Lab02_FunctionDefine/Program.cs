using System;

struct Student{
    public int sID;
    public String name;
    public int age;
    public String dept;
}

namespace Lab02_FunctionDefine
{
    class Program
    {
        static void Main(string[] args)
        {
            Show(args);

            void Show(String[] msg){
                for (int i=0; i < msg.Length; i++){
                    Console.Write(msg[i]+ " ");
                }
                Console.WriteLine();
            }

            ////////////////////////////////////////////////////////////////////////////////
            // 01. 사용자 정의 함수 예제
            /*
            Console.Write("Input two data: ");
            String[] Data = Console.ReadLine().Split(' ');
            int x = Convert.ToInt32(Data[0]);
            int y = Convert.ToInt32(Data[1]);

            Console.WriteLine($"{x} + {y} = {Add(x,y)}");
            Console.WriteLine($"The maximum value of {x} and {y} = {findMax(x,y)}");
            Console.WriteLine($"The minimum value of {x} and {y} = {findMin(x,y)}");
            Console.WriteLine($"The abstract value of {x} = {findAbs(x)}");

            int Add(int x, int y){
                return x + y;
            }

            double findMax(double x, double y){
                return (x > y)? x : y;
            }

            double findMin(double x, double y){
                return (x < y)? x : y;
            }

            double findAbs(double x){
                return (x > 0)? x : -x;
            }

            // ax**2 - bx + c
            double a = 1, b = -6, c = 6;
            double[] answer = rootFormula(a, b, c);
            Console.WriteLine($"{answer[0]:2F}, {answer[1]:2F}");

            double[] rootFormula(double a, double b, double c){
                double[] result = {(-b + Math.Sqrt(b*b - 4*a*c)) / 2*a, (-b - Math.Sqrt(b*b - 4*a*c)) / 2*a};
                return result;
            }*/

            ////////////////////////////////////////////////////////////////////////////////
            // 02. Struct 예제
            /*
            Student student1 = new Student();
            student1.sID = 20010010;
            student1.name = "Kim";
            student1.age = 27;
            student1.dept = "ICT";
            Console.WriteLine($"{student1.sID} {student1.name} {student1.age} {student1.dept}");
            */

            ////////////////////////////////////////////////////////////////////////////////
            Example ins = new Example();
            Example.StaticMethod();
            // Environment.Exit(0); // 강제 종료 기능
            ins.InstanceMethod();

            Random rand = new Random();
            Console.WriteLine(rand.Next());
            Console.WriteLine(rand.Next(10));
            Console.WriteLine(rand.Next(1, 20));
        }
    }
    class Example{
        public static void StaticMethod(){
            Console.WriteLine("Call by Static Method");
        }
        public void InstanceMethod(){
            Console.WriteLine("Call by Instance Method");
        }
    }
}

/*
    File name: Homework02_Program.cs
    File Contents: 로또 번호 생성기, 가위바위보 게임
    Programmed by Minho Kim .2022.05.10.
*/

using System;

namespace Homework02
{
    class Homework02_MinhoKim
    {
        static void Main(string[] args)
        {
            Lotto lotto = new Lotto();
            String[] RPC = {"가위", "바위", "보"};
            lotto.generateLotto();

            Console.WriteLine("Generate New Lotto Numbers");
            for (int i=0; i < lotto.getLength(); i++){
                Console.Write($"{lotto.lotto[i]} ");
            }
            Console.WriteLine();

            while (true){
                Console.Write("Input one of (가위, 바위, 보), (종료는 Q): ");
                String userRPC = Console.ReadLine();
                if (userRPC == "Q") { break; }
                if (!Array.Exists(RPC, x => x == userRPC)){
                    Console.WriteLine("가위, 바위, 보 중에 입력하세요.\n");
                    continue;
                }
                RockPaperScissors(userRPC);
                Console.WriteLine();
            }
            

            void RockPaperScissors(String src){
                String[] RPC = {"가위", "바위", "보"};
                Random rand = new Random();
                int i = rand.Next(3);

                switch(src){
                    case "가위":
                        Console.Write($"컴퓨터는 {RPC[i]}, 결과는 ");
                        if (i == 0){ Console.WriteLine("비겼습니다."); }
                        if (i == 1){ Console.WriteLine("졌습니다."); }
                        if (i == 2){ Console.WriteLine("이겼습니다."); }
                        break;
                    case "바위":
                        Console.Write($"컴퓨터는 {RPC[i]}, 결과는 ");
                        if (i == 0){ Console.WriteLine("이겼습니다."); }
                        if (i == 1){ Console.WriteLine("비겼습니다."); }
                        if (i == 2){ Console.WriteLine("졌습니다."); }
                        break;
                    case "보":
                        Console.Write($"컴퓨터는 {RPC[i]}, 결과는 ");
                        if (i == 0){ Console.WriteLine("졌습니다."); }
                        if (i == 1){ Console.WriteLine("이겼습니다."); }
                        if (i == 2){ Console.WriteLine("비겼습니다."); }
                        break;
                }
            }
        }
    }
    class Lotto{
        public int[] lotto = new int[6];
        public void generateLotto(){
            Random rand = new Random();
            int i = 0;
            while (i < 6){
                int randNum = rand.Next(1,46);
                if(!Array.Exists(lotto, x => x == randNum)){
                    lotto[i] = randNum;
                    i++;
                }
            }
        }
        public int getLength(){
            return lotto.Length;
        }
    }
}

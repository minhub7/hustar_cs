/*
    File name: Homework01_MinhoKim
    File Contents: 구구단 출력 프로그램
    Programmed by Minho Kim 2022.05.09 (mon)
*/
using System;

namespace Homework01
{
    class Homework01_MinhoKim
    {
        static void Main(string[] args)
        {
            // 구구단 출력 프로그램
            for (int i=1; i<=9; i++){
                for (int j=2; j<=9; j++){
                    Console.Write($"{j,2} X {i,-2} = {i*j,-4}");
                }
                Console.WriteLine();
            }
        }
    }
}

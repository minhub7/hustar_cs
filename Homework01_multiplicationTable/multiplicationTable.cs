// See https://aka.ms/new-console-template for more information
// 구구단 출력 프로그램
using System;

for (int i=1; i<=9; i++){
    for (int j=2; j<=9; j++){
        Console.Write($"{j,2} X {i,-2} = {i*j,-4}");
    }
    Console.WriteLine();
}
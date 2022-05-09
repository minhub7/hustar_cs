// See https://aka.ms/new-console-template for more information
using System;

int myAge = 27, age2 = 10;
// 데이터형 선언 시 ?를 붙이면 null 값을 부여할 수 있음
// int? x = null;

// 상수는 const
// const double PI = 3.14159265;
String grade = "My grade is A";

Console.WriteLine(grade); // 콘솔창에 결과 보기
Console.WriteLine(myAge - age2);

/////////////////////////////////////////////////////////////////////

double d = 23.12;
int i = 12345;

d = i;
Console.WriteLine("암시적 형 변환 = " + d);

d = 12.34;
i = (int)d;
Console.WriteLine("명시적 형 변환 = " + i);

String s = "";
s = Convert.ToString(d);
Console.WriteLine("형식 변환 = " + s);

/////////////////////////////////////////////////////////////////////
// WriteLine과 Write의 차이점: 개행 여부
Console.Write("Input data: ");
String input = Console.ReadLine();
// char c = Convert.ToChar(input);

Console.WriteLine("Input data is " + '"' + input + '"');
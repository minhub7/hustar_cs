// See https://aka.ms/new-console-template for more information
using System;

// 학생의 수를 입력 받은 후 학생 수 만큼 배열 선언
Console.Write("Input number of Students: ");
int size = Convert.ToInt32(Console.ReadLine());
int[,] person = new int[size, 3];
int[] total = new int[size];
float[] avg = new float[size];
char[] grade = new char[size];

// for 문으로 학생들의 성적을 입력받고 총점과 평균, 학점 등급을 계산
for(int i=0; i<size; i++){
    Console.Write("Input Score (KOR, ENG, MATH 순서): ");
    String[] scoreData = Console.ReadLine().Split(' ');
    person[i,0] = Convert.ToInt32(scoreData[0]);
    person[i,1] = Convert.ToInt32(scoreData[1]);
    person[i,2] = Convert.ToInt32(scoreData[2]);
    total[i] = person[i,0] + person[i,1] + person[i,2];
    avg[i] = (float)total[i] / 3;

    if(avg[i] >= 90){
        grade[i] = 'A';
    }else if(avg[i] >= 80){
        grade[i] = 'B';
    }else if(avg[i] >= 70){
        grade[i] = 'C';
    }else if(avg[i] >= 60){
        grade[i] = 'D';
    }else {
        grade[i] = 'F';
    }
}

// 출력 format 지정
Console.WriteLine($"\n***Score Table***");
Console.WriteLine("kor|eng|math  |Total Score| |Average| |Grade|");
Console.WriteLine("---------------------------------------------");
for (int i=0; i < size; i++){
    Console.WriteLine($"{person[i,0], 3} {person[i,1], 3} {person[i,2], 3} {total[i], 10} {avg[i], 12:F2} {grade[i], 6}   --- Person({i+1})");
}
////////////////////////////////////////////////////////////////////////////
// 평균에 따른 등급 계산 (switch 문 사용한 방법)
// switch((int)avg/10){
//     case 9:
//         grade = 'A';
//         break;
//     case 8:
//         grade = 'B';
//         break;
//     case 7:
//         grade = 'C';
//         break;
//     case 6:
//         grade = 'D';
//         break;
//     default:
//         grade = 'F';
//         break;
// }
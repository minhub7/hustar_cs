using System;

namespace Lab03_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Person test = new Person();
            Person Kim = new Person("Kim", 27, 180, 70, 'A');
            test.ShowInfo();
            Kim.ShowInfo();
            Console.WriteLine($"Kim's GetName is {Kim.GetName()}");
            Console.WriteLine($"test Name is {test.GetName()}");
            test.SetName("Son");
            Console.WriteLine($"After test SetName is {test.GetName()}\n");

            Student test2 = new Student();
            Student Lee = new Student("Lee", 28, 175, 68, 'B', "POSTECH", "Computer", 2);
            test2.ShowInfo();
            Console.WriteLine();
            Lee.ShowInfo();

        }
    }

    public class Person{
        protected String name;
        protected int age;
        protected float height, weight;
        protected char bloodType;

        public Person(){
            name = null;
            age = 0;
            height = 0;
            weight = 0;
            bloodType = ' ';
        }
        public Person(String _name, int _age, float _height, float _weight, char _bdt){
            name = _name;
            age = _age;
            height = _height;
            weight = _weight;
            bloodType = _bdt;
        }
        public void ShowInfo(){
            Console.WriteLine($"Name: {name, 5} | Age: {age, 3} | height: {height, 3} | weight: {weight, 3} | Blood Type: {bloodType}");
        }
        public void Bark(){ Console.WriteLine("Wal Wal"); }

        public String GetName(){ return this.name; }
        public int GetAge(){ return this.age; }
        public float GetHeight(){ return this.height; }
        public float GetWeight(){ return this.weight; }
        public char GetBloodType(){ return this.bloodType; }

        public void SetName(String newName){ this.name = newName; }
        public void SetAge(int newAge){ this.age = newAge; }
        public void SetHeight(float newHeight){ this.height = newHeight; }
        public void SetWeight(float newWeight){ this.weight = newWeight; }
        public void SetBloodType(char newBLDT){ this.bloodType = newBLDT; }
    }

    public class Student : Person {
        private String schoolName, major;
        private int grade;

        public Student(){
            base.name = null;
            base.age = 0;
            base.height = 0;
            base.weight = 0;
            base.bloodType = ' ';
            this.schoolName = null;
            this.major = null;
            this.grade = 0;
        }
        public Student(String _name, int _age, float _height, float _weight, char _bdt, String _schoolName, String _major, int _grade){
            base.name = _name;
            base.age = _age;
            base.height = _height;
            base.weight = _weight;
            base.bloodType = _bdt;
            this.schoolName = _schoolName;
            this.major = _major;
            this.grade = _grade;
        }

        public void ShowInfo(){
            Console.WriteLine($"Name: {name, 5} | Age: {age, 3} | height: {height, 3} | weight: {weight, 3} | Blood Type: {bloodType}");
            Console.WriteLine($"School Name: {schoolName} | Major: {major} | Grade: {grade}");
        }
    }
}

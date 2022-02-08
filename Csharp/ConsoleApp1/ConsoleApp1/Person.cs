using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    namespace qq
    {
        class Person
        {
            public string _name;
            public int _age;
            private double _height;
            private double _width;
            // static
            public static int amount = 0;

            // setter getter
            public double Height
            {
                get { return _height; }
                set { _height = value; }
            }

            public double Width
            {
                get { return _width; } 
                set { _width = value; }
            }

            // construct
            public Person(string name, int age, double h, double w)
            {
                _name = name;
                _age = age;
                Height = h;
                Width = w;
                amount++;
            }


            public void SayHi()
            {
                Console.WriteLine("hello i am " + _name);
            }

            public bool IsAdult()
            {
                return _age >= 18;
            }

            public int getAmount()
            {
                return amount;
            }
        }

        // static class can't be create
        static class Tool
        {
            // static method
            public static void SayHi()
            {
                Console.WriteLine("Hello");
            }
        }

        // inheritance
        class Student : Person
        {
            public string _school;

            public Student(string name, string school, int age, double h, double w):base(name, age, h, w)
            {
                _school = school;
            }

            public string getSchool()
            {
                return _school;
            }

        }

    }

}

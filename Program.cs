using System;

namespace PolymorphicCollections
{
    // Абстрактний базовий клас Фігура
    abstract class Shape
    {
        public abstract string Name { get; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    // Похідний клас Коло
    class Circle : Shape
    {
        public double Radius { get; set; }
        public override string Name => "Коло";

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }

    // Похідний клас Прямокутник
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string Name => "Прямокутник";

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => 2 * (Width + Height);
    }

    // Похідний клас Трикутник (додано відповідно до пункту "Зміст роботи")
    class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public override string Name => "Трикутник";

        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public override double GetPerimeter() => SideA + SideB + SideC;

        public override double GetArea()
        {
            // Обчислення площі за формулою Герона
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення масиву базового типу Shape[] (виконується апкастинг)
            // Містить по два об'єкти Circle, Rectangle та Triangle
            Shape[] shapes = new Shape[]
            {
                new Circle(5),
                new Circle(3),
                new Rectangle(4, 6),
                new Rectangle(2, 8),
                new Triangle(3, 4, 5),
                new Triangle(6, 8, 10)
            };

            double totalArea = 0;
            double totalPerimeter = 0;

            Console.WriteLine("=== Обробка поліморфної колекції фігур ===\n");

            // Єдиний цикл для обходу всіх об'єктів
            foreach (Shape shape in shapes)
            {
                double area = shape.GetArea();
                double perimeter = shape.GetPerimeter();

                // Виведення площі кожної фігури (Загальне завдання)
                Console.WriteLine($"{shape.Name}: Площа = {area:F2}, Периметр = {perimeter:F2}");

                // Підрахунок загальної суми площ та периметрів (Зміст роботи + Домашнє завдання)
                totalArea += area;
                totalPerimeter += perimeter;
            }

            Console.WriteLine("\n=== Підсумкові результати ===");
            Console.WriteLine($"Загальна площа всіх фігур: {totalArea:F2}");
            Console.WriteLine($"Загальна сума периметрів усіх фігур (ДЗ): {totalPerimeter:F2}");
        }
    }
}

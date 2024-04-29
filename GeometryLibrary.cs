using System;

namespace GeometryLibrary
{
    /// <summary>
    /// Интерфейс, представляющий геометрическую фигуру.
    /// </summary>
    public interface IShape
    {
        double CalculateArea();
    }
    /// <summary>
    /// Класс, представляющий круг.
    /// </summary>
    public class Circle : IShape
    {
        private double radius;
        /// <summary>
        /// Конструктор класса Circle.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            this.radius = radius;
        }
        /// <summary>
        /// Метод для вычисления площади круга.
        /// </summary>
        /// <returns>Площадь круга.</returns>
        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }
    /// <summary>
    /// Класс, представляющий треугольник.
    /// </summary>
    public class Triangle : IShape
    {
        private double sideA;
        private double sideB;
        private double sideC;
        /// <summary>
        /// Конструктор класса Triangle.
        /// </summary>
        /// <param name="sideA">Длина первой стороны треугольника.</param>
        /// <param name="sideB">Длина второй стороны треугольника.</param>
        /// <param name="sideC">Длина третьей стороны треугольника.</param>
        /// <exception cref="ArgumentException">Выводится ошибка, если переданные стороны не образуют треугольник.</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (!IsValidTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Треугольника не существует. Сумма двух любых сторон должна быть больше третьей стороны.");
            }
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
        /// <summary>
        /// Метод для вычисления площади треугольника с помощью площади Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public double CalculateArea()
        {
            double s = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }
        /// <summary>
        /// Метод для определения, является ли треугольник прямоугольным.
        /// </summary>
        /// <returns>True, если треугольник прямоугольный, иначе - false.</returns>
        public bool IsRightTriangle()
        {
            double[] sides = { sideA, sideB, sideC };
            Array.Sort(sides);
            return sides[2] * sides[2] == sides[0] * sides[0] + sides[1] * sides[1];
        }
        /// <summary>
        /// Метод для проверки возможности существования треугольника по длинам его сторон.
        /// </summary>
        /// <param name="a">Длина первой стороны.</param>
        /// <param name="b">Длина второй стороны.</param>
        /// <param name="c">Длина третьей стороны.</param>
        /// <returns>True, если треугольник с такими сторонами существует, иначе - false.</returns>
        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }

}


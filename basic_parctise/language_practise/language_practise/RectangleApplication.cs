using System;
namespace rectangle_application
{
    class Rectangle
    {
        double length;
        double width;
        dynamic d = 123;
        public void Acceptdetails()
        {
            length = 4.5;
            width = 3.5;
        }

        public double GetArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
            Console.WriteLine("dynamic: {0}", d);
            string str = @"/var/


www";
            Console.WriteLine(str);
           
        }
    }

    class ExecuteRectangle
    {
        //static void Main(String[] args)
        //{
        //    Rectangle r = new Rectangle();
        //    r.Acceptdetails();
        //    r.Display();
        //    Console.ReadLine();
        //}
    }
}

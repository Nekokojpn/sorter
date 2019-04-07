using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace sorter
{
    public class debugClass
    {
        public void a(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(debtext + "\r\n");
        }
        public void a_ly()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("*" + "\r\n");
        }
        public void a_event(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(debtext + "\r\n");
        }
        public void a_event_ln(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(debtext);
        }
        public void a_method(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write(debtext + "\r\n");
        }
        public void a_method_ln(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write(debtext);
        }
        public void a_script(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(debtext + "\r\n");
        }
        public void a_script_ln(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(debtext);
        }
        public void a_error(string debtext)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(debtext + "\r\n");
        }
        public void ms_error(string mes)
        {
            MessageBox.Show(mes, "learningSystem", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

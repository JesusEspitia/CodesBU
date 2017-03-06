using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testEmail
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba el correo al que desee enviar");
            string to = Console.ReadLine();
            Email email = new Email();
            Console.WriteLine("Indique el metodo: 1 0 2");
            int resp = Convert.ToInt32(Console.ReadLine());
            switch (resp)
            {
                case 1:
                    email.sendEmail(to);
                    break;
                case 2:
                    email.SendCDO(to);
                    break;
            }
            
            Console.WriteLine("Oprima enter");
            Console.ReadKey();
        }
    }
}

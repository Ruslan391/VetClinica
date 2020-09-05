using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
 
namespace EFGetStarted

{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (veterinar db = new veterinar())
            {       
             Console.Write("Добавить клинику? Y/N:  ");
             if (Console.ReadLine()=="Y")
                 {
                    string title1, address1;
                    int phnumber1=0;
                    Console.Write("Название:   ");
                    title1=Console.ReadLine();
                    Console.Write("Адрес:   ");
                    address1=Console.ReadLine();
                    int i = 0;
                    do
                        {
                    try
                      {
                        Console.Write("Телефон:   ");
                        phnumber1=Convert.ToInt32(Console.ReadLine());
                        i=0;
                      }
                    catch (Exception ex)
                      {
                          i = 1;
                          Console.WriteLine($"Возникло исключение: {ex.Message}");

                      } 
                        }
                    while (i == 1);

                    Console.Write("Сщхранить? Y/N:   ");

                    if (Console.ReadLine()=="Y")
                    
                        {
                        do
                            {
                            VetClinica vetclinica1 = new VetClinica {Title= title1, Address = address1, PhNamber = phnumber1};
                            try
                               {
                                   db.VetClinica.Add(vetclinica1);
                                   db.SaveChanges();
                               }
                            catch (Exception ex)
                               {
                                   Console.WriteLine($"Возникло исключение: {ex.Message}");
                                    i = 1;
                               }
                            finally 
                               {
                                   Console.WriteLine("Клиника добавлена");
                                   i = 0;
                               }
                            }
                        while (i == 1);     
                        }

                 }

               }
            //Console.Read();
        }
    }
}
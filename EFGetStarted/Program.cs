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
             int j = 0;
             while (j==0)
             {      
             Console.WriteLine("Добавить: 1 - клинику, 2 - доктора, 3 - ветуслуга 4 - выйти");
             string q = Console.ReadLine();
             switch (q)
              {
               case  "1":
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
                    break;

                 }
            case "2":
                {
                   string FIODoctor, DescriptionDoctor;
                    int AgeDoctor=0, StagDoctor=0;
                    Console.Write("ФИО:   ");
                    FIODoctor=Console.ReadLine();
                    Console.Write("Описание:   ");
                    DescriptionDoctor=Console.ReadLine();
                    int i = 2;
                    do
                        {
                    try
                      {
                        Console.Write("Возраст:   ");
                        AgeDoctor=Convert.ToInt32(Console.ReadLine());
                        if (AgeDoctor<100) {i=0;}
                      }
                    catch (Exception ex)
                      {
                          i = 1;
                          Console.WriteLine($"Возникло исключение: {ex.Message}");

                      } 
                        }
                    while (i == 1);

                    i = 1;
                    while (i==1)
                        {
                    try
                      {
                        Console.Write("Стаж:   ");
                        StagDoctor=Convert.ToInt32(Console.ReadLine());
                        
                        if (StagDoctor<AgeDoctor) {i=0;}
                      }
                    catch (Exception ex)
                      {
                          i = 1;
                          Console.WriteLine($"Возникло исключение: {ex.Message}");

                      } 
                        }

                    Console.Write("Сщхранить? Y/N:   ");

                    if (Console.ReadLine()=="Y")
                    
                        {
                        do
                            {
                            VetDoctor vetdoctor1 = new VetDoctor {FIO= FIODoctor, Age = AgeDoctor, Stag = StagDoctor, Description = DescriptionDoctor};
                            try
                               {
                                   db.VetDoctor.Add(vetdoctor1);
                                   db.SaveChanges();
                               }
                            catch (Exception ex)
                               {
                                   Console.WriteLine($"Возникло исключение: {ex.Message}");
                                    i = 1;
                               }
                            finally 
                               {
                                   Console.WriteLine("Доктор добавлен");
                                   i = 0;
                               }
                            }
                        while (i == 1);     
                        } 
                    break;
                }
            case "3":
                {
                    string titleUslugi, animalsUslugi, descriptionUslugi;
                    Console.Write("Название услуги:   ");
                    titleUslugi=Console.ReadLine();
                    Console.Write("Животное:   ");
                    animalsUslugi=Console.ReadLine();
                    Console.Write("Описание услуги:   ");
                    descriptionUslugi=Console.ReadLine();
                    

                    Console.Write("Сщхранить? Y/N:   ");
                    int i=0;
                    if (Console.ReadLine()=="Y")

                        {
                        do
                            {
                            VetUslugi vetuslugi1 = new VetUslugi {Title= titleUslugi, Animals = animalsUslugi, Description = descriptionUslugi};
                            try
                               {
                                   db.VetUslugi.Add(vetuslugi1);
                                   db.SaveChanges();
                               }
                            catch (Exception ex)
                               {
                                   Console.WriteLine($"Возникло исключение: {ex.Message}");
                                    i = 1;
                               }
                            finally 
                               {
                                   Console.WriteLine("ВетУслуга добавлена");
                                   i = 0;
                               }
                            }
                        while (i == 1);     
                        }
                    break;
                }
            case "4":
                {
                    j=1;
                    break;
                }

               }
            }
            //Console.Read();
        }
    }
}
}
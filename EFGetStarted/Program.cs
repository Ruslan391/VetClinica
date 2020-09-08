using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
 
namespace EFGetStarted

{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i=0, j=0;
            using (veterinar db = new veterinar())
            { 
             j = 0;
             while (j==0)
             {      
             Console.WriteLine("Добавить: 1 - клинику, 2 - доктора, 3 - ветуслуга 4 - продолжить");
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
                    i = 0;
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
                    i = 2;
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
                    i=0;
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
            j = 0;
            while (j==0)
                {
                Console.WriteLine("Действия: Добавить Доктора в клинику - 1, Добавить услугу в клинику - 2, добавить доктору услугу - 3, выход -4");
                string qq = Console.ReadLine();
                string titleVet, nameDoc;
                switch (qq)
                    {
                        case "1":
                            {
                                i=0;
                                while (i==0)
                                  {
                                   do
                                     {                      
                                       Console.WriteLine("Введите название клиники");
                                       titleVet=Console.ReadLine();
                                       if (db.VetClinica.Any(cs => cs.Title==titleVet) == true)
                                          {
                                               Console.WriteLine("ok");
                                               i=0;
                                          }
                                       else 
                                          {
                                              Console.WriteLine("Клиника отсутствует в базе. Выйти? Y/N");
                                              if (Console.ReadLine()=="Y") {i=1; break;}
                                              i=1;
                                          }
                                      }
                                    while (i!=0);
                                    if (i==1) break;
                                    var vetclinica1 = db.VetClinica.Where(cs => cs.Title==titleVet).First();
                                    do
                                      {
                                        Console.WriteLine("Введите имя доктора");
                                        nameDoc=Console.ReadLine();
                                        if (db.VetDoctor.Any(cs => cs.FIO==nameDoc) == true)
                                          {
                                              Console.WriteLine("ok");
                                              i=0;
                                          }
                                        else 
                                          {
                                            Console.WriteLine("Доктор отсутствует в базе. Выйти? Y/N");
                                            if (Console.ReadLine()=="Y") {i=1; break;}
                                            i=1;
                                          }
                                      }
                                    while (i!=0);
                                    if (i==1) break;
                                    var vetDoc1 = db.VetDoctor.Where(cs => cs.FIO==nameDoc).First();
                                    vetclinica1.DoctorInClinicas.Add(new DoctorInClinica{VetClinicaId=vetclinica1.Id, VetDoctorId=vetDoc1.Id});
                                    db.SaveChanges();
                                    Console.WriteLine("Данные добавлены");
                                    i=1;
                                  }
                                break;
                            }
                        case "2":
                            {
                                break;
                            }
                        case "3":
                            {
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
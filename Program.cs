using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteBook
{
    
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Show_Menu();
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите слово \"Все\", если хотите просмотреть все записи, если хотите посмотерть определенную запись, введите её id:");
                        string str = Console.ReadLine();
                        if (str.ToLower().Equals("все"))
                        {
                            Human.Show_Humans();
                            break;
                        }
                        if (Int32.TryParse(str, out int id))
                        {
                            if (Human.list_of_people.ContainsKey(id))
                            {
                                Human.Show_One_Human(id);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели несуществующий id, нажмите любую клавишу, чтобы попробовать снова");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели недопустиые символы, нажмите любую клавишу, чтобы попробовать снова");
                            Console.ReadKey();
                        }
                    }
                }
                if (answer == "2")
                {
                    Console.Clear();
                    Human.Add_Human(Human.Id);
                }
                if (answer == "3")
                {
                    Console.WriteLine("Введите id записи, которую вы хотите изменить");
                    int id = Convert.ToInt32( Console.ReadLine());
                    Human.Edit_Human(id);
                }
                if (answer == "4")
                {
                    Human.Delete_Human();
                }
                if (answer == "5")
                {
                    break;
                }
            }
          

        }

        static void Show_Menu()
        {
            Console.WriteLine("1. Просмотр созданных записей");
            Console.WriteLine("2. Добавить запись");
            Console.WriteLine("3. Редактировать запись");
            Console.WriteLine("4. Удалить запись");
            Console.WriteLine("5. Выйти из программы");
          
        }
    }
}

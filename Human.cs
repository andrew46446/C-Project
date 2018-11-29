using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteBook
{
    class Human
    {
        public static Dictionary <int, Human> list_of_people= new Dictionary<int, Human>();
        public static int Id { get; set; }
        public enum Country { Russia, Belarus, Kazakhstan, Other_Countries, Default_Country }

        public string Name { get; set; } = "defaul_name";
        public string Surname { get; set; } = "defaul_surname";
        public string Thirdname { get; set; } = "defaul_thirdname";
        public string Phone_number { get; set; } = "defaul_number";
        public Country citizenship = Country.Default_Country;
        public DateTime Birth_date = new DateTime(01/01/2000); 
        public string Org { get; set; } = "defaul_org";
        public string Position { get; set; } = "defaul_position";
        public string Notes { get; set; } = "defaul_notes";

        public static void Add_Human(int id)
        {
            Human person1 = new Human();
            Console.WriteLine("Введите имя:");
            person1.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            person1.Surname = Console.ReadLine();
            Console.WriteLine("Введите номер телефона:");
            while (true)
            {
                string s = Console.ReadLine();
                if (Int32.TryParse(s, out int result))
                {
                    if (s.Length >= 5)
                    {
                        person1.Phone_number = s;
                        break;
                    }
                    else Console.WriteLine("Вы ввели недостаточное количество символов, попробуйте еще раз:");
                }
                else Console.WriteLine("Вы ввели недопустимые символы, попробуйте еще раз:");
            }
            Console.WriteLine("Выбирете страну из перечисленных и напишите ее порядковый номер:");
            Console.WriteLine("1.Russia\n2.Belarus\n3.Kazakhstan\n4.Other Countries");
            switch (Console.ReadLine())
            {
                case "1":
                    person1.citizenship = Country.Russia;
                    break;
                case "2":
                    person1.citizenship = Country.Belarus;
                    break;
                case "3":
                    person1.citizenship = Country.Kazakhstan;
                    break;
                case "4":
                    person1.citizenship = Country.Other_Countries;
                    break;
            }
            Console.WriteLine("Хотите ввести дополнительную информацию? Введите да- если хотите, нет -если нет.");
            string answer = Console.ReadLine();
            if (answer.ToLower().Equals("да"))
            {
                Console.WriteLine("Введите отчество:");
                person1.Thirdname = Console.ReadLine();
                Console.WriteLine("введите дату рождения:");
                person1.Birth_date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите место работы:");
                person1.Org = Console.ReadLine();
                Console.WriteLine("Введите должность:");
                person1.Position = Console.ReadLine();
                Console.WriteLine("Введите доп. информацию:");
                person1.Notes = Console.ReadLine();
            }
            else { }

            list_of_people.Add(Id, person1);
            Id++;
            Console.WriteLine("Запись успешно создана!\nНажмите любую клавишу для продолжения:");
            Console.ReadKey();
        }
        public static void Show_Humans()
        {
            if (list_of_people.Count == 0)
            {
                Console.WriteLine("Созданные записи отсутсвуют!\nНажмите любую клавишу для продолжения работы:");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("1-показать основную информацию\n2-показать полную информацию");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    foreach (KeyValuePair<int, Human> keyValue in list_of_people)
                    {
                        Console.WriteLine("id: " + keyValue.Key + "," + keyValue.Value.Surname + ',' + keyValue.Value.Name + ',' + keyValue.Value.Phone_number);
                    }
                    Console.WriteLine("Для продолжения нажмите любую клавишу:");
                    Console.ReadKey();
                }
                if (answer == "2")
                {
                    foreach (KeyValuePair<int, Human> keyValue in list_of_people)
                    {
                        Console.WriteLine("id: " + keyValue.Key);
                        Console.WriteLine("Surname: " + keyValue.Value.Surname);
                        Console.WriteLine("Name: " + keyValue.Value.Name);
                        Console.WriteLine("Thirdname: " + keyValue.Value.Thirdname);
                        Console.WriteLine("Phone number: " + keyValue.Value.Phone_number);
                        Console.WriteLine("Country: " + keyValue.Value.citizenship);
                        Console.WriteLine("birth date: " + keyValue.Value.Birth_date);
                        Console.WriteLine("Organisation: " + keyValue.Value.Org);
                        Console.WriteLine("Position: " + keyValue.Value.Position);
                        Console.WriteLine("Other notes: " + keyValue.Value.Notes);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Для продолжения нажмите любую клавишу:");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
        public static void Show_One_Human(int id)
        {
            Console.Clear();
            Console.WriteLine("id: " + id);
            Console.WriteLine("Surname: " + list_of_people[id].Surname);
            Console.WriteLine("Name: " + list_of_people[id].Name);
            Console.WriteLine("Thirdname: " + list_of_people[id].Thirdname);
            Console.WriteLine("Phone number: " + list_of_people[id].Phone_number);
            Console.WriteLine("Country: " + list_of_people[id].citizenship);
            Console.WriteLine("birth date: " + list_of_people[id].Birth_date);
            Console.WriteLine("Organisation: " + list_of_people[id].Org);
            Console.WriteLine("Position: " + list_of_people[id].Position);
            Console.WriteLine("Other notes: " + list_of_people[id].Notes);
            Console.WriteLine("Для продолжения нажмите любую клавишу:");
            Console.ReadKey();
        }
        public static void Edit_Human(int id)
        {
            Console.WriteLine("Введите название поля которое вы хотите редактировать");
            string field = Console.ReadLine();
            switch (field)
            {
                case "Name":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Name = Console.ReadLine();
                    break;

                case "Surname":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Surname = Console.ReadLine();
                    break;

                case "Thirdname":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Thirdname = Console.ReadLine();
                    break;

                case "Phone_number":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Phone_number = Console.ReadLine();
                    break;

                case "Birth_date":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Birth_date = DateTime.Parse( Console.ReadLine());
                    break;

                case "Org":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Org = Console.ReadLine();
                    break;

                case "Position":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Position = Console.ReadLine();
                    break;

                case "Notes":
                    Console.WriteLine("Введите необходимую информацию:");
                    list_of_people[id].Notes = Console.ReadLine();
                    break;
                case "Country":
                    Console.WriteLine("Выбирете страну из перечисленных и напишите ее порядковый номер");
                    Console.WriteLine("1.Russia\n2.Belarus\n3.Kazakhstan\n4.Other Countries");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            list_of_people[id].citizenship = Country.Russia;
                            break;
                        case "2":
                            list_of_people[id].citizenship = Country.Belarus;
                            break;
                        case "3":
                            list_of_people[id].citizenship = Country.Kazakhstan;
                            break;
                        case "4":
                            list_of_people[id].citizenship = Country.Other_Countries;
                            break;
                    }
                    break;

                default:
                    break;
            }
        }
        public static void Delete_Human()
        {
            Console.Clear();
            Console.WriteLine("Введите id записи, которую вы хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());
            list_of_people.Remove(id);
            Console.WriteLine("Запись успешно удалена, для продолжения работы нажмите любую клавишу:");
            Console.ReadKey();
        }

    }
}

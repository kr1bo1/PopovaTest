using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectorLib;

namespace InspectorLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Установливаю кодировку вывода на UTF-8 для русского языка
            Console.InputEncoding = Encoding.UTF8;  // Установливаю кодировку ввода на UTF-8 для русского языка

            FunctionInsp inspector = new FunctionInsp();

                // 1. Получение ФИО главного инспектора
                Console.WriteLine("Главный инспектор: " + inspector.GetInspector());

                // 2. Получение названия автоинспекции
                Console.WriteLine("Название автоинспекции: " + inspector.GetCarInspection());

                // 3. Изменение главного инспектора
                Console.Write("\nПожалуйста, введите новые инициалы главного инспектора из следующего списка сотрудников: \n Иванов И.И.\r\nЗировнов Т.А.\r\nМиронов А.В.\r\nВасильев В.И.\r\n");
                string newChief = Convert.ToString(Console.ReadLine());
                bool isChanged = inspector.SetInspector(newChief);
                Console.WriteLine($"Главный инспектор был изменён на: {newChief}: {isChanged}");

                // 4. Генерация госномера
                try
                {
                    string generatedNumber = inspector.GenerateNumber("1234", 'A', 75);
                    Console.WriteLine("\nСгенерированный номер: " + generatedNumber);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nОшибка: " + ex.Message);
                }

                // 5. Получение списка сотрудников
                Console.WriteLine("\nСписок сотрудников: ");
                foreach (var worker in inspector.GetWorker())
                {
                    Console.WriteLine(worker);
                }

                // 6. Добавление нового сотрудника
                string newWorker = Convert.ToString(Console.ReadLine());
                inspector.AddWorker(newWorker);
                Console.WriteLine($"\nБыл добавлен новый сотрудник: {newWorker}");

                // Проверка обновлнного списка сотрудников
                Console.WriteLine("\nОбновлённый список сотрудников: ");
                foreach (var worker in inspector.GetWorker())
                {
                    Console.WriteLine(worker);
                }
        }
    }
}

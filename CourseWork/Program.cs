using CourseWork.Controllers;
using CourseWork.Data;
using CourseWork.Interfaces;
using System.Security.Cryptography;
using System.Text.Json;

namespace CourseWork
{
    public delegate void Message(string message);
    class Program
    {
        public static void Main()
        {
            string user_settings_file = "user_settings.json";

            List<Room> rooms = new List<Room>();
            rooms.Add(new Room("Bedroom"));
            rooms.Add(new Room("LivingRoom"));
            rooms.Add(new Room("Wardrobe"));

            List<DataSensors> data_sensor_now = new List<DataSensors>(rooms.Count);
            for (int i = 0; i < data_sensor_now.Capacity; i++)
            {
                data_sensor_now.Add(new DataSensors());
            }

            SaveSettingToJson<UserSettings> save_settings = new SaveSettingToJson<UserSettings>();
            save_settings.Message += ConsoleMessageToUser;

            List<UserSettings> user_settings = new List<UserSettings>(rooms.Count);
            if(save_settings.GetFromFile(user_settings_file) is List<UserSettings> user_set)
            {
                user_settings = user_set;
            }

            //конструкция под рефакторинг
            ConsoleMessageToUser("If you want to change the basic settings, please enter 1");
            int choice;
            while (true) 
            { 
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    ConsoleMessageToUser("Incorrect input");
                }
            }

            if (choice == 1)
            {
                ChangeSettings set = new ChangeSettings(user_settings);
                //изменение некоторых базовых настроек
                set.SetTemperature(0, 20);
                set.SetTemperature(1, 25);
                set.SetHumidMax(1, 50);
                set.SetSecurityOn(2, 1);
                save_settings.SaveToFile(user_settings, user_settings_file);
            }
            else 
            {
                ChangeSettings set = new ChangeSettings(user_settings);
                ConsoleMessageToUser("Basic settings used");
            }
            //

            GasController gas_controller = new GasController(data_sensor_now, user_settings);
            HumidControler humid_controler = new HumidControler(data_sensor_now, user_settings);
            TemperatureControler temperature_controler = new TemperatureControler(data_sensor_now, user_settings);
            SecurityController security_controller = new SecurityController(data_sensor_now, user_settings);
            
            //переодическая проверка параметров
            TimerCallback tm = new TimerCallback(ParamHandler);
            Timer timer = new Timer(tm,null,4000,5000);

            //подписка на сообщения
            security_controller.Message += ConsoleMessageToUser;
            humid_controler.Message+= ConsoleMessageToUser;
            gas_controller.Message += ConsoleMessageToUser;
            temperature_controler.Message += ConsoleMessageToUser;
            
            //обработчик сообщений классов
            void ConsoleMessageToUser(string message)
            {
                Console.WriteLine(message);
            }
            
            //проверка датчиков
            void ParamHandler(object obj)
            {
                gas_controller.CheckParam();
                temperature_controler.CheckParam();
                humid_controler.CheckParam();
                security_controller.CheckParam();
            }
            Console.ReadLine();
        }
        
    }
}


    /*
     * Контроллеры 
     *            температуры 
     *            влажности 
     *            света
     *            газов
     *            охрана
     *            
     *            
     * Структура с входящими данными (массив или хз), возможно несколько структур
     *            температура
     *            влажность
     *            давление
     *            освещенность
     *            СО2
     *            датчик газа
     *            датчики движения
     *            
     * Структура или массив флагов для исполнительных устройств
     * 
     * Структура или массив с установленными параметрами.
     * 
     * 
     * Пользовательский интерфейс для установки желаемых параметров
     * 
     * Система оповещения о неисправностях и выхода за пределы параметров
     * 
     * Сохранение пареметров в файл при изменении настроек.
     * 
     * Абстрактный класс контроллер с базовым функцианалом для всех контроллеров
     * 
     * Интерфейсы предоставляющие методы для взаимодействия с контроллерами
     * 
     * 
     * В классе програм в бесконечном цикле, с определенной переодичностью, контроллеры считывают входящие данные со структуры, при необходимости включают/выключают исполнительные устройства.
     * 
     */


//Требования
//1.Создать консольное приложение с использованием основ ООП, логики алгоритмов, структур данных
//2. В коде должны использоваться интерфейсы, абстрактные классы, делегаты, события, обобщения, механизмы обработки исключений
//3. Разработку проекта вести с использованием сервиса Github. 
//4. Изменения в проект добавлять через создание отдельных веток
//5. Выполнять слияние ветки master с промежуточными ветками через создание Pull Request
//"6. Для выполнения Pull Request необходимо провести ревью кода. Ревьюерами назначить участников курса (2-3 человека)
//    После просмотра изменения ревьюерами можно сливать ветки."
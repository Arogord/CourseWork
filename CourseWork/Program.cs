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
            //массив текущих значений датчиков
            DataSensorsStruct[] data_sensor_now = new DataSensorsStruct[12];

            for (int i = 0; i < data_sensor_now.Length; i++)
            {
                data_sensor_now[i] = new DataSensorsStruct();
            }

            //массив настроек для каждой комнаты
            UserSettings[] user_settings = new UserSettings[12];

            string user_settings_file = "user_settings.json";

            try
            {
                using (FileStream fs = new FileStream(user_settings_file, FileMode.Open))
                {
                    //при десериализации обьекты массива инициализируются
                    user_settings = JsonSerializer.Deserialize<UserSettings[]>(fs);
                }
                Console.WriteLine("Old settings loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Maybe it is first start");
                Console.WriteLine("Default settings used");
                //инициализациия массива настроек
                for (int i = 0; i < user_settings.Length; i++)
                {
                    user_settings[i] = new UserSettings();
                }
            }

            Console.WriteLine("If you want to change the basic settings, please enter 1");
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
                    Console.WriteLine("Incorrect input");
                }
            }
            if(choice == 1)
            {
                ChangeSettings settings = new ChangeSettings(user_settings);
                //изменение некоторых базовых настроек
                settings.SetTemperature(Rooms.BoilerRoom, 20);
                settings.SetHumidMax(Rooms.Bathroom, 50);
                settings.SetSecurityOn(Rooms.Attic, 1);

                //сохранение настроек в файл
                try
                {
                    using (FileStream fs = new FileStream(user_settings_file, FileMode.OpenOrCreate))
                    {
                        JsonSerializer.Serialize(fs, user_settings);
                    }
                    Console.WriteLine("Settings saved to file");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else Console.WriteLine("Basic settings used");

            
            GasController gas_Controller = new GasController(data_sensor_now, user_settings);
            HumidControler humid_Controler = new HumidControler(data_sensor_now, user_settings);
            TemperatureControler temperature_Controler = new TemperatureControler(data_sensor_now, user_settings);
            SecurityController security_Controller = new SecurityController(data_sensor_now, user_settings);
            
            //переодическая проверка параметров
            TimerCallback tm = new TimerCallback(ParamHandler);
            Timer timer = new Timer(tm,null,1000,4000);


            //подписка через делегат
            gas_Controller.RegisterMessage(MessageToUser);
            //подписка с помощью события
            security_Controller.Message += MessageToUser;





            //обработчик сообщений классов
            void MessageToUser(string message)
            {
                Console.WriteLine(message);
            }
            
            //проверка датчиков
            void ParamHandler(object obj)
            {
                gas_Controller.CheckParam();
                temperature_Controler.CheckParam();
                humid_Controler.CheckParam();
                security_Controller.CheckParam();
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
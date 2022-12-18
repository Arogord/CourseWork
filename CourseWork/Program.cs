using CourseWork.ContactWithUser;
using CourseWork.Controllers;
using CourseWork.Data;

namespace CourseWork
{
    public delegate void Message(string message);
    class Program
    {
        public static void Main()
        {
            List<Room> rooms = new List<Room>();
            //обобщенный класс для сохранения листа обьектов
            SaveSettingToJson<Room> SaveSettings = new SaveSettingToJson<Room>();
            //класс для общения с пользователем через консоль
            ConsoleInformationWithUser UserContact = new ConsoleInformationWithUser();
            //класс для изменения настроек
            ChangeSettings settings = new ChangeSettings(UserContact);
            SaveSettings.Message += UserContact.MessageToUser;
            //Попытка десериализовать старые настройки
            if (SaveSettings.GetFromFile(Properties.Resources.FileName) is List<Room> rooms_from_file)
            {
                rooms = rooms_from_file;
            }
            CreateRooms creator = new CreateRooms(UserContact, rooms);

            CreateNewRoom();
            if (rooms.Count == 0) 
            {
                UserContact.MessageToUser("Тo rooms, program ended");
                goto END; 
            }
            ChangeSettings();
            List<DataSensors> DataSensorNow = new List<DataSensors>(rooms.Count);
            //когда будут реальные классы с входными данными, инициализируем обьекты в них
            for (int i = 0; i < DataSensorNow.Capacity; i++)
            {
                DataSensorNow.Add(new DataSensors());
                DataSensorNow[i].Name = rooms[i].Name;
            }

            GasController gasController = new GasController(DataSensorNow, rooms);
            HumidControler humidController = new HumidControler(DataSensorNow, rooms);
            TemperatureControler temperatureControler = new TemperatureControler(DataSensorNow, rooms);
            SecurityController securityController = new SecurityController(DataSensorNow, rooms);
            //переодическая проверка параметров
            TimerCallback tm = new TimerCallback(ParamHandler);
            Timer timer = new Timer(tm,null,4000,5000);
            //подписка на сообщения
            securityController.Message += UserContact.MessageToUser;
            humidController.Message+= UserContact.MessageToUser;
            gasController.Message += UserContact.MessageToUser;
            temperatureControler.Message += UserContact.MessageToUser;

            END:
            Console.ReadLine();
            void ParamHandler(object obj)
            {
                gasController.CheckParam();
                humidController.CheckParam();
                temperatureControler.CheckParam();
                securityController.CheckParam();
            }
            
            void CreateNewRoom()
            {
                try
                {
                    while (true)
                    {
                        UserContact.MessageToUser("You want to create a new room y/n?");
                        string? choice = UserContact.InfoFomUser();
                        if (choice != null && choice.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            creator.AddRoom();
                            SaveSettings.SaveToFile(rooms, Properties.Resources.FileName);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    UserContact.MessageToUser(ex.Message);
                }
            }

            void ChangeSettings()
            {
                try
                {
                    UserContact.MessageToUser("Do you want to change the default settings y/n?");
                    string? choice2 = UserContact.InfoFomUser();
                    if (choice2 != null && choice2.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (Room room in rooms)
                        {
                            settings.RoomChangeSettings(room);
                        }
                        SaveSettings.SaveToFile(rooms, Properties.Resources.FileName);
                    }
                }
                catch (Exception ex)
                {
                    UserContact.MessageToUser(ex.Message);
                }
            }

        }
        
    }
}

//Требования
//1.Создать консольное приложение с использованием основ ООП, логики алгоритмов, структур данных
//2. В коде должны использоваться интерфейсы, абстрактные классы, делегаты, события, обобщения, механизмы обработки исключений
//3. Разработку проекта вести с использованием сервиса Github. 
//4. Изменения в проект добавлять через создание отдельных веток
//5. Выполнять слияние ветки master с промежуточными ветками через создание Pull Request
//"6. Для выполнения Pull Request необходимо провести ревью кода. Ревьюерами назначить участников курса (2-3 человека)
//    После просмотра изменения ревьюерами можно сливать ветки."
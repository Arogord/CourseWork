using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourseWork.Data
{
    public class SaveSettingToJson<T> where T : class
    {

        
        public event Action<string>? Message;
        
        public void SaveToFile(List<T> obj, string user_settings_file)
        {
            try
            {
                using (FileStream fs = new FileStream(user_settings_file, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, obj);
                }
                SendMessage("Settings saved to file");
            }
            catch (Exception e)
            {
                SendMessage(e.Message);
            }
        }
        public List<T> GetFromFile(string user_settings_file)
        {
            List<T> room = null;
            try
            {
                using (FileStream fs = new FileStream(user_settings_file, FileMode.Open))
                {
                    room = JsonSerializer.Deserialize<List<T>>(fs);
                }
                SendMessage("Old settings loaded");
            }
            catch (Exception e)
            {
                SendMessage(e.Message);
                SendMessage("Maybe it is first start\nDefault settings used");
            }
            return room;
        }
        public void SendMessage(string message)
        {
            Message?.Invoke(message);
        }
    }
}

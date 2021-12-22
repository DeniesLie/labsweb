using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace DynamicMenu.Infrastructure
{
    public static class Logger
    {
        const string logPath = @"D:\VSProjects\DynamicMenu\DynamicMenuApp\DynamicMenu\Logs\";

        public static void LogAsXML(object obj)
        {
            using (FileStream fs = File.Create(logPath + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss") + "_log.xml"))
            {
                var xmlSerializer = new XmlSerializer(obj.GetType());
                xmlSerializer.Serialize(fs, obj);
            }
        }
    }
}

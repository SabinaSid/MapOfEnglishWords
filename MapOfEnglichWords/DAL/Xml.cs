using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MapOfEnglichWords.DAL
{
    public class Xml
    {
        public static XDocument Serelialize<T>(T source)
        {
            var stream = new MemoryStream();
            var ser = new XmlSerializer(typeof(T));
            ser.Serialize (stream, source);
            stream.Position = 0;
            return XDocument.Load(stream);
        }
        /// <summary>
        /// XML-десереализация объекта
        /// </summary>
        /// <typeparam name="T">Тип получаемого объекта</typeparam>
        /// <param name="source">Сереализуемый объект</param>
        /// <returns></returns>
        public static T Deserelialize<T>(XDocument source)
        {
            var stream = source.CreateReader();
            var ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(stream);
        }
        /// <summary>
        /// Загрузка объекта из XML-файла
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="path">Путь к XML-файлу</param>
        /// <returns></returns>
        public static T LoadObjectFromFile<T>(string path)
        {
            var xml = XDocument.Load(path);
            return Deserelialize<T>(xml);
        }
        /// <summary>
        /// Загрузка объекта из XML-строки
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="textXml">XML в виде строки</param>
        /// <returns></returns>
        public static T LoadObjectFromString<T>(string textXml)
        {
            var xml = XDocument.Parse(textXml);
            return Deserelialize<T>(xml);
        }
    }
}

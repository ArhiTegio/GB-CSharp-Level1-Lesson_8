using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _2_WinBelieveUnbelievers
{
    class Save_Load
    {
        /// <summary>
        /// Сохранить в формат XML
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public static void SaveAsXmlFormat(Question obj, string fileName)
        {
            // Сохранить объект класса Student в файле fileName в формате XML
            // typeof(Student) передает в XmlSerializer данные о классе.
            // Внутри метода Serialize происходит большая работа по постройке
            // графа зависимостей для последующего создания xml-файла.
            // Процесс получения данных о структуре объекта называется рефлексией.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Question));
            // Создаем файловый поток(проще говоря, создаем файл)
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            // В этот поток записываем сериализованные данные(записываем xml-файл)
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }

        /// <summary>
        /// Загрузить в формат XML
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public static Question LoadFromXmlFormat(string fileName)
        {
            // Считать объект Student из файла fileName формата XML
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Question));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var obj = (xmlFormat.Deserialize(fStream) as Question);
            fStream.Close();
            return obj;
        }

        /// <summary>
        /// Сохранить коллекцию в формат XML
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public static void SaveAsXmlCollectionFormat(List<Question> obj, string fileName)
        {
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write); ;
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                xmlFormat.Serialize(fStream, obj);
                fStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при записе. {e.Message}", "Проблемы?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fStream.Close();
            }

        }

        /// <summary>
        ///  Загрузить коллекцию в формат XML
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Question> LoadFromXmlCollectionFormat(string fileName)
        {
            List<Question> obj = new List<Question>();
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                obj = (xmlFormat.Deserialize(fStream) as List<Question>);
                fStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при чтении. {e.Message}", "Проблемы?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fStream.Close();
            }
            return obj;
        }

        /// <summary>
        /// Конвертировать из формата CSV в XML
        /// </summary>
        /// <param name="fileName"></param>
        public static void ConvertCSVtoXML(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            var xml = new XElement("TopElement",
               lines.Select(line => new XElement("Item",
                  line.Split(';')
                      .Select((column, index) => new XElement("Column" + index, column)))));

            xml.Save($"{fileName}.xml");
        }
    }


}

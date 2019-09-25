﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lesson8_1
{
    class Save_Load
    {
        public static void SaveAsXmlFormat(CityModel obj, string fileName)
        {
            // Сохранить объект класса Student в файле fileName в формате XML
            // typeof(Student) передает в XmlSerializer данные о классе.
            // Внутри метода Serialize происходит большая работа по постройке
            // графа зависимостей для последующего создания xml-файла.
            // Процесс получения данных о структуре объекта называется рефлексией.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(CityModel));
            // Создаем файловый поток(проще говоря, создаем файл)
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            // В этот поток записываем сериализованные данные(записываем xml-файл)
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }
        public static CityModel LoadFromXmlFormat(string fileName)
        {
            // Считать объект Student из файла fileName формата XML
            XmlSerializer xmlFormat = new XmlSerializer(typeof(CityModel));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var obj = (xmlFormat.Deserialize(fStream) as CityModel);
            fStream.Close();
            return obj;
        }
        public static void SaveAsXmlCollectionFormat(List<CityModel> obj, string fileName)
        {
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write); ;
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CityModel>));
                xmlFormat.Serialize(fStream, obj);
                fStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при записе. {e.Message}", "Проблемы?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fStream.Close();
            }

        }
        public static List<CityModel> LoadFromXmlCollectionFormat(string fileName)
        {
            List<CityModel> obj = new List<CityModel>();
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CityModel>));
                obj = (xmlFormat.Deserialize(fStream) as List<CityModel>);
                fStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при чтении. {e.Message}", "Проблемы?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fStream.Close();
            }
            return obj;
        }

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

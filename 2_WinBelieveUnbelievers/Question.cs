using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace _2_WinBelieveUnbelievers
{
    // Класс для вопроса    
    [Serializable]
    public class Question
    {
        public string text;       // Текст вопроса
        public bool trueFalse;// Правда или нет
                              // Здесь мы нарушаем правила инкапсуляции и эти поля нужно было бы реализовать через открытые свойства, но для упрощения примера оставим так
                              // Вам же предлагается сделать поля закрытыми и реализовать открытые свойства Text и TrueFalse
                              // Для сериализации должен быть пустой конструктор.
        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }
    }
    // Класс для хранения списка вопросов. А также для сериализации в XML и десериализации из XML
    public class TrueFalse
    {
        string fileName;
        List<Question> list;
        public string FileName
        {
            set { fileName = value; }
        }

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        /// <summary>
        /// Добавить вопрос
        /// </summary>
        /// <param name="text"></param>
        /// <param name="trueFalse"></param>
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        /// <summary>
        /// Убрать по индексу
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        /// <summary>
        /// Индексатор - свойство для доступа к закрытому объекту
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Question this[int index]
        {
            get { return list[index]; }
        }


        /// <summary>
        /// Сохранить вопросы
        /// </summary>
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        /// <summary>
        /// Загрузить вопросы
        /// </summary>
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

        /// <summary>
        /// Количество вопросов
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }

        /// <summary>
        /// Перечислитель вопросов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Question> GetAllQuestuon()
        {
            foreach (var t in list)            
                yield return t;
            
            yield break;
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_WinBelieveUnbelievers
{
    class BelieveUnbelievers
    {
        public Dictionary<string, string> answer = new Dictionary<string, string>();
        public BelieveUnbelievers()
        {
            if (File.Exists(@"Answer.txt"))
            {
                StreamReader sr = new StreamReader(@"Answer.txt");
                try
                {
                    while (true)
                    {
                        var t = sr.ReadLine();
                        if (t != null)
                        {
                            var t2 = t.Split('|');
                            if (!answer.ContainsKey(t2[0]))
                                answer.Add(t2[0], t2[1]);
                        }
                        else
                            break;
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при загрузки файла");
                    sr.Close();
                }
            }
        }
        /// <summary>
        /// Получить перерчислитель вопросов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Tuple<string, string>> Question()
        {
            foreach (var n in answer)
            {
                yield return Tuple.Create(n.Key, n.Value);
            }
        }
    }
}

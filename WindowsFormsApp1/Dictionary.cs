using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp1
{
    [Serializable]
    class Dictionary
    {
        ArrayList words;

        public Dictionary()
        {
            Words = new ArrayList();
        }

        public ArrayList Words { get => words; set => words = value; }

        public void Add(Words word)
        {
            Words.Add(word);
        }

        public override string ToString()
        {
            String result = "";
            foreach (Words word in words)
            {
                result += word.ToString() + "\n";
            }

            return result;
        }

        public void Save(String filename)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, this);
                }
                catch (Exception exc)
                {

                }
            }
        }

        public void Load(String filename)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();

            // десериализация из файла
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                try
                {
                    this.words = ((Dictionary)(formatter.Deserialize(fs))).words;
                }
                catch (Exception exc)
                {

                } 
            }
        }
    }
}

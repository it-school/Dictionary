using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Dictionary dictionary;
        public Form1()
        {
            InitializeComponent();
            dictionary = new Dictionary();
            dictionary.Add(new Words("красный", Parts.прилагательное));
            dictionary.Add(new Words("жёлтый", Parts.прилагательное));
            dictionary.Add(new Words("зелёный", Parts.прилагательное));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //            MessageBox.Show(textBox1.Text);
            StringBuilder s = new StringBuilder(textBox1.Text);
            char c;
            for (int i = 0; i < s.Length / 2; i++)
            {
                c = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = c;
            }
            
                  /*                 
                       Array array = s.ToArray();
                       Array.Reverse(array);
                       s = array.
               */
                
            label1.Text = s.ToString();
        } 
        
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            ArrayList words = new ArrayList();
            String s = "123,45", s1="";
            double d = Convert.ToDouble(s) + 10;
            for (int i = 0; i < s.Length; i++)
            {
                s1 += ((int)s[i]).ToString();
            }
            MessageBox.Show(s1);
            */
            richTextBox1.Clear();
            richTextBox1.Text = dictionary.ToString();

            MessageBox.Show("Test");

            ((Words)dictionary.Words[0]).Word = "Монитор";
            ((Words)dictionary.Words[0]).Part = Parts.существительное;

            richTextBox1.Clear();
            richTextBox1.Text = dictionary.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("d:\\word.txt", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, ((Words)(dictionary.Words[0])));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                MessageBox.Show("Serialized");
            }

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream(@"d:\word.txt", FileMode.OpenOrCreate))
            {
                Words newWord = (Words)formatter.Deserialize(fs);

                MessageBox.Show($"Слово: {newWord.Word} --- Часть речи: {newWord.Part.ToString()}" );
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dictionary.Save(@"d:\dictionary.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dictionary.Words.Clear();
            dictionary.Load(@"d:\dictionary.txt");
            richTextBox1.Text = dictionary.ToString();
        }
    }
}

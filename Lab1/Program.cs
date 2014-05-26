using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace BinaryFile2
{
    [Serializable]
    class Student
    {
        private string Name;
        private string Subject;
        private int Score;

        public Student(string Name, string Subject, int Score)
        {
            this.Name = Name;
            this.Subject = Subject;
            this.Score = Score;
        }

        public string GetName()
        {
            return Name;
        }
        public string GetSubject()
        {
            return Subject;
        }
        public int GetScore()
        {
            return Score;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Stream ws = new FileStream("a.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            ArrayList students = new ArrayList();
            string name;
            string subject;
            int score;
            for (string answer = ""; answer != "n"; )
            {
                Console.Write("이름: ");
                name = Console.ReadLine();
                Console.Write("과목: ");
                subject = Console.ReadLine();
                Console.Write("성적: ");
                score = Convert.ToInt32(Console.ReadLine());
                students.Add(new Student(name, subject, score));
                Console.Write("더 입력하시겠습니까? ");
                answer = Console.ReadLine();
                if (answer == "n")
                {
                    serializer.Serialize(ws, students);
                    ws.Close();
                    Stream rs = new FileStream("a.dat", FileMode.Open);
                    BinaryFormatter deserializer = new BinaryFormatter();

                    students = (ArrayList)deserializer.Deserialize(rs);
                    foreach (Student student in students)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", student.GetName(), student.GetSubject(), student.GetScore());
                    }
                    rs.Close();
                    break;
                }
            }
        }
    }
}

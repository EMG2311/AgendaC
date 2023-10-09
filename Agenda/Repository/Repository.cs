using Agenda.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Agenda.Repository
{
    public class Repository : IRepository
    {
        private readonly string FilePath;
        private readonly string TempFilePath;
        public Repository() {
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Agenda.txt");
            TempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Agenda.tmp");
        }

        public List<Student> ListStudents()
        {
            List<Student> Students = new List<Student>();
            try
            {
                CheckFileExistence(FilePath);
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string record = string.Empty;
                    while ((record = reader.ReadLine()) != null)
                    {
                        Student Student = JsonConvert.DeserializeObject<Student>(record);
                        if (Student.Active==true) {
                            Students.Add(Student);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return Students;
        }

        public void SaveStudent(Student student)
        {
            if (ShowStudent(student.DNI) == null || ShowStudent(student.DNI).Active== false)
            {
                Student studentCreate = student;
                studentCreate.SetActive(true);
                string studentString = JsonConvert.SerializeObject(studentCreate);
                InsertRecord(studentString);

            }
            else
            {
                throw new Exception();
            }



        }
        public bool InsertRecord(string record)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(record);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            return true;
        }

        public Student ShowStudent(int dni)
        {
            try
            {
                CheckFileExistence(FilePath);

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    Student StudentAux=new Student();
                    
                    string record = string.Empty;
                    while ((record = reader.ReadLine()) != null)
                    {
                        Student Student = JsonConvert.DeserializeObject<Student>(record);
                        if (Student.GetDNI()== dni)
                        {
                            StudentAux = Student;
                        }
                    }
                    reader.Close();
                    return StudentAux;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            
        }

        public Student updateStudent(Student Student)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string record = string.Empty;
                using (StreamWriter writer = new StreamWriter(TempFilePath))
                { 
                    while ((record = reader.ReadLine()) != null)
                {
                    
                        Student Student1 = JsonConvert.DeserializeObject<Student>(record);

                        if (Student.DNI == Student1.DNI && Student1.Active==true)
                        {
                            string newRecord = JsonConvert.SerializeObject(Student);
                            writer.WriteLine(newRecord);
                        }
                        else
                        {
                            writer.WriteLine(record);
                        }

                        
                    }
                    writer.Close();
                }

                reader.Close();

                bool removed = RemoveFile(FilePath);
                if (removed)
                {
                    RenameFile();
                }

            }

            return Student;
        }

        public bool DeleteStudent(int dni)
        {

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string record = string.Empty;
                while ((record = reader.ReadLine()) != null)
                {
                    Student Student = JsonConvert.DeserializeObject<Student>(record);
                    if (Student.DNI != dni)
                    {
                        using (StreamWriter writer = new StreamWriter(TempFilePath))
                        {
                            writer.WriteLine(record);
                            writer.Close();
                        }
                    }
                }

                reader.Close();

                bool removed = RemoveFile(FilePath);
                if (removed)
                {
                    RenameFile();
                }
            }

            return true;
        }


       




    private void CheckFileExistence(string path)
    {
        bool exist = FileExist(path);
        if (!exist)
        {
            throw new FileNotFoundException();
        }
    }

    private bool FileExist(string path)
    {
        bool exist = File.Exists(path);

        return exist;
    }

    private bool RemoveFile(string path)
    {
        bool exist = FileExist(path);

        if (exist)
        {
            File.Delete(path);
        }

        return exist;
    }

    private void RenameFile()
    {
        File.Move(TempFilePath, FilePath,true);
    }
}
}

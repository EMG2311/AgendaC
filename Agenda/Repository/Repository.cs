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
        public bool DeleteAlumno(int dni)
        {
            return true;
        }

        public List<Alumno> ListAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                CheckFileExistence(FilePath);
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string record = string.Empty;
                    while ((record = reader.ReadLine()) != null)
                    {
                        Alumno alumno = JsonConvert.DeserializeObject<Alumno>(record);
                        if (alumno.Active==true) {
                            alumnos.Add(alumno);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return alumnos;
        }

        public void SaveAlumno(Alumno student)
        {
            if (ShowAlumno(student.DNI) == null || ShowAlumno(student.DNI).Active== false)
            {
                Alumno studentCreate = student;
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

        public Alumno ShowAlumno(int dni)
        {
            try
            {
                CheckFileExistence(FilePath);

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    Alumno alumnoAux=new Alumno();
                    
                    string record = string.Empty;
                    while ((record = reader.ReadLine()) != null)
                    {
                        Alumno alumno = JsonConvert.DeserializeObject<Alumno>(record);
                        if (alumno.GetDNI()== dni)
                        {
                            alumnoAux = alumno;
                        }
                    }
                    reader.Close();
                    return alumnoAux;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            
        }

        public Alumno updateAlumno(Alumno alumno)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string record = string.Empty;
                using (StreamWriter writer = new StreamWriter(TempFilePath))
                { 
                    while ((record = reader.ReadLine()) != null)
                {
                    
                        Alumno Alumno1 = JsonConvert.DeserializeObject<Alumno>(record);

                        if (alumno.DNI == Alumno1.DNI && Alumno1.Active==true)
                        {
                            string newRecord = JsonConvert.SerializeObject(alumno);
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

            return alumno;
        }

        public bool DeleteRecord(int dni)
        {

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string record = string.Empty;
                while ((record = reader.ReadLine()) != null)
                {
                    Alumno alumno = JsonConvert.DeserializeObject<Alumno>(record);
                    if (alumno.DNI != dni)
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

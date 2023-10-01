using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repository
{


    /// <summary> 
    /// Representa una clase administradora del archivo de la agenda
    /// </summary>
    public class FileManager
    {
        private readonly string FilePath;
        private readonly string TempFilePath;

        public FileManager()
        {
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Agenda.txt");
            TempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Agenda.tmp");
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

        public bool DeleteRecord(string identifier)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string record = string.Empty;
                while ((record = reader.ReadLine()) != null)
                {
                    FileData data = JsonConvert.DeserializeObject<FileData>(record);
                    if (data.Nombre.Trim() != identifier.Trim())
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

        public FileData GetRecord(string identifier)
        {
            try
            {
                CheckFileExistence(FilePath);

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string record = string.Empty;
                    while ((record = reader.ReadLine()) != null)
                    {
                        FileData data = JsonConvert.DeserializeObject<FileData>(record);
                        if (data.Nombre.Trim() == identifier.Trim())
                        {
                            return data;
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            return null;
        }

        public bool UpdateRecord(FileData newData)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string record = string.Empty;
                while ((record = reader.ReadLine()) != null)
                {
                    using (StreamWriter writer = new StreamWriter(TempFilePath))
                    {
                        FileData data = JsonConvert.DeserializeObject<FileData>(record);

                        if (data.Nombre.Trim() == newData.Nombre.Trim())
                        {
                            string newRecord = JsonConvert.SerializeObject(newData);
                            writer.WriteLine(newRecord);
                        }
                        else
                        {
                            writer.WriteLine(record);
                        }

                        writer.Close();
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
            File.Move(TempFilePath, FilePath);
        }
    }
}

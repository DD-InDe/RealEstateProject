using System.Diagnostics;
using System.IO;
using System.Windows.Documents;
using Microsoft.Win32;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Enums;
using File = System.IO.File;

namespace RealtorSystemDesk.Services;

public abstract class FileService
{
    // private const string ServerPath = @"C:\Users\alena\OneDrive\Desktop\real_estate_project\server_files";
    private const string ServerPath = @"../../../server_files";

    public static void DownloadFile(string fileName)
    {
        try
        {
            SaveFileDialog dialog = new() { FileName = fileName };
            string savePath = String.Empty;
            if (dialog.ShowDialog() == true)
                savePath = dialog.FileName;


            string filePath = Path.Combine(ServerPath, App.AuthorizedUser.Login, fileName);
            if (File.Exists(filePath))
            {
                File.Copy(filePath, savePath);
                MessageService.ShowOk("Файл сохранен!");
                new Process()
                {
                    StartInfo = new(savePath)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
            else
                throw new Exception("Файл не был найден!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }

    public static int UploadFile(FileOption option)
    {
        try
        {
            OpenFileDialog dialog = new();
            if (option == FileOption.Document)
                dialog.Filter = "documents |*.docx; *.doc; *.pdf; *.xlsx;";
            if (option == FileOption.Image)
                dialog.Filter = "images |*.jpeg; *.jpg; *.png";

            Database.File file = new();
            if (dialog.ShowDialog() == true)
            {
                file.FileName = dialog.SafeFileName;

                string directory = Path.Combine(ServerPath, App.AuthorizedUser.Login);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string newFilePath = Path.Combine(directory, file.FileName);
                if (File.Exists(newFilePath)) File.Delete(newFilePath);
                File.Copy(dialog.FileName, newFilePath);

                Db.Context.Files.Add(file);
                DatabaseSaveService.SaveWithMessage("Файл добавлен!");
                return file.Id;
            }
        }
        catch (IOException ioException)
        {
            Console.WriteLine(ioException.Message);
            MessageService.ShowError(new("Данные файл уже существует!"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }

        return 0;
    }

    public static void DeleteFile(Database.File file)
    {
        try
        {
            string directory = Path.Combine(ServerPath, App.AuthorizedUser.Login, file.FileName);
            if (File.Exists(directory))
                File.Delete(directory);
            Db.Context.Files.Remove(file);
            DatabaseSaveService.SaveWithMessage("Файл удален!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }
}
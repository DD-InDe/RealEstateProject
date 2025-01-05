using System.Diagnostics;
using System.IO;
using System.Windows.Documents;
using Microsoft.Win32;
using RealtorSystemDesk.Database;

namespace RealtorSystemDesk.Services;

public class FileService
{
    private const string ServerPath = @"C:\Users\alena\OneDrive\Desktop\real_estate_project\server_files";

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

    public static int UploadFile()
    {
        try
        {
            Document document = new();
            OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                document.FileName = dialog.SafeFileName;

                string directory = Path.Combine(ServerPath, App.AuthorizedUser.Login);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string newFilePath = Path.Combine(directory, document.FileName);
                if (File.Exists(newFilePath)) File.Delete(newFilePath);
                File.Copy(dialog.FileName, newFilePath);

                Db.Context.Documents.Add(document);
                DatabaseSaveService.SaveWithMessage("Файл добавлен!");
                return document.Id;
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
}
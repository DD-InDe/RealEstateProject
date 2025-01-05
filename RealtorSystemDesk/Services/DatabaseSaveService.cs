using RealtorSystemDesk.Database;

namespace RealtorSystemDesk.Services;

public class DatabaseSaveService
{
    public static void SaveWithMessage(string message = "Данные сохранены!")
    {
        if (Db.Context.SaveChanges() > 0)
            MessageService.ShowOk(message);
        else
            MessageService.ShowError(new Exception("При сохранении данных произошла ошибка."));
    }
}
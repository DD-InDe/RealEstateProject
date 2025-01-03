using System.Windows;

namespace RealtorSystemDesk.Services;

public class MessageService
{
    public static void ShowOk(string message) =>
        MessageBox.Show(message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Asterisk);

    public static void ShowError(Exception exception) =>
        MessageBox.Show($"Произошла ошибка: {exception.Message}", "Ошибка", MessageBoxButton.OK,
            MessageBoxImage.Error);

    public static void ShowInfo(string message) =>
        MessageBox.Show(message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

    public static bool GetConfirm(string message) =>
        MessageBox.Show(message, "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) ==
        MessageBoxResult.Yes;
}
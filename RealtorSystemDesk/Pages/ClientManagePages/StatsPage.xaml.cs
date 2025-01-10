using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Models;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages.ClientManagePages;

public partial class StatsPage : Page
{
    public StatsPage()
    {
        InitializeComponent();
    }

    private void DisplayButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            List<Contract> contracts = new();

            if (AllCheckBox.IsChecked ?? false)
                contracts.AddRange(Db.Context.Contracts
                    .Include(c => c.Client)
                    .Include(c => c.Type)
                    .Where(c => c.Client.UserId == App.AuthorizedUser.Id).ToList());
            else
            {
                if (StartDatePicker.SelectedDate != null && EndDatePicker.SelectedDate != null)
                {
                    if (StartDatePicker.SelectedDate > EndDatePicker.SelectedDate)
                    {
                        contracts.AddRange(Db.Context.Contracts
                            .Include(c => c.Client)
                            .Include(c => c.Type)
                            .Where(c => c.Client.UserId == App.AuthorizedUser.Id &&
                                        c.DateCreate >= DateOnly.FromDateTime(StartDatePicker.SelectedDate.Value) &&
                                        c.DateCreate <= DateOnly.FromDateTime(EndDatePicker.SelectedDate.Value))
                            .ToList());
                    }
                    else
                    {
                        MessageService.ShowInfo("Начальная дата не может быть больше конечной!");
                        return;
                    }
                }
                else
                {
                    MessageService.ShowInfo("Выберите диапазон дат");
                    return;
                }
            }

            List<PieSeries> pieSeries = new();
            var groupedList = contracts.GroupBy(c => c.Type).ToList();
            foreach (var grouping in groupedList)
            {
                pieSeries.Add(new PieSeries()
                {
                    Title = grouping.Key.Name,
                    Values = new ChartValues<int> { grouping.Count() }
                });
            }

            PieChart.Series.Clear();
            PieChart.Series.AddRange(pieSeries);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }
}
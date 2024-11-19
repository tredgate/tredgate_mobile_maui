using System.Collections.ObjectModel;


namespace TredgateMauiTestingApp;


public partial class MainPage : ContentPage
{
    public ObservableCollection<TaskItem> Tasks { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnAddTask(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
        {
            var newTask = new TaskItem
            {
                Name = TaskEntry.Text,
                Deadline = DeadlinePicker.Date,
                Priority = PriorityPicker.SelectedItem?.ToString() ?? "Střední"
            };
            Tasks.Add(newTask);
            TaskEntry.Text = string.Empty;
            DeadlinePicker.Date = DateTime.Today;
            PriorityPicker.SelectedIndex = -1;
        }
    }

    private void OnDeleteTask(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is TaskItem task)
        {
            Tasks.Remove(task);
        }
    }

    private async void OnEditTask(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is TaskItem task)
        {
            // Zobrazíme modální stránku pro úpravu úkolu
            var editPage = new EditTaskPage(task);
            await Navigation.PushAsync(editPage);
        }
    }

    private async void OnOpenWebView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WebViewPage());
    }

}

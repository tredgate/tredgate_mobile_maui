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
			Tasks.Add(new TaskItem { Name = TaskEntry.Text });
			TaskEntry.Text = string.Empty;
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
			string result = await DisplayPromptAsync("Upravit úkol", "Změňte název úkolu:", initialValue: task.Name);
			if (!string.IsNullOrWhiteSpace(result))
			{
				task.Name = result;
				// Aktualizace seznamu
				int index = Tasks.IndexOf(task);
				Tasks.Remove(task);
				Tasks.Insert(index, task);
			}
		}
	}
}

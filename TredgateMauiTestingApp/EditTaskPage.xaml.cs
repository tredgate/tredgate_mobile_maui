namespace TredgateMauiTestingApp;

public partial class EditTaskPage : ContentPage
{
    public TaskItem Task { get; set; }

    public EditTaskPage(TaskItem task)
    {
        InitializeComponent();
        Task = task;
        BindingContext = this;
    }

    private async void OnSave(object sender, EventArgs e)
    {
        // Zde se změny automaticky projeví díky BindingContext
        await Navigation.PopAsync();
    }

    private async void OnCancel(object sender, EventArgs e)
    {
        // Vrátíme se bez uložení změn
        await Navigation.PopAsync();
    }
}

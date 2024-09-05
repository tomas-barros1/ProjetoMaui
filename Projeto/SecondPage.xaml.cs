namespace Projeto;

public partial class SecondPage : ContentPage
{

   

	public SecondPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ThirdPage());
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string userName = Name.Text;
        string userEmail = Email.Text;
        string userPassword = Password.Text;
        string confirmPassword = ConfirmPassword.Text;

        if (!IsValidEmail(userEmail))
        {
            await DisplayAlert("Error", "Please enter a valid email address.", "OK");
            return;
        }

        if (userPassword != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(userPassword) || userPassword.Length < 6)
        {
            await DisplayAlert("Error", "Password must be at least 6 characters long.", "OK");
            return;
        }

        try
        {
            await SecureStorage.Default.SetAsync("user_name", userName);
            await SecureStorage.Default.SetAsync("user_email", userEmail);
            await SecureStorage.Default.SetAsync("user_password", userPassword); 
            await Navigation.PushAsync(new ThirdPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred while saving data: {ex.Message}", "OK");
        }

    }
}
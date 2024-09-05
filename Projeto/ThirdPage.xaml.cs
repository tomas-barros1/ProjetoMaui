namespace Projeto;

public partial class ThirdPage : ContentPage
{
	public ThirdPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string userEmail = Email.Text;
        string userPassword = Password.Text;

        if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(userPassword))
        {
            await DisplayAlert("Error", "Email and password cannot be empty", "OK");
            return;
        }

        string savedEmail = await SecureStorage.Default.GetAsync("user_email");
        string savedPassword = await SecureStorage.Default.GetAsync("user_password");

        if (savedEmail == null || savedPassword == null)
        {
            await DisplayAlert("Error", "No user data found", "OK");
            return;
        }

        if (userEmail == savedEmail)
        {
            if (userPassword == savedPassword)
            {
                await Navigation.PushAsync(new FourthPage());
            }
            else
            {
                await DisplayAlert("Error", "Wrong password", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Wrong email", "OK");
        }

    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new SecondPage());
    }
}
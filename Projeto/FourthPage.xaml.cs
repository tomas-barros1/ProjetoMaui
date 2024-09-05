namespace Projeto;

public partial class FourthPage : ContentPage
{

	public async void getUsername()
	{
		string usernameVar = await SecureStorage.GetAsync("user_name");
		Username.Text = usernameVar;
    }


	public FourthPage()
	{
		getUsername();
		InitializeComponent();
	}

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = sender as CheckBox;

        if (e.Value) 
        {
            checkBox.Color = Color.FromArgb("#50C2C9"); 
        }
        else
        {
            return;
            //checkBox.Color = Color.FromArgb("#000000"); 
        }
    }
}




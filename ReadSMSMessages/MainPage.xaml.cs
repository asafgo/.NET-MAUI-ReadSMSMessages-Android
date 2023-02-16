namespace ReadSMSMessages;

public partial class MainPage : ContentPage
{
    private readonly IMyReadSMS myReadSMS;
    int count = 0;

	public MainPage(IMyReadSMS _myReadSMS)
	{
		InitializeComponent();
        myReadSMS = _myReadSMS;

        //var a = myReadSMS.RequestPermissions();
        //var b = myReadSMS.getAllSms();
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        //count++;

        //if (count == 1)
        //	CounterBtn.Text = $"Clicked {count} time";
        //else
        //	CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);


        var a = await myReadSMS.RequestPermissions();

        var b = await myReadSMS.getAllSms();

    }
}


using BatShared.Clients;

namespace Batmobile
{
    public partial class MainPage : ContentPage
    {
        RpmClient client;

        public MainPage()
        {
            InitializeComponent();

            client = new RpmClient();

            BindingContext = client;
        }
    }
}
using BatShared.Clients;

namespace Batcave
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
using System.Text;

namespace MyApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
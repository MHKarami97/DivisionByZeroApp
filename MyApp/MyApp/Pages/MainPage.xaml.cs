using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;

namespace MyApp.Pages
{
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail)]
    public partial class MainPage : MvxContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
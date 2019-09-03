using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;

namespace MyApp.Pages
{
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false)]
    public partial class MasterPage : MvxContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }
    }
}
using System;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;

namespace MyApp.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false)]
    public partial class RootPage : MvxMasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();

            IsPresentedChanged += RootPage_IsPresentedChanged;
        }

        private void RootPage_IsPresentedChanged(object sender, EventArgs e)
        {
        }
    }
}
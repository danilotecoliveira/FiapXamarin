using Xamarin.Forms;
using XF.AplicativoFIAP.ViewModel;

namespace XF.AplicativoFIAP
{
    public partial class MainPage : ContentPage
    {
        private ProfessorViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel = new ProfessorViewModel();
            BindingContext = ViewModel;

            MessagingCenter.Subscribe<string>(this, "NovoProfessor", (msg) =>
            {
                Navigation.PushAsync(new View.NovoProfessorView());
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<string>(this, "NovoProfessor");
        }
    }
}

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.Model;

namespace XF.LocalDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        //private LoginViewModel vmLogin;

        public LoginView()
        {
            InitializeComponent();
            //vmLogin = new LoginViewModel();
        }

        //private void btnEntrar_Clicked(object sender, EventArgs e)
        //{
        //    vmLogin.Usuario = txtUsuario.Text;
        //    vmLogin.Senha = txtSenha.Text;

        //    if (vmLogin.ValidaLogin())
        //        MessagingCenter.Send(new Login(), "SucessoLogin");
        //    else
        //        DisplayAlert("Login", "Digite um usuário e senha válidos", "Ok");
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Login>(this, "FalhaLogin", async (ex) =>
            {
                await DisplayAlert("Login", "Falha", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Login>(this, "FalhaLoain");
        }
    }
}
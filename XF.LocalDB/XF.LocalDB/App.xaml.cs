using Xamarin.Forms;
using XF.LocalDB.Model;

namespace XF.LocalDB
{
    public partial class App : Application
    {
        static Aluno alunoModel;
        public static Aluno AlunoModel
        {
            get
            {
                if (alunoModel == null)
                {
                    alunoModel = new Aluno();
                }
                return alunoModel;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Login>(this, "SucessoLogin", (msg) =>
            {
                MainPage = new NavigationPage(new View.MainPage());
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

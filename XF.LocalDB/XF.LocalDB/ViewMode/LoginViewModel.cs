using System.Windows.Input;
using Xamarin.Forms;
using XF.LocalDB.Model;

namespace XF.LocalDB.ViewMode
{
    public class LoginViewModel
    {
        //public LoginViewModel() { }

        //public string Usuario { get; set; }
        //public string Senha { get; set; }

        //public bool ValidaLogin()
        //{
        //    try
        //    {
        //        var login = new Login();
        //        return login.ValidarLogin(Usuario, Senha);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(() =>
            {
                var login = new Login(usuario, senha);

                if (login.ValidarLogin())
                    MessagingCenter.Send(login, "SucessoLogin");
                else
                    MessagingCenter.Send(login, "FalhaLogin");
            });
        }
    }
}

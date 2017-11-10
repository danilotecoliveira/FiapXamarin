using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.Views;

namespace XF.MVVMBasic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            var Alunos = new List<Aluno>
            {
                new Aluno {
                    Id = Guid.NewGuid(),
                    RM = "542621",
                    Nome = "Anderson Silva",
                    Email = "anderson@ufc.com"
                }
            };

            MainPage = new NavigationPage(new AlunoView(Alunos));
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

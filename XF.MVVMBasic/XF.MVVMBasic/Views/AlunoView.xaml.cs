using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.ViewModel;

namespace XF.MVVMBasic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlunoView : ContentPage
    {
        private AlunoViewModel ViewModel { get; set; }

        public AlunoView(List<Aluno> alunos)
        {
            InitializeComponent();
            ViewModel = new AlunoViewModel(alunos);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<List<Aluno>>(this, "FormularioAluno",
                async (alunos) =>
                {
                    var aluno = new Aluno();
                    await Navigation.PushAsync(new NovoAlunoView(alunos, aluno));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Aluno>(this, "FormularioAluno");
        }
    }
}
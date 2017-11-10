using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.ViewModel;

namespace XF.MVVMBasic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlunoView : ContentPage
    {
        public NovoAlunoViewModel vmNovoAluno { get; set; }

        public NovoAlunoView(List<Aluno> alunos, Aluno aluno)
        {
            InitializeComponent();
            vmNovoAluno = new NovoAlunoViewModel(alunos, aluno);
            BindingContext = vmNovoAluno;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<List<Aluno>>(this, "CadastrarAluno",
                async (alunos) =>
                {
                    await DisplayAlert("Sucesso", "Aluno cadastrado com sucesso", "Ok");
                    await Navigation.PushAsync(new AlunoView(alunos));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<List<Aluno>>(this, "CadastrarAluno");
        }
    }
}
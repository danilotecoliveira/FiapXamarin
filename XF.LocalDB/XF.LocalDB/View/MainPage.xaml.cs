using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.ViewMode;

namespace XF.LocalDB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        AlunoViewModel vmAluno;

        public MainPage()
        {
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;
            lstAlunos.ItemsSource = App.AlunoModel.GetAlunos().OrderBy(c => c.Nome);
            base.OnAppearing();
        }

        private void OnNovo(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NovoAlunoView());
        }

        private void OnAlunoTapped(object sender, ItemTappedEventArgs args)
        {
            var selecionado = args.Item as Model.Aluno;
            Navigation.PushAsync(new NovoAlunoView(selecionado.Id));
        }

        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            var id = (int)((Button)sender).CommandParameter;

            var confirma = await DisplayAlert("Excluir", "Deseja excluir este registro?", "Sim", "Não");

            if (confirma)
            {
                App.AlunoModel.RemoverAluno(id);
                lstAlunos.ItemsSource = App.AlunoModel.GetAlunos().OrderBy(c => c.Nome);
            }
        }
    }
}
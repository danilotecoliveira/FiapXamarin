using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.Model;

namespace XF.Contatos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContatosView : ContentPage
    {
        public ContatosView()
        {
            var lista = new List<Contato>
            {
                new Contato { Nome = "João", Telefone = "011997721454" },
                new Contato { Nome = "Maria", Telefone = "02101213215" },
                new Contato { Nome = "Ana", Telefone = "01126364545" }
            };

            listaContatos.ItemsSource = lista;
            InitializeComponent();
        }
    }
}
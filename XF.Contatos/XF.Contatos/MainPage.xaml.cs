using Xamarin.Forms;
using XF.Contatos.View;

namespace XF.Contatos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ContatosView());
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FotoView());
        }

        private void Button_Clicked_2(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapaView());
        }
    }
}

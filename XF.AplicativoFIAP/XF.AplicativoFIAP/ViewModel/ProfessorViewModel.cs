using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using XF.AplicativoFIAP.Model;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace XF.AplicativoFIAP.ViewModel
{
    public class ProfessorViewModel : INotifyPropertyChanged
    {
        public ICommand NovoProfessor { get; private set; }
        private List<Professor> professores;

        public List<Professor> Professores
        {
            get { return professores; }
            set { professores = value; }
        }

        public ProfessorViewModel()
        {
            professores = new List<Professor>();
            Professores = GetProfessoresSqlAzureAsync();
            CopiaListaAlunos = new List<Professor>();
            CopiaListaAlunos = Professores;

            NovoProfessor = new Command(() =>
            {
                MessagingCenter.Send("NovoProfessor", "NovoProfessor");
            });
        }

        public List<Professor> GetProfessoresSqlAzureAsync()
        {
            return ProfessorRepository.GetProfessoresSqlAzureAsync();
        }


        private Professor selecionado;
        public Professor Selecionado
        {
            get { return selecionado; }
            set
            {
                selecionado = value as Professor;
                EventPropertyChanged();
            }
        }

        private string pesquisaPorNome;
        public string PesquisaPorNome
        {
            get { return pesquisaPorNome; }
            set
            {
                if (value == pesquisaPorNome) return;

                pesquisaPorNome = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PesquisaPorNome)));
                AplicarFiltro();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<Professor> CopiaListaAlunos;
        private void AplicarFiltro()
        {
            if (pesquisaPorNome == null)
                pesquisaPorNome = "";

            var resultado = CopiaListaAlunos.Where(n => n.Nome.ToLowerInvariant()
                                .Contains(PesquisaPorNome.ToLowerInvariant().Trim())).ToList();

            var removerDaLista = professores.Except(resultado).ToList();
            foreach (var item in removerDaLista)
            {
                professores.Remove(item);
            }

            for (int index = 0; index < resultado.Count; index++)
            {
                var item = resultado[index];
                if (index + 1 > professores.Count || !professores[index].Equals(item))
                    professores.Insert(index, item);
            }
        }
    }
}

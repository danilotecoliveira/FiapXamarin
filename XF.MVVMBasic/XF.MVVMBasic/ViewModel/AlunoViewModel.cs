using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        public Aluno Aluno { get; set; }
        public ICommand FormularioAluno { get; set; }

        public List<Aluno> Alunos { get; set; }

        public AlunoViewModel(List<Aluno> alunos)
        {
            Alunos = alunos;

            FormularioAluno = new Command(() =>
            {
                MessagingCenter.Send(alunos, "FormularioAluno");
            });
        }
    }
}

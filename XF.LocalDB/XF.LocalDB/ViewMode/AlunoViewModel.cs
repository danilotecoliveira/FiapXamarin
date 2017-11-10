using System.Collections.Generic;
using System.Linq;
using XF.LocalDB.Model;

namespace XF.LocalDB.ViewMode
{
    public class AlunoViewModel
    {
        public AlunoViewModel() { }

        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<Aluno> Alunos
        {
            get
            {
                return App.AlunoModel.GetAlunos().ToList();
            }
        }
    }
}

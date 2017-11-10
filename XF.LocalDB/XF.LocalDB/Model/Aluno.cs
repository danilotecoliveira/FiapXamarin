using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XF.LocalDB.Data;

namespace XF.LocalDB.Model
{
    public class Aluno
    {
        private SQLiteConnection database;

        public Aluno()
        {
            database = DependencyService.Get<ISQLite>().GetConexao();
            database.CreateTable<Aluno>();
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Aprovado { get; set; }
        static object locker = new object();

        public int SalvarAluno(Aluno aluno)
        {
            lock (locker)
            {
                if (aluno.Id != 0)
                {
                    database.Update(aluno);
                    return aluno.Id;
                }
                else
                    return database.Insert(aluno);
            }
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            lock (locker)
            {
                return (from c in database.Table<Aluno>() orderby c.Nome select c).ToList();
            }
        }

        public Aluno GetAluno(int Id)
        {
            lock (locker)
            {
                return database.Table<Aluno>().Where(c => c.Id == Id).FirstOrDefault();
            }
        }

        public int RemoverAluno(int Id)
        {
            lock (locker)
            {
                return database.Delete<Aluno>(Id);
            }
        }
    }
}

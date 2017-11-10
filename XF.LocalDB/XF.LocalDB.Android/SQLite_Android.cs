using System.IO;
using XF.LocalDB.Data;
using XF.LocalDB.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace XF.LocalDB.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db3";
            string caminho = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var local = Path.Combine(caminho, arquivodb);
            var conexao = new SQLite.SQLiteConnection(local);
            return conexao;
        }
    }
}
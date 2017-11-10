using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Serialization;

namespace XF.LocalDB.Model
{

    [XmlRoot("usuarios")]
    public class Login
    {
        [XmlElement("username")]
        public string Usuario { get; set; }
        [XmlElement("password")]
        public string Senha { get; set; }

        [XmlElement("usuario")]
        public List<Login> Usuarios { get; set; }

        public Login() { }

        public Login(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public bool ValidarLogin()
        {
            var client = new HttpClient();

            try
            {
                var result = client.GetStreamAsync("http://wopek.com/xml/usuarios.xml").Result;
                var xml = new XmlSerializer(typeof(Login));

                var root = (Login)xml.Deserialize(result);
                var usuarios = (root == null) ? new List<Login>() : root.Usuarios;

                foreach (var item in usuarios)
                {
                    if (item.Usuario == Usuario && item.Senha == Senha)
                        return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

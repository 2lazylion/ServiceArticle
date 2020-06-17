using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceArticle
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        // implemente les OperationContract
        public void PostArticle(Article article)
        {
            // string pour la connexion TODO: Objet Database
            string ip = "192.168.1.171";
            string user = "ted";
            string password = "1234";
            string db = "article_a15";
            string cs = String.Format("server={0};user={1};password={2};database={3};" +
                "port=3306;", ip, user, password, db);

            // connexion
            MySqlConnection connection = new MySqlConnection(cs);

            try
            {
                // connection a la bd
                connection.Open();

                // prendre les infos de l'article
                string titre = article.titre;
                int journalisteId = article.auteur.journaliste_id;
                //string date_parution = article.date_parution;
                string texte = article.texte;

                // creer une requete
                string sql = "INSERT INTO article( titre, auteur, date_parution, texte)" +
                                            " VALUES('"+ titre +"', "+ journalisteId + ", DATE_FORMAT(NOW(), '%Y-%m-%d'), '" + texte + "')";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                //execute la commande 
                cmd.ExecuteNonQuery();
            } 
            
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        // correct
        public Journaliste GetJournaliste(int journaliste_id)
        {
            Journaliste j = new Journaliste();

            // string pour la connexion TODO: Objet Database
            string ip = "192.168.1.171";
            string user = "ted";
            string password = "1234";
            string db = "article_a15";
            string cs = String.Format("server={0};user={1};password={2};database={3};" +
                "port=3306;", ip, user, password, db);

            // connexion
            MySqlConnection connection = new MySqlConnection(cs);

            try
            {
                //Journaliste j = new Journaliste();

                // connection a la bd
                connection.Open();

                // creer une requete pour aller chercher le count
                string sql = "SELECT nom, prenom FROM journaliste WHERE journaliste_id = @journaliste_id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@journaliste_id", journaliste_id);

                //execute la commande 
                MySqlDataReader rd = cmd.ExecuteReader();

                
                while (rd.Read())
                {
                    j.journaliste_id = journaliste_id;
                    j.nom = rd.GetString(0);
                    j.prenom = rd.GetString(1);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Close();
            }

            return j;
        }
    }
}

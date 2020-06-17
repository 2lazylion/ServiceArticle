using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceArticle
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        // Declare les OperationContract ici
        // Ils vont être les méthodes appelé par les clients
        [OperationContract]
        void PostArticle(Article article);

        [OperationContract]
        Journaliste GetJournaliste(int journaliste_id);
    }


   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceArticle
{
    [DataContract(IsReference =true)]
    public class Journaliste
    {
        [DataMember]
        public int journaliste_id { get; set; }
        
        [DataMember]
        public string nom { get; set; }

        [DataMember]
        public string prenom { get; set; }

        public Journaliste() { }
        public Journaliste(int journaliste_id, string nom, string prenom)
        {
            this.journaliste_id = journaliste_id;
            this.nom = nom;
            this.prenom = prenom;
        }
    }
}
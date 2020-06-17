using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceArticle
{
    [DataContract(IsReference = true)]
    public class Article
    {
        [DataMember]
        public int articleId { get; set; }

        [DataMember]
        public string titre { get; set; }

        [DataMember]
        public Journaliste auteur { get; set; }

        [DataMember]
        public string date_parution { get; set; }

        [DataMember]
        public string texte { get; set; }

        public Article(int articleId, string titre, Journaliste auteur, string date_parution, string texte)
        {
            this.articleId = articleId;
            this.titre = titre;
            this.auteur = auteur;
            this.date_parution = date_parution;
            this.texte = texte;
        }
    }
}
using System;

namespace CQRSSAmple.Domain.Entity
{
    public class Operatore : EntityBase
    {
        public Operatore(Guid? id, string nome, string cognome, string username, string password) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Nome = nome;
            Cognome = cognome;
            UserName = username;
            Password = password;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        private Operatore()
        {
        }
        
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string UserName { get;  set; }
        public string Password { get;  set; }
        

    }
}
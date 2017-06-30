using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PessoaPojo
    {
        
        public string Email { get; set; }
       
        public string Senha { get; set; }

        public int Nivel { get; set; }

        public int Id { get; set; }

        public PessoaPojo(string Email, string Senha)
        {
           
            this.Email = Email;
            this.Senha = Senha;
           

        }

        public PessoaPojo()
        {

        }

        /* 
         *
    
         EXEMPLO GET SET EXCPLICITO

          public int GetCod()
         {
             return Cod;
         }

         public void SetCod(int Cod)
         {
             this.Cod = Cod;
         }*/
    }
}
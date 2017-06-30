using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAO;
using MySql.Data.MySqlClient;

namespace WebApplication1.Models
{
    public class Pessoa
    {
        

        public void inserirpessoa(PessoaPojo pessoa)

        {
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "INSERT INTO pessoa (email,senha,nivel) VALUES('" + pessoa.Email + "', '" + pessoa.Senha + "','0')";

            cmd.CommandText = query;

            //create command and assign the query and connection from the constructor
           

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            objCon.CloseConnection();





        }
        

        public bool validausuario(PessoaPojo usuario)

        {
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();


            string query = "SELECT Count(*) FROM pessoa where email='" + usuario.Email + "' and senha='" + usuario.Senha + "'";

            cmd.CommandText = query;

            MySqlDataReader Reader = cmd.ExecuteReader();
           
            while (Reader.Read())
            {
                System.Diagnostics.Debug.WriteLine(Reader.GetUInt16(0));
                if (Reader.GetUInt16(0) > 0)
                { 
                
                cmd.Dispose();
                objCon.CloseConnection();
                return true;
                }
            }


            objCon.CloseConnection();
            cmd.Dispose();


            return false;
        }

        public PessoaPojo buscarusuario(PessoaPojo usuario)

        {
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "SELECT nivel,id FROM pessoa where email='" + usuario.Email + "' and senha='" + usuario.Senha + "'";
            cmd.CommandText = query;

            MySqlDataReader Reader = cmd.ExecuteReader();
          
            while (Reader.Read())
            {
                usuario.Nivel = Reader.GetInt16(0);
                usuario.Id = Reader.GetInt16(1);
            }

            cmd.Dispose();
            objCon.CloseConnection();
            


            return usuario;
        }


        

    }


}
    

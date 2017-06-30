using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAO;
using MySql.Data.MySqlClient;

namespace WebApplication1.Models
{
    public class Filme
    {


        public List<filmespojo> listarinfo()

        {
            List<filmespojo> listafilmes = new List<filmespojo>();

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM filmes";



            //create command and assign the query and connection from the constructor

            cmd.CommandText = query;

            MySqlDataReader Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                filmespojo f = new filmespojo();
                f.cod = Reader.GetString(0);
                f.nome = Reader.GetString(1);
                f.genero = Reader.GetString(2);
                f.duracao = Reader.GetString(3);
                f.diretor = Reader.GetString(4);
                f.imagemref = Reader.GetString(5);
                f.imdbrating = Reader.GetString(6);
                f.videoref = Reader.GetString(7);


                listafilmes.Add(f);
            }

            cmd.Dispose();
            objCon.CloseConnection();



            //Execute command
            // cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            // conexao.close();


            return listafilmes;




        }

        public List<filmespojo> listarcomedia()

        {
            List<filmespojo> listafilmes = new List<filmespojo>();

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "SELECT * FROM filmes where genero='Comédia'";

            cmd.CommandText = query;



            //create command and assign the query and connection from the constructor


            MySqlDataReader Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                filmespojo f = new filmespojo();
                f.cod = Reader.GetString(0);
                f.nome = Reader.GetString(1);
                f.genero = Reader.GetString(2);
                f.duracao = Reader.GetString(3);
                f.diretor = Reader.GetString(4);
                listafilmes.Add(f);
            }



            //Execute command
            // cmd.ExecuteNonQuery();

            //close connection

            cmd.Dispose();
            objCon.CloseConnection();

            return listafilmes;




        }




        public void inserirfilme(filmespojo filme)

        {

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "INSERT INTO filmes (cod, nome, genero, duracao, diretor,imagemref,nota,videoref) VALUES('" + filme.cod + "', '" + filme.nome + "','" + filme.genero + "','" + filme.duracao + "','" + filme.diretor + "','" + filme.imagemref + "','" + filme.imdbrating + "','" + filme.videoref +"')";

            cmd.CommandText = query;

            //create command and assign the query and connection from the constructor


            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            objCon.CloseConnection();





        }

        public bool inserirassistidos(filmespojo filme, PessoaPojo pessoa)

        {
            int opcao = 0;

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmdverificar = Conn.CreateCommand();

            string queryverificar = "SELECT status FROM meufilme WHERE pessoaid='" + pessoa.Id + "'and filmeid='" + filme.cod + "'";

            cmdverificar.CommandText = queryverificar;

            MySqlDataReader Reader = cmdverificar.ExecuteReader();

            while (Reader.Read())
            {
                if (Reader.HasRows == true)
                {
                    if (Reader.GetInt32(0) == 0) { opcao = 1; }
                    else opcao = 2;
                }
            }

            cmdverificar.Dispose();

            objCon.CloseConnection();

            if (opcao == 1)
            {
                Conn = objCon.OpenConnection();
                MySqlCommand cmdupdate = Conn.CreateCommand();

                string queryupdate = "UPDATE meufilme SET status='1' WHERE pessoaid='" + pessoa.Id + "'and filmeid='" + filme.cod + "' and status='0'";

                cmdupdate.CommandText = queryupdate;

                cmdupdate.ExecuteNonQuery();
                cmdupdate.Dispose();
                objCon.CloseConnection();
                return true;

            }

            if (opcao == 2) return false;

            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "INSERT INTO meufilme (pessoaid, filmeid, status) VALUES('" + pessoa.Id + "', '" + filme.cod + "','1')";


            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            objCon.CloseConnection();



            return true;

        }


        public bool inserirdesejos(filmespojo filme, PessoaPojo pessoa)

        {
            int opcao = 0;

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmdverificar = Conn.CreateCommand();

            string queryverificar = "SELECT status FROM meufilme WHERE pessoaid='" + pessoa.Id + "'and filmeid='" + filme.cod + "'";
            cmdverificar.CommandText = queryverificar;

            MySqlDataReader Reader = cmdverificar.ExecuteReader();

            while (Reader.Read())
            {
                if (Reader.HasRows == true)
                {
                    opcao = 1;
                }
            }

            cmdverificar.Dispose();
            objCon.CloseConnection();


            if (opcao == 1)
            {
                return false;

            }


            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "INSERT INTO meufilme (pessoaid, filmeid, status) VALUES('" + pessoa.Id + "', '" + filme.cod + "','0')";


            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            objCon.CloseConnection();



            return true;

        }



        public filmespojo selecionarfilme(filmespojo filmecod)

        {


            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM filmes where cod='" + filmecod.cod + "'";

            filmespojo f = new filmespojo();


            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            MySqlDataReader Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {

                f.cod = Reader.GetString(0);
                f.nome = Reader.GetString(1);
                f.genero = Reader.GetString(2);
                f.duracao = Reader.GetString(3);
                f.diretor = Reader.GetString(4);
                f.videoref = Reader.GetString(7);

            }



            //Execute command
            // cmd.ExecuteNonQuery();

            //close connection

            cmd.Dispose();
            objCon.CloseConnection();
            return f;




        }


        public List<filmespojo> listarassistidos(int id)

        {


            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            


            string query = "SELECT filmeid FROM meufilme where pessoaid='" + id + "' and status='1'";

            List<filmespojo> filmes = new List<filmespojo>();
            List<string> idfilmes = new List<string>();


            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            MySqlDataReader Reader = cmd.ExecuteReader();


            while (Reader.Read())
            {
                idfilmes.Add(Reader.GetString(0));


            }
            Reader.Close();
            Reader.Dispose();
            cmd.Dispose();
            objCon.CloseConnection();




            //Execute command
            // cmd.ExecuteNonQuery();

            //close connection
            Conn = objCon.OpenConnection();
            MySqlCommand cmd2 = Conn.CreateCommand();

            for (int i = 0; i < idfilmes.Count; i++)
            {
                string query2 = "SELECT * FROM filmes where cod='" + idfilmes[i] + "'";

                cmd2.CommandText = query2;
                
                MySqlDataReader Reader2 = cmd2.ExecuteReader();

                while (Reader2.Read())
                {
                    filmespojo f = new filmespojo();
                    f.cod = Reader2.GetString(0);
                    f.nome = Reader2.GetString(1);
                    f.genero = Reader2.GetString(2);
                    f.duracao = Reader2.GetString(3);
                    f.diretor = Reader2.GetString(4);
                    f.imagemref = Reader2.GetString(5);
                    f.imdbrating = Reader2.GetString(6);
                    System.Diagnostics.Debug.WriteLine(f.diretor);

                    filmes.Add(f);

                }
                Reader2.Close();
            }
            cmd2.Dispose();
            cmd.Dispose();
            objCon.CloseConnection();


            return filmes;




        }


        public void atualizarfilme(filmespojo f)

        {

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "UPDATE filmes set nome='" + f.nome + "', cod='" + f.cod + "', genero='" + f.genero + "', diretor='" + f.diretor + "', duracao='" + f.duracao + "',videoref='" + f.videoref + "' WHERE cod='" + f.cod + "'";



            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            objCon.CloseConnection();





        }

        public void removerfilme(filmespojo f)

        {

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "DELETE FROM filmes WHERE cod='" + f.cod + "'";



            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            objCon.CloseConnection();
            cmd.Dispose();




        }
        public void removerassistidos(filmespojo f, PessoaPojo usuario)

        {

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "DELETE FROM meufilme WHERE filmeid='" + f.cod + "' and status='1'and pessoaid='" + usuario.Id + "'";



            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            objCon.CloseConnection();
            cmd.Dispose();




        }

        public void removerdesejos(filmespojo f, PessoaPojo usuario)

        {

            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();
            string query = "DELETE FROM meufilme WHERE filmeid='" + f.cod + "' and status='0' and pessoaid='" + usuario.Id + "'";



            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            cmd.Dispose();
            objCon.CloseConnection();
            cmd.Dispose();




        }

        public List<filmespojo> listardesejos(int id)

        {



            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.OpenConnection();
            MySqlCommand cmd = Conn.CreateCommand();



            string query = "SELECT filmeid FROM meufilme where pessoaid='" + id + "' and status='0'";

            List<filmespojo> filmes = new List<filmespojo>();
            List<string> idfilmes = new List<string>();


            //create command and assign the query and connection from the constructor
            cmd.CommandText = query;

            MySqlDataReader Reader = cmd.ExecuteReader();


            while (Reader.Read())
            {
                idfilmes.Add(Reader.GetString(0));


            }
            Reader.Close();
            Reader.Dispose();
            cmd.Dispose();
            objCon.CloseConnection();




            //Execute command
            // cmd.ExecuteNonQuery();

            //close connection
            Conn = objCon.OpenConnection();
            MySqlCommand cmd2 = Conn.CreateCommand();

            for (int i = 0; i < idfilmes.Count; i++)
            {
                string query2 = "SELECT * FROM filmes where cod='" + idfilmes[i] + "'";

                cmd2.CommandText = query2;

                MySqlDataReader Reader2 = cmd2.ExecuteReader();

                while (Reader2.Read())
                {
                    filmespojo f = new filmespojo();
                    f.cod = Reader2.GetString(0);
                    f.nome = Reader2.GetString(1);
                    f.genero = Reader2.GetString(2);
                    f.duracao = Reader2.GetString(3);
                    f.diretor = Reader2.GetString(4);
                    f.imagemref = Reader2.GetString(5);
                    f.imdbrating = Reader2.GetString(6);
                    System.Diagnostics.Debug.WriteLine(f.diretor);

                    filmes.Add(f);

                }
                Reader2.Close();
            }
            cmd2.Dispose();
            cmd.Dispose();
            objCon.CloseConnection();


            return filmes;







        }


    }
}
    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Models.DAO
{
    public class Conexao
    {
        //public static string caminho = "SERVER=mysql5019.smarterasp.net;DATABASE=db_a26413_web;UID=a26413_web;PASSWORD=power100";

        //public static string caminho = "SERVER=127.0.0.1;DATABASE=web;UID=root;PASSWORD=";

        

            private MySqlConnection Conn;

            public MySqlConnection OpenConnection()
            {
            //Local:    
             Conn = new MySqlConnection("server=127.0.0.1;database=web;uid=root;pwd=");
           // Conn = new MySqlConnection("SERVER=mysql5019.smarterasp.net;DATABASE=db_a26413_web;UID=a26413_web;PASSWORD=power100");
            Conn.Open();
                return Conn;

            }


            public void CloseConnection()
            {
                Conn.Close();

            }




        }
}//public static string caminho = "SERVER=mysql5019.smarterasp.net;DATABASE=db_a26413_web;UID=a26413_web;PASSWORD=power100";
//public static string caminho = "SERVER=mysql5019.smarterasp.net;DATABASE=db_a26413_web;UID=a26413_web;PASSWORD=power100";
//public static string caminho = "SERVER=mysql5019.smarterasp.net;DATABASE=db_a26413_web;UID=a26413_web;PASSWORD=power100";

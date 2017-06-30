using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        Pessoa pessoa = new Pessoa();
        // GET: Login
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Login()
        {
            return View("Login");


        }
        [HttpPost]
        public ActionResult Login(PessoaPojo usuario)
        {
            bool verificador;


            
            
            usuario = pessoa.buscarusuario(usuario);
            verificador = pessoa.validausuario(usuario);


            if (verificador == true)
            {

                Session["user"] = new PessoaPojo { Email = usuario.Email, Senha = usuario.Senha };
                Session["nivel"] = usuario.Nivel;
                Session["id"] = usuario.Id;
                return RedirectToAction("Index","Home");
            }



            return RedirectToAction("Index", "Home");
        }

        public ActionResult Cadastrousuario()
        {
            
            return View();


        }
        [HttpPost]
        public ActionResult Cadastrousuario(PessoaPojo usuario)
        {
            

            pessoa.inserirpessoa(usuario);

           return RedirectToAction("Index","Home");


        }

        public ActionResult Sair()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");


        }


    }

}
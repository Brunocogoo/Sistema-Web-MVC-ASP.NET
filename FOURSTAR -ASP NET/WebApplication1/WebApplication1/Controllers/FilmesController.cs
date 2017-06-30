using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAO;
using WebApplication1.Models;
using System.Web.Script.Serialization;
using System.Web.Script;
using Newtonsoft.Json.Linq;


namespace WebApplication1.Controllers
{
    public class FilmesController : Controller
    {
        
        Filme filmes= new Filme();
        // GET: Filmes
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Filme()
        {
            System.Diagnostics.Debug.WriteLine("errado");
            if (Session["user"] == null) { return RedirectToAction("Login","Login"); }
            ViewBag.Message = "Aqui ficam as séries";
            
            List<filmespojo> listar = new List<filmespojo>();
            listar = filmes.listarinfo();


            using (var webClient = new System.Net.WebClient())
            {
                foreach(filmespojo filme in listar)
                {
                    System.Diagnostics.Debug.WriteLine(filme.cod);
                    var jsonData = webClient.DownloadString("http://www.omdbapi.com/?i="+filme.cod+"&apikey=abdc768b");
                    System.Diagnostics.Debug.WriteLine("http://www.omdbapi.com/?i=" + filme.cod + "&apikey=abdc768b");
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var Dfilme = js.Deserialize <imdbpojo>(jsonData);

                    if (Dfilme.imdbRating != null)
                    {
                        filme.imdbrating = Dfilme.imdbRating;
                    }
                    else filme.imdbrating = "0";
                }

                // ViewBag.CatJson = saida;
            }





            return View(listar);


        }




        public ActionResult filmeremover(filmespojo filmeremover)
        {
            System.Diagnostics.Debug.WriteLine("certo");
           
            filmes.removerfilme(filmeremover);

            return RedirectToAction("Filme");
        }

        public ActionResult Filmeadd()
        {
            if (Session["user"] == null) { return RedirectToAction("Login", "Login"); }
            return View();


        }

        [HttpPost]
        public ActionResult Filmeadd(filmespojo filme , HttpPostedFileBase file)
        {
           
            if (Session["user"] == null) { return RedirectToAction("Login", "Login"); }
            filme.imagemref = file.FileName;

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/img/upload"), pic);

                file.SaveAs(path);



            }

            using (var webClient = new System.Net.WebClient())
            {
                
                    System.Diagnostics.Debug.WriteLine(filme.cod);
                    var jsonData = webClient.DownloadString("http://www.omdbapi.com/?i="+filme.cod+"&apikey=abdc768b");
                    System.Diagnostics.Debug.WriteLine("http://www.omdbapi.com/?i=" + filme.cod + "&apikey=abdc768b");
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var Dfilme = js.Deserialize <imdbpojo>(jsonData);

                    if (Dfilme.imdbRating != null)
                    {
                        filme.imdbrating = Dfilme.imdbRating;
                        filme.duracao = Dfilme.Runtime;
                        filme.genero = Dfilme.Genre;
                        filme.diretor = Dfilme.Director;
                }
                    else filme.imdbrating = "0";
                

                // ViewBag.CatJson = saida;
            }

                      
           filmes.inserirfilme(filme);



            return RedirectToAction("Filmeadd");


        }



        [HttpPost]
        public ActionResult Filmeeditar(filmespojo filme)
        {
            if (Session["user"] == null) { return RedirectToAction("Login", "Login"); }
            System.Diagnostics.Debug.WriteLine(filme.cod);
            
            filmes.atualizarfilme(filme);






            return RedirectToAction("Filme");


        }



        [HttpGet]
        public ActionResult Filmeeditar(filmespojo filmeid, int? x)
        {
            if (Session["user"] == null) { return RedirectToAction("Login", "Login"); }
            System.Diagnostics.Debug.WriteLine(filmeid.cod);
           
            filmespojo f = new filmespojo();
            f = filmes.selecionarfilme(filmeid);


            return View(f);


        }

        public ActionResult Assistidos()
        {
            if (Session["user"] == null) { return RedirectToAction("Login", "Login"); }
            
            List<filmespojo> f = new List<filmespojo>();
            
            f=filmes.listarassistidos((int)Session["id"]);

            

            return View(f);


        }
        public ActionResult Assistidosremover(filmespojo filmeremover)
        {
            PessoaPojo usuario = new PessoaPojo();
            usuario.Id = (int)Session["id"];
            System.Diagnostics.Debug.WriteLine("certo");

            filmes.removerassistidos(filmeremover,usuario);

            return RedirectToAction("Assistidos");
        }

        public ActionResult Desejos()
        {
            if (Session["user"] == null) { return RedirectToAction("Login", "Login"); }

            List<filmespojo> f = new List<filmespojo>();
            f = filmes.listardesejos((int)Session["id"]);



            return View(f);


        }
        public ActionResult Desejosremover(filmespojo filmeremover)
        {
            PessoaPojo usuario = new PessoaPojo();
            usuario.Id = (int)Session["id"];
            System.Diagnostics.Debug.WriteLine("certo");

            filmes.removerdesejos(filmeremover,usuario);

            return RedirectToAction("Desejos");
        }

        public ActionResult Inserirassistidos(filmespojo filme)
        {
            PessoaPojo usuario = new PessoaPojo();
            usuario.Id = (int)Session["id"];

           bool verificador= filmes.inserirassistidos(filme,usuario);

            

            return RedirectToAction("Assistidos");
        }

        public ActionResult Inserirdesejos(filmespojo filme)
        {

            PessoaPojo usuario = new PessoaPojo();
            usuario.Id = (int)Session["id"];
            filmes.inserirdesejos(filme,usuario);

            return RedirectToAction("Desejos");
        }

        public ActionResult Serialize()
        {
            List<filmespojo> listar = new List<filmespojo>();

            listar = filmes.listarinfo();

            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(listar);
            ViewBag.CatJson = jsonData;

            return View();
        }

        public ActionResult Player(filmespojo filme)
        {
            if (Session["user"] == null) { return RedirectToAction("Login", "Login"); }
            System.Diagnostics.Debug.WriteLine(filme.videoref);

            


            return View(filme);


        }

    }
}
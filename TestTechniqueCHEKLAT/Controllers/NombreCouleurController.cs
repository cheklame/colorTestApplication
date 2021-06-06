using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTechniqueCHEKLAT.Models;

namespace TestTechniqueCHEKLAT.Controllers
{
    public class NombreCouleurController : Controller
    {

        public static List<NombreCouleur> ListeNombreCouleur = new List<NombreCouleur>();
        public static List<Couleur> ListeCouleur = new List<Couleur>();
        public static NombreCouleur NombreCouleur = new NombreCouleur();
        public static Couleur Couleur = new Couleur();


        public ActionResult Index()
        {
            return View(Couleur);
        }


        [HttpPost]
        public ActionResult Ajouter(Couleur couleur)
        {
            if (ModelState.IsValid)
            {
                ListeCouleur.Add(couleur); 
            }

            return Affichage();
        }


        [HttpPost]
        public ActionResult Affichage()
        {
            ListeNombreCouleur = new List<NombreCouleur>();

                for (var i = 1; i <= 50; i++)
                {
                    foreach(var item in ListeCouleur)
                    {
                        if (isDiviseurCommun(i, item.NumeroDivisible))
                        {
                            var numCouleur = new NombreCouleur();
                            if (ListeNombreCouleur.Select(x => x.Numero).Contains(i))
                            {
                                ListeNombreCouleur.Select(x => x).Where(n => n.Numero == i)
                                    .First().Couleur.CodeCouleur = "#F5E51B";
                            }
                            else { 
                                
                                numCouleur.Numero = i;
                                // numCouleur.Couleur = item;
                                numCouleur.Couleur = new Couleur();
                                numCouleur.Couleur.CodeCouleur = "#" + item.CodeCouleur;
                                ListeNombreCouleur.Add(numCouleur);
                        }
                        
                               
                        }  
                    }

                    if (!ListeNombreCouleur.Select(x => x.Numero).Contains(i))
                    {
                       var numCouleur = new NombreCouleur();
                       numCouleur.Couleur = new Couleur();

                       numCouleur.Numero = i;
                       numCouleur.Couleur.LibelleCouleur = "Blanc";
                       numCouleur.Couleur.CodeCouleur = $"#FFFFFF";
                       ListeNombreCouleur.Add(numCouleur);
                    }
                }
                ViewBag.ListeCouleur = ListeCouleur;

            return PartialView("~/Views/NombreCouleur/_MonAffichage.cshtml", ListeNombreCouleur);

        }


        /* 
         * Fonction qui retourne si un nombre est divisible par un autres.
         */
        private bool isDiviseurCommun(int numero, int diviseur)
        {

            return ((numero % diviseur == 0));

        }

        public ActionResult ReturnTo()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Reset()
        {
            
            ListeCouleur = new List<Couleur>();
            ListeNombreCouleur = new List<NombreCouleur>();
            Couleur = new Couleur();

            return View("Index");
        }

    }
}

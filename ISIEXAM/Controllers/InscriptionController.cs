using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIEXAM.Models;
using PagedList;

namespace ISIEXAM.Controllers
{
    public class InscriptionController : Controller
    {
        private bdISIEXAMContext db = new bdISIEXAMContext();
        int pageSize = 2;
        // GET: Etudiants/Create
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult listerClasse(int? page, string Nom, string Prenom, string Telephone)
        {
          page = page.HasValue ? page : 1;
            var liste = getListeClasse();
            ViewBag.Nom = Nom;
            ViewBag.Prenom = Prenom;
            ViewBag.Telephone = Telephone;

            if (!string.IsNullOrEmpty(Nom))
            {
                liste = liste.Where(a => a.NomEtudiant.ToUpper().Contains(Nom.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(Prenom))
            {
                liste = liste.Where(a => a.PrenomEtudiant.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(Telephone))
            {
                liste = liste.Where(a => a.TelEtudiant.ToUpper().Contains(Telephone.ToUpper())).ToList();
            }

           int pageNumber = (page ?? 1);
            return View(liste.ToPagedList(pageNumber, pageSize));
        }

        private List<CLasseViewModel> getListeClasse()
        {
            List<CLasseViewModel> lister = new List<CLasseViewModel>();

            var liste = db.classes.Join(db.etudiants, x => x.IdClasse, y => y.IdEtudiant, (x, y) =>
            new { x.IdClasse, x.LibelleClasse, y.NomEtudiant, y.PrenomEtudiant, y.AdresseEtudiant, y.EmailEtudiant, y.TelEtudiant }).ToList();

            foreach (var i in liste)
            {
                CLasseViewModel c = new CLasseViewModel();
                c.TelEtudiant = i.TelEtudiant;
                c.LibelleClasse = i.LibelleClasse;
                c.PrenomEtudiant = i.PrenomEtudiant;
                c.NomEtudiant = i.NomEtudiant;
                c.IdEtudiant = i.IdClasse;
                c.EmailEtudiant = i.EmailEtudiant;
                c.AdresseEtudiant = i.AdresseEtudiant;
                lister.Add(c);
            }

            return lister;
        }

        // POST: Etudiants/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEtudiant,NomEtudiant,PrenomEtudiant,AdresseEtudiant,EmailEtudiant,TelEtudiant,LibelleClasse")] CLasseViewModel cl)
        {
            if (ModelState.IsValid)
            {
                Etudiant e = new Etudiant();
                e.NomEtudiant = cl.NomEtudiant;
                e.PrenomEtudiant = cl.PrenomEtudiant;
                e.AdresseEtudiant = cl.AdresseEtudiant;
                e.EmailEtudiant = cl.EmailEtudiant;
                e.TelEtudiant = cl.TelEtudiant;
                db.etudiants.Add(e);
                db.SaveChanges();

                Classe c = new Classe();
                c.IdClasse = e.IdEtudiant;
                c.LibelleClasse = cl.LibelleClasse;
                db.classes.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cl);
        }
    }
}
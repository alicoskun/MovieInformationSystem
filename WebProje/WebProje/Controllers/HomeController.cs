using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class MyModels
    {
        public List<tblMovie> movies { get; set; }
        public List<tblSlider> slides { get; set; }
        public List<tblType> types { get; set; }
    }
    public class HomeController : Controller
    {
        FilmBilgileriEntities1 ent = new FilmBilgileriEntities1();

        public ActionResult Index(string searchString)
        {
            MyModels model = new MyModels();
            if (!String.IsNullOrEmpty(searchString))
            {
                model.movies = ent.tblMovie.Where(s => s.MovieName.Contains(searchString)).ToList();
            }
            else
                 model.movies = ent.tblMovie.ToList();
            model.slides = ent.tblSlider.ToList();
            model.types = ent.tblType.ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tblMember member, HttpPostedFileBase file)
        {
            try
            {
                tblMember _member = new tblMember();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _member.MemberPhoto = memoryStream.ToArray();
                }
                _member.MemberName = member.MemberName;
                _member.MemberEmail = member.MemberEmail;
                _member.MemberDOB = member.MemberDOB;
                _member.MemberPassword = member.MemberPassword;
                _member.MemberGroupID = 3;
                _member.MemberReputationID = 1;
                _member.MemberRegisterDate = DateTime.Now;
                ent.tblMember.Add(_member);
                ent.SaveChanges();
                return View("RegisterMessage");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu! - " + ex.Message);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblMember member)
        {
            if (ModelState.IsValid)
            {
                string sifre = member.MemberPassword;
                var uye = ent.tblMember.Where(x => x.MemberEmail == member.MemberEmail && x.MemberPassword == sifre).FirstOrDefault();
                int uye_rol = uye.MemberGroupID;
                if (uye != null)
                {
                    Session["eposta"] = member.MemberEmail; 
                    if (uye_rol == 1)
                        return RedirectToAction("Filmler", "Admin");
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Mesaj"] = "Kullanıcı Adı veya şifre yanlış, eposta aktivasyon maili onaylanmamıştır";
                }
            }
            return View("Login");
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult FilmDetay(int ID)
        {
            var FilmDetay = ent.tblMovie.Where(x => x.MovieID == ID).FirstOrDefault();
            return View(FilmDetay);
        }

        public ActionResult TureGoreFilmler(int TypeID, tblMember member)
        {
            ViewBag.FilmTur = ent.tblType.FirstOrDefault(x => x.TypeID == TypeID);
            var tureGoreFilmler = ent.tblMovie.
                 Where(x => x.tblMovieType.FirstOrDefault
                    (z => z.MovieType_TypeID == TypeID)
                        .MovieType_MovieID == x.MovieID).ToList();
            return View(tureGoreFilmler);
        }

        public ActionResult FavoriFilmler(int MemberID)
        {
            if (MemberID != 0)
            {
                var favoriFilmler = ent.tblMovie.
                     Where(x => x.tblMovieFavList.FirstOrDefault
                        (z => z.MovieFavList_MemberID == MemberID)
                            .MovieFavList_MovieID == x.MovieID).ToList();
                return View(favoriFilmler);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult FavoriFilmEkle(int MovieID, tblMovie movie)
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["eposta"] != null)
                {
                    var ent = new FilmBilgileriEntities1();
                    string eposta = System.Web.HttpContext.Current.Session["eposta"].ToString();
                    int MemberID = ent.tblMember.First(x => x.MemberEmail == eposta).MemberID;

                    int filmDahaOnceEklenmisMi = ent.tblMember.Count(x => x.tblMovieFavList.FirstOrDefault(z => z.MovieFavList_MovieID == MovieID).MovieFavList_MemberID == MemberID);

                    if (filmDahaOnceEklenmisMi <= 0)
                    {
                        tblMovieFavList _movieFav = new tblMovieFavList();
                        _movieFav.MovieFavList_MovieID = MovieID;
                        _movieFav.MovieFavList_MemberID = MemberID;
                        ent.tblMovieFavList.Add(_movieFav);
                        ent.SaveChanges();
                        return View("FilmFavorilereEklendi");
                    }
                    else
                    {
                        
                        return View("FilmFavorilereEklenmedi");
                    }
                }
                else
                {
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu! - " + ex.Message);
            }
        }

        public ActionResult FavoriFilmSil(int MovieID)
        {
            int MemberID = MemberID_Getir();
            try
            {
                ent.tblMovieFavList.Remove(ent.tblMovieFavList.First(x => x.MovieFavList_MemberID == MemberID && x.MovieFavList_MovieID == MovieID));
                ent.SaveChanges();

                var favoriFilmler = ent.tblMovie.
                     Where(x => x.tblMovieFavList.FirstOrDefault
                        (z => z.MovieFavList_MemberID == MemberID)
                            .MovieFavList_MovieID == x.MovieID).ToList();
                return View("FilmSilindi");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu! - " + ex.Message);
            }
        }

        public static int MemberID_Getir()
        {
            if (System.Web.HttpContext.Current.Session["eposta"] != null)
            {
                var ent = new FilmBilgileriEntities1();
                string eposta = System.Web.HttpContext.Current.Session["eposta"].ToString();
                return ent.tblMember.First(x => x.MemberEmail == eposta).MemberID;
            }
            else
            {
                return 0;
            }
        }

        public static string UyeBilgiGetir(string eposta)
        {
            var ent = new FilmBilgileriEntities1();
            var uye_bilgi = ent.tblMember.FirstOrDefault(x => x.MemberEmail == eposta);
            string adsoyad = uye_bilgi.MemberName;
            return adsoyad;
        }


        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

    }
}
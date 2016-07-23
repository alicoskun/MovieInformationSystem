using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        FilmBilgileriEntities1 ent = new FilmBilgileriEntities1();

        #region Film
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult Filmler()
        {
            var _filmler = ent.tblMovie.ToList();
            return View(_filmler);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult FilmEkle()
        {
            return View();
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult FilmDuzenle(int FilmID)
        {
            var _filmDuzenle = ent.tblMovie.Where(x => x.MovieID == FilmID).FirstOrDefault();
            return View(_filmDuzenle);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult FilmSil(int FilmID)
        {
            try
            {
                ent.tblMovie.Remove(ent.tblMovie.First(d => d.MovieID == FilmID));
                ent.SaveChanges();
                return RedirectToAction("Filmler","Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu! - " + ex.Message);
            }
        }

        [HttpPost]
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult FilmEkle(tblMovie film, HttpPostedFileBase file)
        {
            try
            {
                tblMovie _film = new tblMovie();
                if(file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _film.MoviePhoto = memoryStream.ToArray();
                }
                _film.MovieName = film.MovieName;
                _film.MovieReleaseDate = film.MovieReleaseDate;
                _film.MovieRunTimeMinutes = film.MovieRunTimeMinutes;
                _film.MovieSynopsis = film.MovieSynopsis;
                ent.tblMovie.Add(_film);
                ent.SaveChanges();
                return RedirectToAction("Filmler","Admin");
            }
            catch(Exception ex)
            {
                throw new Exception("Eklerken hata oluştu! - " + ex.Message);
            }
        }

        [HttpPost]
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult FilmDuzenle(tblMovie film, HttpPostedFileBase file)
        {
            try
            {
                var _filmDuzenle = ent.tblMovie.Where(x => x.MovieID == film.MovieID).FirstOrDefault();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _filmDuzenle.MoviePhoto = memoryStream.ToArray();
                }
                _filmDuzenle.MovieName = film.MovieName;
                _filmDuzenle.MovieReleaseDate = film.MovieReleaseDate;
                _filmDuzenle.MovieRunTimeMinutes = film.MovieRunTimeMinutes;
                _filmDuzenle.MovieSynopsis = film.MovieSynopsis;
                ent.SaveChanges();
                return RedirectToAction("Filmler","Admin");
            }
            catch(Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu! - " + ex.Message);
            }
        }
        #endregion

        #region Cast
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult Cast()
        {
            var _cast = ent.tblPeople.ToList();
            return View(_cast);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult CastEkle()
        {
            return View();
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult CastDuzenle(int CastID)
        {
            var _castDuzenle = ent.tblPeople.Where(x => x.PeopleID == CastID).FirstOrDefault();
            return View(_castDuzenle);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult CastSil(int CastID)
        {
            try
            {
                ent.tblPeople.Remove(ent.tblPeople.First(d => d.PeopleID == CastID));
                ent.SaveChanges();
                return RedirectToAction("Cast","Admin");
            }
            catch(Exception ex)
            {
                throw new Exception("Silerken hata oluştu! - " + ex.Message);
            }
        }

        [HttpPost]
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult CastEkle(tblPeople cast, HttpPostedFileBase file)
        {
            try
            {
                tblPeople _cast = new tblPeople();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _cast.PeoplePhoto = memoryStream.ToArray();
                }
                _cast.PeopleName = cast.PeopleName;
                _cast.PeopleDOB = cast.PeopleDOB;
                ent.tblPeople.Add(_cast);
                ent.SaveChanges();
                return RedirectToAction("Cast", "Admin");
            }
            catch (Exception ex)
            {

                throw new Exception("Eklerken hata oluştu!");
            }
        }

        [HttpPost]
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult CastDuzenle(tblPeople cast, HttpPostedFileBase file)
        {
            try
            {
                var _castDuzenle = ent.tblPeople.Where(x => x.PeopleID == cast.PeopleID).FirstOrDefault();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _castDuzenle.PeoplePhoto = memoryStream.ToArray();
                }
                _castDuzenle.PeopleName = cast.PeopleName;
                _castDuzenle.PeopleDOB = cast.PeopleDOB;
                ent.SaveChanges();
                return RedirectToAction("Cast", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu! - " + ex.Message);
            }
        }
        #endregion

        #region Uye
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult Uye()
        {
            var _uyeler = ent.tblMember.ToList();
            return View(_uyeler);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult UyeDuzenle(int MemberID)
        {
            ViewBag.MemberGroup = new SelectList(ent.tblMemberGroup.ToList(), "MemberGroupID", "MemberTypeName");
            ViewBag.MemberReputation = new SelectList(ent.tblMemberReputation.ToList(), "MemberReputationID", "MemberLevelName");
            var _uyeDuzenle = ent.tblMember.Where(x => x.MemberID == MemberID).FirstOrDefault();
            return View(_uyeDuzenle);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult UyeSil(int MemberID)
        {
            try
            {
                ent.tblMember.Remove(ent.tblMember.First(d => d.MemberID == MemberID));
                ent.SaveChanges();
                return RedirectToAction("Uye", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu! - " + ex.Message);
            }
        }

        [HttpPost]
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult UyeDuzenle(tblMember member, HttpPostedFileBase file)
        {
            try
            {
                var _uyeDuzenle = ent.tblMember.Where(x => x.MemberID == member.MemberID).FirstOrDefault();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _uyeDuzenle.MemberPhoto = memoryStream.ToArray();
                }
                _uyeDuzenle.MemberName = member.MemberName;
                _uyeDuzenle.MemberEmail = member.MemberEmail;
                _uyeDuzenle.MemberDOB = member.MemberDOB;
                _uyeDuzenle.MemberGroupID = member.MemberGroupID;
                _uyeDuzenle.MemberReputationID = member.MemberReputationID;
                _uyeDuzenle.MemberRegisterDate = member.MemberRegisterDate;
                ent.SaveChanges();
                return RedirectToAction("Uye", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu! - " + ex.Message);
            }
        }
        #endregion

        #region Slider

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult Slider()
        {
            var slider = ent.tblSlider.ToList();
            return View(slider);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult SlideEkle()
        {
            return View();
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult SlideDuzenle(int SlideID)
        {
            var _slideDuzenle = ent.tblSlider.Where(x => x.SliderID == SlideID).FirstOrDefault();
            return View(_slideDuzenle);
        }

        [WebProje.Attributes.AdminRoleControl]
        public ActionResult SlideSil(int SlideID)
        {
            try
            {
                ent.tblSlider.Remove(ent.tblSlider.First(d => d.SliderID == SlideID));
                ent.SaveChanges();
                return RedirectToAction("Slider", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }

        [HttpPost]
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult SlideEkle(tblSlider s, HttpPostedFileBase file)
        {
            try
            {
                tblSlider _slide = new tblSlider();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _slide.SliderPhoto = memoryStream.ToArray();
                }
                ent.tblSlider.Add(_slide);
                ent.SaveChanges();
                return RedirectToAction("Slider", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }

        [HttpPost]
        [WebProje.Attributes.AdminRoleControl]
        public ActionResult SlideDuzenle(tblSlider slide, HttpPostedFileBase file)
        {
            try
            {
                var _slideDuzenle = ent.tblSlider.Where(x => x.SliderID == slide.SliderID).FirstOrDefault();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _slideDuzenle.SliderPhoto = memoryStream.ToArray();
                }
                ent.SaveChanges();
                return RedirectToAction("Slider", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }
        #endregion

        //Uzun metinleri, girilen length değeri boyutuna kadar kısaltmaya yarayan metot
        public static string TruncateAtWord(string value, int length)
        {
            if (value == null || value.Length < length)
                return value;

            return value.Substring(0, length) + "...";
        }
    }
}
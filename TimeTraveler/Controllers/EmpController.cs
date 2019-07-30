using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeTraveler.Controllers
{
    public class EmpController : Controller
    {
        chinniDBEntities1 db = new chinniDBEntities1();
        private IDataAccess<Empdata> _dataAcee;
        public EmpController()
        {
            _dataAcee = new DAL.DataAccesss();
        }
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Geralldata()
        {
            
            var res = _dataAcee.GetData();          
            return View(res);
        }
        public ActionResult GetAllEmpPartial()
        {

            var res = _dataAcee.GetData();
            return PartialView(@"/Views/Shared/_GetAll.cshtml",res);
        }


        public ActionResult save()
        {
            return View(@"/Views/Emp/SaveEmployee.cshtml");
        }
        [HttpPost]
        public ActionResult AddEmp(Empdata data)
        {
            var Response=_dataAcee.SaveEmployee(data);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        

       
        public ActionResult Delete(int id)
        {
            
            var data = db.Empdatas.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Empdata obj, int id)
        {
            var data = db.Empdatas.Find(id);
            _dataAcee.Delete(data);
           return RedirectToAction("Geralldata");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            chinniDBEntities1 db = new chinniDBEntities1();
            var data = db.Empdatas.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Empdata emp)
        {

            _dataAcee.Update(emp);
            return RedirectToAction("Geralldata");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TestApplication.Models;
using TestApplication.ViewModel;
using Newtonsoft.Json;
using static TestApplication.ViewModel.EmployeeDetailsViewModel;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace TestApplication.Controllers
{
    public class TestController : Controller
    {
        MyDbContext db = new MyDbContext();

        public IActionResult DefaultQuick()
        {
            return PartialView("DefaultQuickView");
        }
        #region Employee

        public ActionResult getEmplistPartial(string MenuID)
        {
            EmployeeViewModelList lst = getlist();
            return PartialView("EmployeeList", lst);

        }
        public EmployeeViewModelList getlist()
        {
            List<Employee> datalist = (from D in db.Employee
                                       select new Employee
                                       {
                                           Id = D.Id,
                                           Name = D.Name,
                                           Email = D.Email,
                                           Designation = D.Designation
                                       }).ToList();

            EmployeeViewModelList DataViewlist = null;
            DataViewlist = new EmployeeViewModelList();
            if (datalist != null)
            {
                List<EmpViewModel> dataViewModel = new List<EmpViewModel>();
                foreach (Employee Emp in datalist)
                {
                    EmpViewModel data = new EmpViewModel();
                    data.Id = Emp.Id;
                    data.Name = Emp.Name;
                    data.Email = Emp.Email;
                    data.Designation = Emp.Designation;
                    data.Title = "";
                    dataViewModel.Add(data);
                }
                DataViewlist.EmployeeList = dataViewModel;
            }
            return DataViewlist;
        }
        public ActionResult CreateEmp(string MenuID)
        {
            EmpViewModel empViewModel = new EmpViewModel();
            empViewModel.Title = "Add New Employee";
            empViewModel.Id = -1;
            if (MenuID == "3")
                return PartialView("AddEmployee", empViewModel);
            else
                return View("AddEmployee", empViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddEmp([FromBody] EmpViewModel model)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                Employee employee = db.Employee.Where(s => s.Email == model.Email).FirstOrDefault();
                if (employee == null)
                {
                    Employee d = new Employee();
                    d.Email = model.Email;
                    d.Designation = model.Designation;
                    d.Name = model.Name;

                    db.Employee.Add(d);
                    db.SaveChanges();

                    if (d.Id > 0)
                    {
                        msg = "success";
                    }
                }
                else
                {
                    msg = "1";
                    string jsonresult1 = JsonConvert.SerializeObject(msg);
                    return Json(jsonresult1);
                }
            }
            else
            {
                msg = "failed";
            }

            string jsonresult = JsonConvert.SerializeObject(msg);
            return Json(jsonresult);
        }


        public ActionResult ModifyEmp(int Id)
        {
            EmpViewModel Empdata = GetEmpByID(Id);
            if (Empdata != null)
            {
                Empdata.Title = "Modify Employee";

                return PartialView("AddEmployee", Empdata);
            }
            else
            {
                return PartialView("AddEmployee", null);
            }
        }

        public EmpViewModel GetEmpByID(int Id)
        {
            EmpViewModel emp = (from D in db.Employee
                                where D.Id == Id
                                select new EmpViewModel
                                {
                                    Id = D.Id,
                                    Name = D.Name,
                                    Email = D.Email,
                                    Designation = D.Designation
                                }).FirstOrDefault();

            return emp;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateEmp([FromBody] EmpViewModel model)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                Employee employees = db.Employee.Where(s => s.Email == model.Email && s.Id != model.Id).FirstOrDefault();
                if (employees == null)
                {
                    Employee employee = db.Employee.Where(s => s.Id == model.Id).FirstOrDefault();
                    employee.Email = model.Email;
                    employee.Designation = model.Designation;
                    employee.Name = model.Name;
                    int returnValue = db.SaveChanges();
                    if (returnValue > 0)
                    {
                        msg = "success";
                    }
                }
                else
                {
                    msg = "1";
                    string jsonresult1 = JsonConvert.SerializeObject(msg);
                    return Json(jsonresult1);
                }

            }
            string jsonresult = JsonConvert.SerializeObject(msg);
            return Json(jsonresult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteEmployee([FromBody] EmpViewModel model)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                EmployeeDetails employees = db.EmployeeDetails.Where(s => s.Employee.Id == model.Id).FirstOrDefault();
                if (employees == null)
                {
                    Employee employee = db.Employee.Where(s => s.Id == model.Id).FirstOrDefault();
                    db.Remove(employee);
                    db.SaveChanges();
                    msg = "success";
                }
                else
                {
                    msg = "Document already exists";
                }

            }
            string jsonresult = JsonConvert.SerializeObject(msg);
            return Json(jsonresult);
        }

        #endregion


        #region Document

        public EmployeeDetailsViewModel GetDocumentById(int Id)
        {
            try
            {
                EmployeeDetailsViewModel empdetails = (from D in db.EmployeeDetails
                                                       join E in db.Employee on D.Employee.Id equals E.Id
                                                       where D.Id == Convert.ToInt32(Id)
                                                       select new EmployeeDetailsViewModel
                                                       {
                                                           Id = D.Id,
                                                           EmpId = E.Id,
                                                           FileName = D.FileName,
                                                           FilePath = D.FilePath,
                                                           Createddate = D.Createddate
                                                       }).FirstOrDefault();

                return empdetails;
            }
            catch(Exception ex)
            {
                return null;
            }

        }
        
        
        [ValidateAntiForgeryToken]
        public IActionResult GetDocumentListView(string RelatedId)
        {
            EmployeeDetailsListViewModel documentListViewModel = new EmployeeDetailsListViewModel();
            List<EmployeeDetailsViewModel> lst = GetDocumentList(RelatedId);
            if (lst.Count > 0)
            {
                
                documentListViewModel.EmployeeDetailsViewModels = lst;
            }
            else
                documentListViewModel.EmployeeDetailsViewModels = new List<EmployeeDetailsViewModel>();
            documentListViewModel.title = "Documents";
            documentListViewModel.RelatedId = RelatedId;
            return PartialView("DocumentList", documentListViewModel);
        }

        public List<EmployeeDetailsViewModel> GetDocumentList(string RelatedId)
        {
            List<EmployeeDetailsViewModel> datalist = (from D in db.EmployeeDetails 
                                              join E in db.Employee on D.Employee.Id equals E.Id
                                              where D.Employee.Id==Convert.ToInt32(RelatedId)
                                              select new EmployeeDetailsViewModel
                                              {
                                           Id = D.Id,
                                           EmpId = Convert.ToInt32(RelatedId),
                                           FileName = D.FileName,
                                           FilePath = D.FilePath,
                                           Createddate=D.Createddate
                                              }).ToList();

            
            return datalist;
        }
        [ValidateAntiForgeryToken]
        public IActionResult NewDocument(string RelatedId)
        {
            EmployeeDetailsViewModel documentViewModel = new EmployeeDetailsViewModel();
            documentViewModel.RelatedId = RelatedId;
            documentViewModel.Id = -1;
            documentViewModel.title = "Add New Document";
            return PartialView("NewDocument", documentViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateNewDocument(IFormCollection form)
        {
            string msg = "";
            EmployeeDetailsListViewModel documentListViewModel = new EmployeeDetailsListViewModel();
            if (ModelState.IsValid)
            {
                EmployeeDetails d = new EmployeeDetails();
                Employee emp = new Employee();
                d.FileName = form["FileName"];
                emp = db.Employee.Where(s => s.Id == Convert.ToInt32(form["EmpId"])).FirstOrDefault();
                emp.Id = Convert.ToInt32(form["EmpId"]);

                d.Employee = emp;
                Byte[] bytes = null;

                if (form.Files[0].FileName != null)
                {
                    using (MemoryStream ms = new MemoryStream())

                    {
                        form.Files[0].OpenReadStream().CopyTo(ms);

                        bytes = ms.ToArray();

                    }
                }
                d.FilePath = bytes;
                d.Createddate = DateTime.UtcNow.AddHours(4);
                db.EmployeeDetails.Add(d);
                db.SaveChanges();

            }

                EmployeeViewModelList lst = getlist();
                return View("EmployeeList", lst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteDocument([FromBody] EmployeeDetailsViewModel model)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                EmployeeDetails employee = db.EmployeeDetails.Where(s => s.Id == model.Id).FirstOrDefault();
                db.Remove(employee);
                int returnvalue=db.SaveChanges();
                if(returnvalue>0)
                msg = "success";

            }
            string jsonresult = JsonConvert.SerializeObject(msg);
            return Json(jsonresult);
        }

        

        [HttpGet]
        public FileResult DownloadDocument(int Id)
        {

            EmployeeDetailsViewModel datalist = (from D in db.EmployeeDetails
                                                       where D.Id == Id
                                                       select new EmployeeDetailsViewModel
                                                       {
                                                           Id = D.Id,
                                                           FileName = D.FileName,
                                                           FilePath = D.FilePath,
                                                           Createddate = D.Createddate
                                                       }).FirstOrDefault();

            if(datalist!=null)
            return File(datalist.FilePath, "application/pdf", datalist.FileName);
            else
            { return null; 
            }
            }


        #endregion
    }
}
using CoreDemoADO.NET.Data;
using CoreDemoADO.NET.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoApplication.Controllers
{
    public class EmployeesController : Controller
    {


        private readonly IUow _uow;

        public EmployeesController(IUow uow)
        {
            _uow = uow;
        }


        public IActionResult ListEmployees(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var foundEmployees = _uow.StaffRepository.SearchEmployees(search);
                return View(foundEmployees);
            }

            var employees = _uow.StaffRepository.GetAll();
            return View(employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                _uow.StaffRepository.Add(staffMember);

                return RedirectToAction(nameof(ListEmployees));
            }

            return View(staffMember);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employeeModel = _uow.StaffRepository.GetById(id);

            if (employeeModel == null)
            {
                // Redirect user to error view
            }

            return View(employeeModel);
        }


        [HttpPost]
        public ActionResult Edit(StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                _uow.StaffRepository.Edit(staffMember);

                return RedirectToAction(nameof(ListEmployees));
            }

            return View(staffMember);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = _uow.StaffRepository.GetById(id);
            return View(employee);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            _uow.StaffRepository.Delete(id);

            return RedirectToAction(nameof(ListEmployees));
        }


    }
}

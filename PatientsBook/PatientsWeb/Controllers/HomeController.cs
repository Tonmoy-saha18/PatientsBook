using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientsWeb.Data;
using PatientsWeb.Models;
using System.Diagnostics;
using System.Text;

namespace PatientsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Country> CountryList = _db.Countries.ToList();
            List<Customer> CustomerList = _db.Customers.ToList();
            var tupleList = new Tuple<List<Country>, List<Customer>>(CountryList, CustomerList);
            return View(tupleList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetDetails(string Name, string FatherName, string MotherName, int flexradio, int country, IFormFile photo, string address)
        {
            byte[] photoData = null;
            using (var binaryReader = new BinaryReader(photo.OpenReadStream()))
            {
                photoData = binaryReader.ReadBytes((int)photo.Length);
            }

            var customer = new Customer
            {
                CustomerName = Name,
                FatherName = FatherName,
                MotherName = MotherName,
                MaritialStatus = flexradio,
                CustomerPhoto = photoData,
                CustomerAddress = address,
                CountryId = country
            };

            _db.Customers.Add(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            _db.Customers.Remove(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Privacy(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using demoapiconsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace demoapiconsume.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7135/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Get Method
                HttpResponseMessage response = await client.GetAsync("api/Employee/");
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    List<EmployeeModel> _OEmployee = JsonConvert.DeserializeObject<List<EmployeeModel>>(result);
                    return View(_OEmployee);
                }
                else
                {
                    return View();
                }
            }
        }





        [HttpGet]
        public IActionResult Create()
        {
            string _guid = Guid.NewGuid().ToString();
            ViewBag.EmployeeId = _guid;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel employeeModel)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(employeeModel);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:7135/api/Employee";

                HttpResponseMessage response = await client.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    TempData["AlertMsg"] = "Record has been succesfully saved";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }




        [HttpGet]
        public async Task<IActionResult> EditEmployee(Guid Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7135/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Get Method
                HttpResponseMessage response = await client.GetAsync("api/Employee/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var result =  response.Content.ReadAsStringAsync().Result;
                    EmployeeModel _OEmployee = JsonConvert.DeserializeObject<EmployeeModel>(result);
                    return View(_OEmployee);
                }
                else
                {
                    return View();
                }
            }

        }


        [HttpPost]
        public async Task<IActionResult> EditEmployee(Guid Id, EmployeeModel employeeModel)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(employeeModel);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:7135/api/Employee/" + Id;

                //HttpResponseMessage response = await client.PutAsync(url, data);
                HttpResponseMessage response = await client.PatchAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    //string result = response.Content.ReadAsStringAsync().Result;
                    TempData["AlertMsg"] = "Record has been succesfully saved";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetEmployee(Guid Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7135/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Get Method
                HttpResponseMessage response = await client.GetAsync("api/Employee/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    EmployeeModel _OEmployee = JsonConvert.DeserializeObject<EmployeeModel>(result);
                    return View(_OEmployee);
                }
                else
                {
                    return View();
                }
            }
        }






        //[HttpPost]
        public async Task<IActionResult> DeleteEmployee(Guid Id)
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:7135/api/Employee/" + Id;

                HttpResponseMessage response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    //string result = response.Content.ReadAsStringAsync().Result;
                    TempData["AlertMsg"] = "Record has been succesfully deleted";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}

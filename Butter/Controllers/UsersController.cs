using Butter.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Butter.Controllers
{
    public class UsersController : Controller
    {

        HttpClient client = new HttpClient();

        public IActionResult Index()
        {

            client.BaseAddress = new Uri("https://localhost:7199/");
            HttpResponseMessage response = client.GetAsync("api/users").Result;
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                IEnumerable<UserModel> users = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<UserModel>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

                return View(users);
            }
            return View();
            ////2- Appel du Get
            //IEnumerable<UserModel> users = monRepo.Get();         
            ////3- je renvoie
            //return View(users);
        }

        public IActionResult Details(int Id) 
        {
            client.BaseAddress = new Uri("https://localhost:7199/");
            HttpResponseMessage response = client.GetAsync($"api/users/{Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                UserDetails user = System.Text.Json.JsonSerializer.Deserialize<UserDetails>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                if(user is null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Index","Home") ;
            }

            //2 je récup le model
            //UserModel lol = monRepo.GetById(Id);
            //return View(lol);
        }

        public IActionResult Delete(int id)
        {
            client.BaseAddress = new Uri("https://localhost:7199/");
            HttpResponseMessage response = client.DeleteAsync($"api/users/delete/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserAdd u)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.BaseAddress = new Uri("https://localhost:7199/");
            HttpResponseMessage response = client.PostAsync($"api/users/create",httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<UserModel>(json);

                // autre chose que singleOrDefault dans le UserRepository (coté api)
                return RedirectToAction("Details", new { id = user.UserId});
            }
            
            return View(u);
        }

    }
}

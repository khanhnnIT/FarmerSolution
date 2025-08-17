using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FarmerWebClient.Controllers
{
    public class FarmerController : Controller
    {
        private readonly HttpClient client = null;
        private string FarmerApiUrl;
        public FarmerController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            FarmerApiUrl = "https://localhost:7095/api/Farmer";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(FarmerApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Farmer>? listFarmer = JsonSerializer.Deserialize<List<Farmer>>(strData, options);
            return View(listFarmer);
        }

        private async Task<bool> CheckFarmerCodeExists(string code)
        {
            HttpResponseMessage response = await client.GetAsync(FarmerApiUrl + "/by-code?code=" + code);
            string strData = await response.Content.ReadAsStringAsync();
            return strData != "";
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Farmer farmer)
        {
            if (farmer.FarmerName.IsNullOrEmpty())
            {
                ModelState.AddModelError(nameof(Farmer.FarmerName), "Farmer name is not empty.");
                return View(farmer);
            }
            var usernameExists = await CheckFarmerCodeExists(farmer.FarmerCode);
            if (usernameExists)
            {
                ModelState.AddModelError(nameof(farmer.FarmerCode), "Farmer code already exists.");
                return View(farmer);
            }
            
            string jsonData = JsonSerializer.Serialize(farmer);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(FarmerApiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to create Farmer.");
            }
            return View(farmer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            HttpResponseMessage response = await client.GetAsync(FarmerApiUrl + "/farmer?id=" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Farmer farmer = JsonSerializer.Deserialize<Farmer>(strData, options);
            return View(farmer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Farmer farmer)
        {
            string jsonData = JsonSerializer.Serialize(farmer);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(FarmerApiUrl + "/" + farmer.FarmerId, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to update Farmer.");
            }
            return View(farmer);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            HttpResponseMessage response = await client.GetAsync(FarmerApiUrl + "/farmer?id=" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Farmer Farmer = JsonSerializer.Deserialize<Farmer>(strData, options);
            return View(Farmer);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await client.GetAsync(FarmerApiUrl + "/farmer?id=" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Farmer farmer = JsonSerializer.Deserialize<Farmer>(strData, options);
            return View(farmer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFarmer(Guid farmerId)
        {
            if (string.IsNullOrEmpty(farmerId.ToString()))
            {
                ModelState.AddModelError(string.Empty, "Farmer ID is missing.");
                return View("Error");
            }
            HttpResponseMessage response = await client.DeleteAsync($"{FarmerApiUrl}/{farmerId}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete Farmer.");
            }
            return View();
        }
    }
}

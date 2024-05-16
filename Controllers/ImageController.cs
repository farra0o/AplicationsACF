
using System.Text.Json;
using AplicationACF.Models;
using Microsoft.AspNetCore.Mvc;
using AplicationACF.ViewModels;


namespace AplicationACF.Controllers
{
    public class ImageController:Controller
    {
        readonly string apiUrl = "https://jsonplaceholder.typicode.com/photos";

        public async Task<ActionResult> Index(int page = 1, int pageSize = 10)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var photoItems = JsonSerializer.Deserialize<List<ImageEntity>>(json);

                    var totalCount = photoItems.Count;
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                    photoItems = photoItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                    var viewModel = new ImageViewModel
                    {
                        PhotoItems = photoItems,
                        CurrentPage = page,
                        TotalPages = totalPages,
                        PageSize = pageSize
                    };

                    return View(viewModel);
                }
                
                else
                {
                    // Handle error response
                    return View("Error");
                }
            }
        }
    }
}



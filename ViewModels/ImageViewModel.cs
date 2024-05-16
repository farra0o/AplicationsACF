using AplicationACF.Models;

namespace AplicationACF.ViewModels
{
    public class ImageViewModel
    {
        public List<ImageEntity> PhotoItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}

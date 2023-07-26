using System;

namespace LEMV.Application.ViewModels
{
    public class MediaInfoViewModel
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Format { get; set; }
        public double Size { get; set; } //In Megabytes        
    }
}

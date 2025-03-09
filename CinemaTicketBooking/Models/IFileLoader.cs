using CinemaTicketBooking.Models.Entities;
using CinemaTicketBooking.Models.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaTicketBooking.Models
{
    public interface IFileLoader
    {
        Picture? Save(Picture oldPicture, IFormFile formFile, ModelStateDictionary ModelState);
    }
}

using CinemaTicketBooking.Models.Entities;
using Microsoft.AspNetCore.Http;
using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Models.ValidationAttributes
{
    public class PictureAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not IFormFile file)
                return true;

            string extension = file.FileName[file.FileName.LastIndexOf('.')..];

            if (extension != ".jpg" && extension != ".png")
            {
                ErrorMessage = "File type is not supported";

                return false;
            }

            if (file.Length > 10000000L)
            {
                ErrorMessage = "File size is too large";

                return false;
            }

            return true;
        }

        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    if (value is not IFormFile file)
        //        return ValidationResult.Success;

        //    string extension = file.FileName[file.FileName.LastIndexOf('.')..];

        //    if (extension != ".jpg" && extension != ".png")
        //        return new ValidationResult("File type is not supported");

        //    if (file.Length > 10000000L)
        //        return new ValidationResult("File size is too large");

        //    return ValidationResult.Success;
        //}
    }
}

using CinemaTicketBooking.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaTicketBooking.Models
{
    public class PictureLoader : IFileLoader
    {
        public Picture? Save(Picture oldPicture, IFormFile formFile, ModelStateDictionary modelState)
        {
            //check that formfile is not null else return old picture

            byte[] formPictureContent;

            try
            {
                formPictureContent = new byte[formFile.Length];

                formFile.OpenReadStream().Read(formPictureContent, 0, (int)formFile.Length);
            }
            catch
            {
                modelState.Remove(nameof(Picture));
                return oldPicture;
            }

            //if the content is same return old picture else return new picture

            byte[] oldPictureContent = new byte[formFile.Length];

            try
            {
                oldPictureContent = File.
                    ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", oldPicture.UniqueName));

            }
            catch(NullReferenceException)
            {

            }
            catch(Exception ex)
            {
                return oldPicture;
            }

            if (!oldPictureContent.SequenceEqual(formPictureContent)) 
            {
                Picture picture = new();

                string extension = formFile.FileName[formFile.FileName.LastIndexOf('.')..];

                //check that extension is jpg or png
                //if (extension != ".jpg" && extension != ".png")
                //{
                //    modelState.AddModelError(nameof(Picture), "The file type is not supported");
                //    return oldPicture;
                //}

                //if (formFile.Length > 10000000L)
                //{
                //    modelState.AddModelError(nameof(Picture), "The file size is too large.");
                //    return oldPicture;
                //}

                if(!oldPictureContent.All(b => b==0))
                {
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", oldPicture.UniqueName));
                }

                string fileNameAtServer = Guid.NewGuid().ToString() + extension;

                picture.UniqueName = fileNameAtServer;

                string filePathAtServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileNameAtServer);

                using (FileStream file = new FileStream(filePathAtServer, FileMode.OpenOrCreate))
                {
                    formFile.CopyTo(file);
                }
                

                picture.FilenameAtClient = formFile.FileName;

                modelState.Remove(nameof(Picture));
                return picture;
            }

            modelState.Remove(nameof(Picture));
            return oldPicture;

        }
    }
}

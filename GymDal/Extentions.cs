using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace GymDal
{
    public static class Extentions
    {

        public static IEnumerable<TSource> FromHierarchy<TSource>(
        this TSource source,
        Func<TSource, TSource> nextItem,
        Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        public static string GetAllMessages(this Exception exception)
        {
            var messages = exception.FromHierarchy(ex => ex.InnerException)
                .Select(ex => ex.Message);
            return String.Join(Environment.NewLine, messages);
        }
        public static Image ScaleImage(this Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }



        public static string ConvertTo64BaseString(this Image image)
        {




            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }

        }


        public static Image Base64StringToImage(this string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }


    }


    public partial class Customer
    {


        public string PaymentState
        {
            get
            {
                return IsObligor ? "Overdue" : "OK";
            }
        }

        public bool IsObligor
        {
            get
            {

                var last = Payments.OrderByDescending(p => p.TimeStamp).FirstOrDefault();
                if (last == null) return true; // no payments
                return last.To < DateTime.Now;
            }
        }
    }

    public partial class Workout
    {
        public string ExerciseName { get { return WorkoutExercise.Name; } }
    }


}

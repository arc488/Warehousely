using System;

namespace Utils
{
    public class ImageRelated
    {
        public string ConvertImageString(byte[] content)
        {
            var imageString = string.Empty;

            if (content != null)
            {
                imageString = Convert.ToBase64String(content);
            }

            return imageString;
        }
    }
}

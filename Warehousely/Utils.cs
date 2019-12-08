using System;

public class Utils
{
	public string CreateImageString(ImageFile imageFile)
	{

		var convertedString = "";

		if (imageFile.Image != null)
		{
			convertedString = Convert.ToBase64String(imageFile.Content);
		}
		else
		{
			productDetailViewModel.Image = string.Empty;
		}
	}
}

using OpenCvSharp;

namespace OpenCV_CS
{
	public class RotateImage
	{
		public RotateImage(string image_path)
		{
			var img = Cv2.ImRead(image_path);

			Cv2.ImShow("image0", img);


			img.RotateImage(90, 1);
			Cv2.ImShow("image1", img);

			Cv2.WaitKey(0);
			
		}
	}
}
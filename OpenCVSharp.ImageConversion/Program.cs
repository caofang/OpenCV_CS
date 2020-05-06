using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Point = OpenCvSharp.Point;
using Size = OpenCvSharp.Size;

namespace OpenCVSharp.ImageConversion
{
	class Program
	{
		private static void ShowImage(string src)
		{
			using (var img = new Mat(src, ImreadModes.Grayscale))
			{
				using (var window = new Window("window", image: img, flags: WindowMode.AutoSize))
				{
					Cv2.WaitKey();
				}
			}
		}

		private static void ShowImage_BitMap(string src)
		{
			using (var img = new Mat(src, ImreadModes.Grayscale))
			{
				var img_bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img);
				var img_mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(img_bitmap);

				using (var window = new Window("window"))
				{
					window.Image = img_mat;
					Cv2.WaitKey();
				}
			}
		}

		static void Main(string[] args)
		{
			var img_src = @"C:\Users\Owner\Desktop\icons\OpenCV_CS\photo.jpg";

			//ShowImage(img_src);
			ShowImage_BitMap(img_src);
		}
	}
}

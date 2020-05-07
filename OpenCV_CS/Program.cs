using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Point = OpenCvSharp.Point;
using Size = OpenCvSharp.Size;

namespace OpenCV_CS
{
	class Program
	{
		static void Main(string[] args)
		{
			VideoCapture capture = new VideoCapture(0);

			var width = (int) capture.Get(3);
			var height = (int) capture.Get(4);

			var codec = VideoWriter.FourCC('M', 'J', 'P', 'G');
			var output = new VideoWriter("myVideo.avi", codec, 60, new Size(width, height));
			var count = 0;

			using (Window window = new Window("Camera"))
			using (Mat image = new Mat()) // Frame image buffer
			{
				// When the movie playback reaches end, Mat.data becomes NULL.
				while (true)
				{
					capture.Read(image); // same as cvQueryFrame
					if (image.Empty())
						break;

					var timestamp = string.Format("{0:HH:mm:ss.fff}", DateTime.Now);
					var text = string.Format("Frame: {0}, timestamp {1}", count.ToString(), timestamp);
				
					image.PutText(text, new Point(5, 50), HersheyFonts.HersheySimplex, 1, new Scalar(0,0,255), 1, LineTypes.AntiAlias);

					output.Write(image);
					window.ShowImage(image);

					if ((Cv2.WaitKey(1) & 0xFF) == 'q')
					{
						break;
					}

					count++;
				}

				capture.Release();
				output.Release();
			}
		}
	}
}

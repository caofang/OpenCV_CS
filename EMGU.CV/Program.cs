using System;
using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;

namespace Emgu_CV_Example
{
	class Program
	{
		static void Main(string[] args)
		{
			ImageViewer viewer = new ImageViewer();

			var capture = new Capture(0);

			var width = capture.Width;
			var height = capture.Height;

			var codec = VideoWriter.Fourcc('M', 'J', 'P', 'G');
			var output = new VideoWriter("myVideo.avi", codec, 60, new Size(width, height), true);


			// When the movie playback reaches end, Mat.data becomes NULL.
			Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
			{  
				viewer.Image = capture.QueryFrame(); //draw the image obtained from camera

				var image = capture.QueryFrame();

				//output.Write(image);
				viewer.Image = image;

			});
			viewer.ShowDialog();
			//while (true)
			//{
			//	var image = capture.QueryFrame();
			//	if (image.IsEmpty)
			//		break;

			//	output.Write(image);
			//	viewer.Image = image;				

			//	if ((CvInvoke.WaitKey(1) & 0xFF) == 'q')
			//	{
			//		break;
			//	}
			//}

			capture.Dispose();
			output.Dispose();
			
		}
	}
}

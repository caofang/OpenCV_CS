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
			ListCamera.ListAllAttachedCameras();

			//var capture = new Video_Capture(0, 30);
			//capture.StartCapture();
		}
	}
}

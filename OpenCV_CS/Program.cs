﻿using System;
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


			//var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\GaitRite3D_Videos\portugal_team.jpg"; 
			//var r =  new RotateImage(path);

			//var capture = new Video_Capture(2, 30);
			//capture.StartCapture();
		}
	}
}

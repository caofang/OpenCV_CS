using System;
using System.ComponentModel.Design;
using OpenCvSharp;

namespace OpenCV_CS
{
	public class Video_Capture
	{

		private VideoCapture _capture;
		private int _count;
		private VideoWriter _output;
		private Window _window;

		private bool _isRecording = false;

		public Video_Capture(int cameraIdx, int fps)
		{
			_capture = new VideoCapture(cameraIdx);

			var width = (int)_capture.Get(3);
			var height = (int)_capture.Get(4);

			var codec = VideoWriter.FourCC('M', 'J', 'P', 'G');
			_output = new VideoWriter("myVideo.avi", codec, fps, new Size(width, height));
			_count = 0;

			_window = new Window("Camera", WindowMode.KeepRatio);
		}

		public void StartRecording()
		{
			_isRecording = true;
		}

		public void StopRecording()
		{
			_isRecording = false;
		}

		public void StartCapture()
		{
			
			using (Mat image = new Mat()) // Frame image buffer
			{
				// When the movie playback reaches end, Mat.data becomes NULL.
				while (true)
				{
					_capture.Read(image); // same as cvQueryFrame
					if (image.Empty())
						break;

					var timestamp = string.Format("{0:HH:mm:ss.fff}", DateTime.Now);
					var text = string.Format("Frame: {0}, timestamp {1}", _count.ToString(), timestamp);

					image.PutText(text, new Point(5, 50), HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255), 1,
						LineTypes.AntiAlias);

					if(_isRecording)
						_output.Write(image);

					_window.ShowImage(image);

					if ((Cv2.WaitKey(1) & 0xFF) == 'q')
					{
						break;
					}

					_count++;
				}
			}


		}

		public void StopCapture()
		{
			_capture.Release();
			_output.Release();
		}				
	}
}
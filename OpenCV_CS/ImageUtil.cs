using System;
using OpenCvSharp;

namespace OpenCV_CS
{
	public static class ImageUtil
	{
		public static void RotateImage(this Mat src, double angle, double scale)
		{
			var h = src.Height;
			var w = src.Width;
			var cx = src.Cols / 2f;
			var cy = src.Rows / 2f;

			var imageCenter = new Point2f(cx, cy);
			var rotationMat = Cv2.GetRotationMatrix2D(imageCenter, angle, scale);


			var indexer = rotationMat.GetGenericIndexer<double>();

			var cos = Math.Abs(indexer[0, 0]);
			var sin = Math.Abs(indexer[0, 1]);

			var nW = (int)(h * sin + w * cos);
			var nH = (int)(h * cos + w * sin);


			indexer[0, 2] += (nW / 2) - cx;
			indexer[1, 2] += (nH / 2) - cy;


			var size = new OpenCvSharp.Size(nW,nH);

			Cv2.WarpAffine(src, src, rotationMat, size);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.MediaFoundation;

namespace OpenCV_CS
{
	public class ListCamera
	{
		public static int GetCameraIndexForPartName(string partName)
		{
			var cameras = GetListOfAttachedCameras();
			for (var i = 0; i < cameras.Count(); i++)
			{
				if (cameras[i].ToLower().Contains(partName.ToLower()))
				{
					return i;
				}
			}

			return -1;		
		}

		public static List<string> GetListOfAttachedCameras()
		{
			var cameras = new List<string>();
			var attributes = new MediaAttributes(1);
			attributes.Set(CaptureDeviceAttributeKeys.SourceType.Guid, CaptureDeviceAttributeKeys.SourceTypeVideoCapture.Guid);
			var devices = MediaFactory.EnumDeviceSources(attributes);

			for (var i = 0; i < devices.Count(); i++)
			{
				var friendlyName = devices[i].Get(CaptureDeviceAttributeKeys.FriendlyName);
				cameras.Add(friendlyName);
			}
			return cameras;
		}

		public static void ListAllAttachedCameras()
		{
			var cameras = new List<string>();
			var attributes = new MediaAttributes(1);
			attributes.Set(CaptureDeviceAttributeKeys.SourceType.Guid, CaptureDeviceAttributeKeys.SourceTypeVideoCapture.Guid);
			var devices = MediaFactory.EnumDeviceSources(attributes);

			for (var i = 0; i < devices.Count(); i++)
			{
				var friendlyName = devices[i].Get(CaptureDeviceAttributeKeys.FriendlyName);
				cameras.Add(friendlyName);
			}

			foreach (var camera in cameras)
			{
				Console.WriteLine("{0} {1}", cameras.IndexOf(camera), camera);
			}

			Console.ReadKey();
		}
	}
}




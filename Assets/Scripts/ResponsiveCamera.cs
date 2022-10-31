using UnityEngine;
using System.Collections;

namespace StandardAssets {
	/// <summary>
	/// Set the view rect of the Camera to the given Aspect Ratio
	/// </summary>
	[ExecuteInEditMode]
	public class ResponsiveCamera : MonoBehaviour {

		Camera cam;
		/// <summary>
		/// set the desired aspect ratio. (16:9 = 1.777778)
		/// </summary>
		public float targetAspect;
		/// <summary>
		/// The final view rectangle
		/// </summary>
		public static Rect rect;
		/// <summary>
		/// Are the boxes on top(true) or on the side(false)
		/// </summary>
		public static bool letterbox;

		void Start() {
			// determine the game window's current aspect ratio
			float windowaspect = (float)Screen.width / (float)Screen.height;

			// current viewport height should be scaled by this amount
			float scaleheight = windowaspect / targetAspect;

			// obtain camera component so we can modify its viewport
			Camera camera = GetComponent<Camera>();

			// if scaled height is less than current height, add letterbox
			if (scaleheight < 1.0f) {
				letterbox = true;
				rect = camera.rect;

				rect.width = 1.0f;
				rect.height = scaleheight;
				rect.x = 0;
				rect.y = (1.0f - scaleheight) / 2.0f;

				camera.rect = rect;
			} else // add pillarbox
			  {
				letterbox = false;
				float scalewidth = 1.0f / scaleheight;

				Rect rect = camera.rect;

				rect.width = scalewidth;
				rect.height = 1.0f;
				rect.x = (1.0f - scalewidth) / 2.0f;
				rect.y = 0;

				camera.rect = rect;
			}
		}

		// Update is called once per frame
		void Update() {
			Start();
		}

		public static partial class Maths {
			public static float PixelToRect(float y) {
				return (Screen.height - y);
			}
		}

		Color oldColor = Color.black;
		public Color borderColor;

		public Texture2D _border;
		public Texture border {
			get {
				if (_border == null || borderColor != oldColor) {
					_border = new Texture2D(1, 1, TextureFormat.RGB24, false);
					_border.SetPixel(1, 1, (Color)borderColor);
					_border.Apply();
					oldColor = borderColor;
				}

				return _border;
			}
		}

		void OnGUI() {
			//Ensure were on the top
			GUI.depth = 10;

			if (!ResponsiveCamera.letterbox) {
				GUI.DrawTexture(new Rect(0, 0, Camera.main.pixelRect.x, GetComponent<Camera>().pixelRect.height), border);
				GUI.DrawTexture(new Rect(Camera.main.pixelRect.width + Camera.main.pixelRect.x, 0, Camera.main.pixelRect.width, GetComponent<Camera>().pixelRect.height), border);
			} else {
				GUI.DrawTexture(new Rect(0, 0, Camera.main.pixelRect.width, Camera.main.pixelRect.y), border);
				GUI.DrawTexture(new Rect(0, Maths.PixelToRect(Camera.main.pixelRect.y), Camera.main.pixelRect.width, Camera.main.pixelRect.y), border);
			}
		}
		
	}
}	

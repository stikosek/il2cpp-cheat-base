using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using HarmonyLib;

namespace Il2Cpp_Cheat_Base.Gui
{
	public class EspUtilities : MonoBehaviour
	{

		public static void DrawEsp(Vector3[] positions,int pivotup,int pivotdown)
        {
			foreach (Vector3 pos in positions)
			{
				//In-Game Position
				Vector3 pivotPos = pos; //Pivot point NOT at the feet, at the center
				Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f; //At the feet
				Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f; //At the head

				//Screen Position
				Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
				Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

				if (w2s_footpos.z > 0f)
				{
					DrawBoxESP(w2s_footpos, w2s_headpos, Color.red);
				}
			}
		}

		public static void DrawBoxESP(Vector3 footpos, Vector3 headpos, Color color) //Rendering the ESP
		{
			float height = headpos.y - footpos.y;
			float widthOffset = 2f;
			float width = height / widthOffset;

			//ESP BOX
			DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 2f);

			//Snapline
			DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(footpos.x, (float)Screen.height - footpos.y), color, 2f);
		}

		public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

		public static Color Color
		{
			get { return GUI.color; }
			set { GUI.color = value; }
		}

		public static void DrawString(Vector2 position, string label, bool centered = true)
		{
			var content = new GUIContent(label);
			var size = StringStyle.CalcSize(content);
			var upperLeft = centered ? position - size / 2f : position;
			GUI.Label(new Rect(upperLeft, size), content);
		}

		public static Texture2D lineTex;
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
		{
			Matrix4x4 matrix = GUI.matrix;
			if (!lineTex)
				lineTex = new Texture2D(1, 1);

			Color color2 = GUI.color;
			GUI.color = color;
			float num = Vector3.Angle(pointB - pointA, Vector2.right);

			if (pointA.y > pointB.y)
				num = -num;

			GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
			GUIUtility.RotateAroundPivot(num, pointA);
			GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
			GUI.matrix = matrix;
			GUI.color = color2;
		}

		public static void DrawBox(float x, float y, float w, float h, Color color, float thickness)
		{
			DrawLine(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
			DrawLine(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
			DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
			DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
		}
	}
}

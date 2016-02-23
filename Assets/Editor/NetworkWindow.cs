using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NetworkWindow : EditorWindow {
	public static NetworkWindow instance { get; private set; }

	[MenuItem("Wcat/Tools/Network Window Panel")]
	public static void Open()
	{
		EditorWindow.GetWindow<NetworkWindow>(false, "NetworkWindow");
	}

	Vector2 scrollPos = Vector2.zero;
	bool autoScroll = true;
	
	void OnGUI() {
		GUILayout.BeginHorizontal();

		autoScroll = GUILayout.Toggle(autoScroll, "AutoScroll");
		
		if ( GUILayout.Button ("Clear") )
		{
			NetworkLogManager.instance.ClearLogs();
		}

		GUILayout.EndHorizontal();



		GUILayout.BeginVertical();

		scrollPos = GUILayout.BeginScrollView(scrollPos);
		float height = 30f;
		foreach (var log in NetworkLogManager.instance.GetLogs()) {
			var text = log.url;
			if (log.type == NetworkLogManager.NetworkLogType.Post) {
				text = "Post -> " + text;
				GUI.backgroundColor = Color.black;
				GUI.contentColor = new Color(0.3f, 1f, 0.3f);
			} else {
				GUI.backgroundColor = Color.black;
				text = "Response <- " + text;
				GUI.contentColor = new Color(0.5f, 0.5f, 1f);
			}
			if (!string.IsNullOrEmpty(log.data)) {
				var length = Mathf.Min(log.data.Length, (int)(position.width / 6));
				text += "\n" + log.data.Substring(0, length);
			}
			if (GUILayout.Button(text, GUILayout.Height(50f))) {
				var path = System.Uri.EscapeUriString("file://" + GetLogHtmlPath(log.data));
				Application.OpenURL(path);
			}
			
			height += 54f;
		}
		GUILayout.EndScrollView();
		
		if (autoScroll) {
			var scrollTo = Mathf.Max(height - position.height);
			scrollPos.y = scrollTo;
		}
		
		GUILayout.EndVertical ();
	}
	
	void OnInspectorUpdate()	
	{
		Repaint();
	}
	
	void Update() {
		instance = this;
	}
	
	string GetLogHtmlPath(string log) {
		string htmlString = "";
		htmlString += "<HTML>\n";
		htmlString += "<meta charset=\"UTF-8\"><HEAD><style type=\"text/css\">\n<!--\nbody {word-break: break-all;}\n-->\n</style></HEAD>";
		htmlString += "<BODY>";
		htmlString += log;
		htmlString += "</BODY>";
		htmlString += "\n</HTML>";
		
		string path = Path.Combine(Application.temporaryCachePath, "NetworkView.html");
		if (File.Exists(path)) {
			File.Delete(path);
		}
		File.WriteAllText(path, htmlString);
		
		
		Debug.Log("Path:" + path);
		return path;
	}
}

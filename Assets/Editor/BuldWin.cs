using UnityEditor;
using UnityEngine;
using System;
using System.IO;

public static class BuildWin
{
	static void BuildWindows()
	{
		var folderName = "Build-Windows";
		DeleteFolder (folderName);
		CreateFolder (folderName);
		string error = BuildPipeline.BuildPlayer(GetScenes(), folderName, BuildTarget.StandaloneWindows, BuildOptions.None).ToString();
		if (error != null && error.Length > 0)
		{
			throw new Exception("Build failed: " + error);
		}
	}

	static void CreateFolder(string name)
	{
		if (!Directory.Exists(name))
		{
			Directory.CreateDirectory(name);
		}
	}

	static void DeleteFolder(string name)
	{
		if (Directory.Exists(name))
		{
			Directory.Delete(name, true);
		}
	}

	static string[] GetScenes()
	{
		string[] scenes = new string[EditorBuildSettings.scenes.Length];
		for(int i = 0; i < scenes.Length; i++)
		{
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}
		return scenes;
	}
}

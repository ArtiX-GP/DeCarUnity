using UnityEditor;
using UnityEngine;
using System;
using System.IO;

class BuildWin
{
	static void BuildWindows()
	{
		var folderName = "Build-Windows";
		//DeleteFolder (folderName);
		//CreateFolder (folderName);
		BuildPipeline.BuildPlayer(GetScenes(), folderName, BuildTarget.StandaloneWindows64, BuildOptions.None);
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

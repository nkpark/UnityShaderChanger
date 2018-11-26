using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플랫폼 별 셰이더 교체 처리
/// </summary>
public class ShaderChanger : MonoBehaviour {

	[System.Serializable]
	public class ShaderChangeData
	{
		public RuntimePlatform Platform;
		public string ShaderPath;
		public Renderer target;

		// public ShaderChangeData()
		// {
		// 	Platform = RuntimePlatform.IPhonePlayer;
		// 	ShaderPath = "Mobile/Diffuse";			
		// }

	}
	
	public List<ShaderChangeData> scDatas;

	void Start () 
	{
		RefreshShader();
	}
	
	[ContextMenu("RefreshShader")]
	public void RefreshShader()
	{
		if (scDatas == null) return;

		ShaderChangeData data = scDatas.Find(r=> r.Platform == Application.platform);
		if (data != null)
		{
			Renderer[] rends = data.target.GetComponentsInChildren<Renderer>();
			int rendCount = rends.Length;
			for (int i = 0; i < rendCount; i++)
			{
				int sdCount = rends[i].materials.Length;
				for (int s = 0; s < sdCount; s++)
				{
					rends[i].materials[s].shader = Shader.Find(data.ShaderPath);
				}
			}
		}

		//IOS or MacOS UnityEditor
		//if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXEditor)		
		//else //Android or Windows UnityEditor
	}
	
}

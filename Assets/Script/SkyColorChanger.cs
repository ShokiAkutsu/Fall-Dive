using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColorChanger : MonoBehaviour
{
	Camera mainCamera;              // 対象カメラ

	[Header("ゲーム始まりの空の色")]
	[SerializeField] Color startColor = new Color(0f, 0.1f, 0.3f);  // 高空：暗めの青
	[Header("ゲーム終わりの空の色")]
	[SerializeField] Color endColor = new Color(0.5f, 0.8f, 1f);    // 地上：明るい空色
	[Header("落下時間(ゲーム時間)")]
	[SerializeField]float fallDuration = 10f;       // 落下時間（秒）
	
	float timer = 0f;

	void Start()
	{
		if (mainCamera == null)
		{
			mainCamera = Camera.main;
		}

		mainCamera.backgroundColor = startColor;
	}

	void Update()
	{
		timer += Time.deltaTime;
		float t = Mathf.Clamp01(timer / fallDuration);

		mainCamera.backgroundColor = Color.Lerp(startColor, endColor, t);
	}
}

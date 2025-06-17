using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColorChanger : MonoBehaviour
{
	Camera mainCamera;              // �ΏۃJ����

	[Header("�Q�[���n�܂�̋�̐F")]
	[SerializeField] Color startColor = new Color(0f, 0.1f, 0.3f);  // ����F�Â߂̐�
	[Header("�Q�[���I���̋�̐F")]
	[SerializeField] Color endColor = new Color(0.5f, 0.8f, 1f);    // �n��F���邢��F
	[Header("��������(�Q�[������)")]
	[SerializeField]float fallDuration = 10f;       // �������ԁi�b�j
	
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

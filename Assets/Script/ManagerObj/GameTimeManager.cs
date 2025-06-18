using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
	[Header("��������(�Q�[������)")]
	[SerializeField] float _fallDuration = 30f;		// �������ԁi�b�j

	float _timer;									// �o�ߎ��ԁi�b�j

	void Start()
	{
		
	}

	void Update()
	{
		_timer += Time.deltaTime;
	}

	public float GetRatioTime()
	{
		//0����v�Z���Ă��邽�߁A�P�C�Q�����𔽓]���Ă���
		return Mathf.InverseLerp(_fallDuration, 0f, _timer);
	}
}

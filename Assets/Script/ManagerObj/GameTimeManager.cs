using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
	[Header("落下時間(ゲーム時間)")]
	[SerializeField] float _fallDuration = 30f;		// 落下時間（秒）

	float _timer;									// 経過時間（秒）

	void Start()
	{
		
	}

	void Update()
	{
		_timer += Time.deltaTime;
	}

	public float GetRatioTime()
	{
		//0から計算しているため、１，２引数を反転している
		return Mathf.InverseLerp(_fallDuration, 0f, _timer);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
	[Header("—‰ºŠÔ(ƒQ[ƒ€ŠÔ)")]
	[SerializeField] float _fallDuration = 30f;		// —‰ºŠÔi•bj

	float _timer;									// Œo‰ßŠÔi•bj

	void Start()
	{
		
	}

	void Update()
	{
		_timer += Time.deltaTime;
	}

	public float GetRatioTime()
	{
		//0‚©‚çŒvZ‚µ‚Ä‚¢‚é‚½‚ßA‚PC‚Qˆø”‚ğ”½“]‚µ‚Ä‚¢‚é
		return Mathf.InverseLerp(_fallDuration, 0f, _timer);
	}
}

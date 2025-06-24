using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Playerの移動スピード")]
	[SerializeField] float _moveSpeed = 5f;

	[SerializeField] BirdEndManager _birdEndManager;

	float _rangePosX = 8f;	// ±X座標の制限範囲
	float _posX;			// 制限範囲内のX座標添え字

	/// <summary>水平方向の入力値</summary>
	float _horizontal;

	Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		_horizontal = Input.GetAxis("Horizontal"); // ←→キー or A/D

		//PlayerのX座標を制限させる
		_posX = Mathf.Clamp(this.transform.position.x, -(_rangePosX), _rangePosX);
		this.transform.position = new Vector3(_posX, transform.position.y, 0f);
	}

	private void FixedUpdate()
	{
		//横移動(X座標の移動)　着地モードでY軸動かすため
		_rb.velocity = new Vector2(_moveSpeed * _horizontal, _rb.velocity.y);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// ゴールの女の子に到達
		if (collision.CompareTag("Goal"))
		{
			_birdEndManager.TriggerEnding("Goal");
			return;
		}

		// 鳥に衝突した場合
		if(collision.tag == "Bird")
		{
			string birdName = collision.name.Replace("Prefab(Clone)", "");
			if (birdName != null)
			{
				Debug.Log(birdName);
				_birdEndManager.TriggerEnding(birdName);
			}
		}
	}
}

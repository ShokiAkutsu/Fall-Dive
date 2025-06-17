using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Playerの移動スピード")]
	[SerializeField] float _moveSpeed = 5f;

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
	}

	private void FixedUpdate()
	{
		//横移動
		_rb.velocity = new Vector2(_moveSpeed * _horizontal, 0f);
	}
}

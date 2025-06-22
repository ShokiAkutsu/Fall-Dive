using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
	[Header("上昇スピード")]
	[SerializeField] float _moveSpeed = 2f;

	Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = Vector2.up * _moveSpeed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "DeadZone")
		{
			Destroy(this.gameObject, 1f);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player�̈ړ��X�s�[�h")]
	[SerializeField] float _moveSpeed = 5f;

	float _rangePosX = 8f;	// �}X���W�̐����͈�
	float _posX;			// �����͈͓���X���W�Y����

	/// <summary>���������̓��͒l</summary>
	float _horizontal;

	Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		_horizontal = Input.GetAxis("Horizontal"); // �����L�[ or A/D

		//Player��X���W�𐧌�������
		_posX = Mathf.Clamp(this.transform.position.x, -(_rangePosX), _rangePosX);
		this.transform.position = new Vector3(_posX, transform.position.y, 0f);
	}

	private void FixedUpdate()
	{
		//���ړ�(X���W�̈ړ�)
		_rb.velocity = new Vector2(_moveSpeed * _horizontal, 0f);
	}
}

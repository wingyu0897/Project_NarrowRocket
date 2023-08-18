using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigid;

	[SerializeField]
	private float turnSpeed;
	[SerializeField]
	private float forwardSpeed;

	[SerializeField]
	private float angle;

	private bool isActive = false;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();

		angle = 0;
		//isActive = true;
	}

	private void Update()
	{
		if (!isActive)
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameManager.Instance?.UpdateState(GameState.Running);
			}
		}

		if (isActive)
		{
			if (Input.GetMouseButton(0))
				angle -= turnSpeed * Time.deltaTime;
			else
				angle += turnSpeed * Time.deltaTime;
			if (angle > 180)
				angle = -180;
			else if (angle < -180)
				angle = 180;

			transform.eulerAngles = new Vector3(0, 0, angle);
			float rad = (90f + angle) * Mathf.Deg2Rad;
			Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
			rigid.velocity = direction * forwardSpeed;
		}
	}

	public void DeactiveMovement()
	{
		isActive = false;
		rigid.velocity = Vector2.zero;
	}

	public void ActiveMovement()
	{
		isActive = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isActive)
			GameManager.Instance.UpdateState(GameState.Result);
	}

	public void Initialize()
	{
		transform.position = Vector3.zero;
		isActive = false;
		angle = 0;
	}
}

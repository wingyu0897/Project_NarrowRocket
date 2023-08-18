using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float offSet;

    [SerializeField]
    private Transform target;

	private void LateUpdate()
	{
		if (target.position.y > transform.position.y - offSet)
			transform.position = new Vector3(0, target.position.y + offSet, -10);
	}
}

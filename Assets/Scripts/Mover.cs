using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float xDelta; // x�� �̵���
    [SerializeField]
    private float xMoveSpeed;   // x�� �̵��ӵ�

    [Header("Vertical Movement")]
    [SerializeField]
    private float yDelta; // y�� �̵���
    [SerializeField]
    private float yMoveSpeed; // y�� �̵��ӵ�

    private Vector3 startPosition; // ������Ʈ�� ó�� ��ġ�Ǿ� �ִ� ��ġ ����(�̵� �߽���)

    private void Start()
    {
        // ������Ʈ�� ��ġ�ص� ���� ��ġ�� �߽������� ��/��, ��/�Ʒ� �̵�
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // x�� �̵��ӵ��� 0�� �ƴϸ� x�� �̵�
        if (xMoveSpeed != 0)
        {
            // x�� �̵� �� ��� (x�� ���� ��ġ + ���� ��)
            float x = startPosition.x + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
            // x�� �̵�
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        // y�� �̵��ӵ��� 0�� �ƴϸ� x�� �̵�
        if (yMoveSpeed != 0)
        {
            // y�� �̵� �� ��� (y�� ���� ��ġ + ���� ��)
            float y = startPosition.y + yDelta * Mathf.Sin(Time.time * yMoveSpeed);
            // y�� �̵�
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}

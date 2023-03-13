using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // ī�ް� �Ѿƴٴ� ��� (�÷��̾�)
    [SerializeField]
    private float yOffset = 0; // y ��ġ ��
    [SerializeField]
    private float smoothTime = 0.3f; // �ε巴�� �̵��ϴ� �ð�
    private Vector3 velocity = Vector3.zero; // ���� ��ȭ�� (=���� �ӵ�)

    private void FixedUpdate()
    {
        // ���� ��ǥ = TransformPoint(���� ��ǥ);
        // ���� ���� ��ǥ �������� �׻� (0, yOffset, -10)�� �����ϵ��� ���� ��ǥ�� �����Ѵ�.
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        // ��ǥ ��ġ���� �ε巴�� �̵��� �� ����ϴ� �޼ҵ�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

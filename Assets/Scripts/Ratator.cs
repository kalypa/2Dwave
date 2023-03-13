using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50; // ȸ�� �ӵ�(+-�� ���⵵ �Բ� ����)
    private Vector3 rotateDirection = Vector3.forward; // ȸ�� ����

    private void Update()
    {
        // 2D �����̱� ������ z�� ȸ���� �ϵ��� Vector3.forward �������� ȸ��
        transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }
}

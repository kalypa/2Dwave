using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50; // 회전 속도(+-로 방향도 함께 설정)
    private Vector3 rotateDirection = Vector3.forward; // 회전 방향

    private void Update()
    {
        // 2D 게임이기 때문에 z축 회전만 하도록 Vector3.forward 방향으로 회전
        transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }
}

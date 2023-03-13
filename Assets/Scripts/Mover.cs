using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float xDelta; // x축 이동폭
    [SerializeField]
    private float xMoveSpeed;   // x축 이동속도

    [Header("Vertical Movement")]
    [SerializeField]
    private float yDelta; // y축 이동폭
    [SerializeField]
    private float yMoveSpeed; // y축 이동속도

    private Vector3 startPosition; // 오브젝트가 처음 배치되어 있는 위치 저장(이동 중심점)

    private void Start()
    {
        // 오브젝트를 배치해둔 최초 위치를 중심점으로 좌/우, 위/아래 이동
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // x축 이동속도가 0이 아니면 x축 이동
        if (xMoveSpeed != 0)
        {
            // x축 이동 값 계산 (x축 시작 위치 + 변위 값)
            float x = startPosition.x + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
            // x축 이동
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        // y축 이동속도가 0이 아니면 x축 이동
        if (yMoveSpeed != 0)
        {
            // y축 이동 값 계산 (y축 시작 위치 + 변위 값)
            float y = startPosition.y + yDelta * Mathf.Sin(Time.time * yMoveSpeed);
            // y축 이동
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}

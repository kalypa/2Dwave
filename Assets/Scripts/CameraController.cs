using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // 카메가 쫓아다닐 대상 (플레이어)
    [SerializeField]
    private float yOffset = 0; // y 위치 값
    [SerializeField]
    private float smoothTime = 0.3f; // 부드럽게 이동하는 시간
    private Vector3 velocity = Vector3.zero; // 값의 변화량 (=현재 속도)

    private void FixedUpdate()
    {
        // 월드 좌표 = TransformPoint(로컬 좌표);
        // 로컬 상의 좌표 기준으로 항상 (0, yOffset, -10)을 유지하도록 월드 좌표를 설정한다.
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        // 목표 위치까지 부드럽게 이동할 때 사용하는 메소드
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

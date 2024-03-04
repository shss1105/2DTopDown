using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownRolling : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] public float maxMoveDistance = 1f; 
    private WaitForSeconds rollingCooldown = new WaitForSeconds(1f);

    private bool isCooldown = false;

    private void Awake()
    {
        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isCooldown)
        {
            MoveToMousePosition();
            StartCooldown();
        }
    }

    void MoveToMousePosition()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        // 현재 위치와 마우스 클릭 위치 간의 거리 계산
        float distance = Vector2.Distance(transform.position, mousePosition);

        // 제한된 이동 거리보다 클 경우 위치를 조정하여 이동
        if (distance > maxMoveDistance)
        {
            // 현재 위치를 기준으로 마우스 클릭 위치로 향하는 방향 벡터 계산
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

            // 제한된 이동 거리까지의 위치 계산
            Vector2 newPosition = (Vector2)transform.position + direction * maxMoveDistance;

            // 오브젝트 이동
            transform.position = newPosition;
        }
        else
        {
            // 제한된 이동 거리 이내이므로 마우스 클릭 위치로 바로 이동
            transform.position = mousePosition;
        }
    }

    void StartCooldown()
    {
        StartCoroutine(CooldownCoroutine());
    }

    IEnumerator CooldownCoroutine()
    {
        isCooldown = true;

        yield return rollingCooldown;

        isCooldown = false;
    }
}

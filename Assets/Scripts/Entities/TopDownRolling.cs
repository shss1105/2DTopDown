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

        // ���� ��ġ�� ���콺 Ŭ�� ��ġ ���� �Ÿ� ���
        float distance = Vector2.Distance(transform.position, mousePosition);

        // ���ѵ� �̵� �Ÿ����� Ŭ ��� ��ġ�� �����Ͽ� �̵�
        if (distance > maxMoveDistance)
        {
            // ���� ��ġ�� �������� ���콺 Ŭ�� ��ġ�� ���ϴ� ���� ���� ���
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

            // ���ѵ� �̵� �Ÿ������� ��ġ ���
            Vector2 newPosition = (Vector2)transform.position + direction * maxMoveDistance;

            // ������Ʈ �̵�
            transform.position = newPosition;
        }
        else
        {
            // ���ѵ� �̵� �Ÿ� �̳��̹Ƿ� ���콺 Ŭ�� ��ġ�� �ٷ� �̵�
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

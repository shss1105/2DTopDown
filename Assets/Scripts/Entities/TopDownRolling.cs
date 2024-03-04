using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownRolling : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float maxMoveDistance = 1f; 
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

        float distance = Vector2.Distance(transform.position, mousePosition);

        if (distance > maxMoveDistance)
        {
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

            Vector2 newPosition = (Vector2)transform.position + direction * maxMoveDistance;
            transform.position = newPosition;
        }
        else
        {
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

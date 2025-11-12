using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovement
{
    private bool isMoving = false;
    private float moveSpeed = 5f;

    private readonly Vector2 minArea = new Vector2(-2f, -4.5f);
    private readonly Vector2 maxArea = new Vector2(2f, 0f);

    private Vector3 moveDelta;
    private Vector3 newPos;


    public void Move(Vector2 direction)
    {
        if (isMoving)
        {
            // 이동량
            moveDelta = new Vector3(direction.x, direction.y, 0f) * (moveSpeed * Time.deltaTime);

            // 이동 예측위치
            newPos = transform.position + moveDelta;

            // 이동 범위 체크 
            newPos.x = Mathf.Clamp(newPos.x, minArea.x, maxArea.x);
            newPos.y = Mathf.Clamp(newPos.y, minArea.y, maxArea.y);

            // 이동좌표 적용 
            transform.position = newPos;
        }
    }

    public void SetEnable(bool newEnable)
    {
        isMoving = newEnable;
    }
}

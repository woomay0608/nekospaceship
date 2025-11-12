using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovement movement;

    public void CurstomUpdate(Vector2 inputDir)
    {
        movement?.Move(inputDir);
       
        
    }
    public void StartGame()
    {
        movement?.SetEnable(true);
    }

  
    public void StopGame()
    {
        movement?.SetEnable(false);
    }

    private void Awake()
    {
        if (!TryGetComponent<IMovement>(out movement))
            Debug.Log("PlayerController.cs - Awake() - movement참조 실패 ");

    }
}


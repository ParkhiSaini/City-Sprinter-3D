using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump: MonoBehaviour
{
    public float duration = 10.0f; // Duration of the power-up
    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ActivateDoubleJump(duration);
                isActive = false;
                gameObject.SetActive(false); // Disable the power-up object
            }
        }
    }
}


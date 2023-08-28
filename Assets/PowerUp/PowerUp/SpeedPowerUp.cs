using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedMutiplier=2.0f;
    public float duration =10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController!=null)
            {
                playerController.ActivateSpeed(speedMutiplier,duration);
                // playerController.PlayPowerUpParticle();
                gameObject.SetActive(false);
            }
        }
    }
}

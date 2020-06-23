using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject DeathScreen;
    private void Update()
    {
        if(player == null)
        {
            DeathScreen.SetActive(true);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SingletonClass : MonoBehaviour
{
    #region Singleton
    public static SingletonClass Instance;
    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }
    #endregion

    public GameObject Drones;

    public bool checkPointReached = false;
    public bool keyPickedUp = false;

    public bool droneOneKilled = false;
    public bool droneTwoKilled = false;

    public bool terminalOnePassed = false;
    public bool terminalTwoPassed = false;

}
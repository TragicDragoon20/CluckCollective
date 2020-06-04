using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoStorage : MonoBehaviour
{
    #region Singleton
    public static InfoStorage Instance;
    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public Color32 col_w = new Color32(0x73, 0xEF, 0x5E, 0xFF);
    public Color32 col_d = new Color32(0xED, 0x5F, 0x5F, 0xFF);
    public Color32 col_p = new Color32(0xBF, 0x5F, 0xED, 0xFF);
    public Color32 col_l = new Color32(0x60, 0xC3, 0xEA, 0xFF);
    public Color32 col_y = new Color32(0xED, 0xE6, 0x5F, 0xFF);
}

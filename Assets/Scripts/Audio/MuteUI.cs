using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteUI : MonoBehaviour
{

    [SerializeField]
    private GameObject mutedGraphic;

    public void SwitchMute()
    {
        VolumeManager.Instance.SetMuted(!VolumeManager.Instance.Muted);
        mutedGraphic.SetActive(VolumeManager.Instance.Muted);
    }

}

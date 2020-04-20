using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    public AudioTypes type;

    private VolumeManager manager;

    private void Awake()
    {
        manager = VolumeManager.Instance;
        manager.OnMasterValueChanged += (m) => UpdateVolume();

        manager.OnTypeValueChanged += (type, m) => {
            if (type != this.type)
                return;
            
            UpdateVolume();
        };
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        source.volume = manager.GetMasterVolume() * manager.GetVolume(type);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    public AudioTypes type;

    [SerializeField, Range(0, 1)]
    private float volume = 1;

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
        if (source == null)
            source = gameObject.GetComponent<AudioSource>();
        source.mute = manager.Muted;

        manager.OnMuteChange += (muted) => source.mute = muted;
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        source.volume = manager.GetMasterVolume() * manager.GetVolume(type) * volume;
    }
}

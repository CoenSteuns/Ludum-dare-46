using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager
{

    private const float START_TYPE_VOLUME = 1;
    private const float START_MASTER_VOLUME = 0.2f;

    private static VolumeManager instance;
    public static VolumeManager Instance { 
        get {
            if (instance == null)
                instance = new VolumeManager();

            return instance;
        } 
    }

    private float masterVolume = START_MASTER_VOLUME;
    private Dictionary<AudioTypes, float> volumes = new Dictionary<AudioTypes, float>();

    public event Action<VolumeManager> OnMasterValueChanged;
    public event Action<AudioTypes, VolumeManager> OnTypeValueChanged;

    public float GetVolume(AudioTypes type)
    {
        if (!volumes.ContainsKey(type)) {
            SetVolume(type, START_TYPE_VOLUME);
        }

        return volumes[type];

    }

    public float GetMasterVolume() {
        return masterVolume;
    }

    public void SetVolume(AudioTypes type, float volume)
    {
        if (!volumes.ContainsKey(type))
        {
            volumes.Add(type, volume);
        }
        else
        {
            volumes[type] = volume;
        }
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
    }


}

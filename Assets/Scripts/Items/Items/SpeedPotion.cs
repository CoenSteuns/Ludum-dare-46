using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpeedPotion : Pickup, IUsable
{

    [SerializeField]
    private MovementBooster booster;
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Use()
    {
        booster.Boost();
    }

    public bool CanUse()
    {
        return !booster.Isboosting;
    }

#if UNITY_EDITOR

    [ContextMenu("Health References")]
    public void HandleReferendes()
    {
        var potions = FindObjectsOfType<SpeedPotion>();
        for (int i = 0; i < potions.Length; i++)
        {
            potions[i].PlayerReference();
            EditorUtility.SetDirty(potions[i]);
        }
    }

    public void PlayerReference()
    {
        booster = GameObject.Find("Player").GetComponent<MovementBooster>();
    }

    

#endif

}

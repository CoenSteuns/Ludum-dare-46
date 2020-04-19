using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    private const string PICKUP_TAG = "Pickup";

    [SerializeField]
    private Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(PICKUP_TAG))
            return;

        Pickup pickup = other.gameObject.GetComponent<Pickup>();
        pickup.PickupItem(inventory);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereInteraction : MonoBehaviour, IDamage {
    public void TakeDamage() {
        gameObject.SetActive(false);
    }
}

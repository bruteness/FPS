using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour, IDamage {
    public Color[] colors;
    private int materialNum;
    private Material objectMat;

    private void Start() {
        objectMat = GetComponent<Renderer>().material;
    }

    public void TakeDamage() {
        if (materialNum >= colors.Length - 1) {
            materialNum = 0;
        } else {
            materialNum++;
        }
        objectMat.color = colors[materialNum];
    }
}

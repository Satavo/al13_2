using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public Transform pos;
    public void CreateObj(GameObject prefab)
    {
        Instantiate(prefab, pos.position, pos.rotation);
    }
}

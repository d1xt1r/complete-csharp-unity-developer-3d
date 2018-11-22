using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    void OnCollisionEnter(Collision Wall)
    {
        Destroy(Wall.gameObject);
    }

}

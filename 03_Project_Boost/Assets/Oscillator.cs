using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 4f;


    //todo remove from inspector later
    [Range(0,1)] [SerializeField] float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos; // must be stored for absolute movement

	// Use this for initialization
	void Start () {

        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //set movementFactor automatically 

        // todo protect against NaN
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period; //grow continually from 0 || The number of cycles!

        const float tau = Mathf.PI * 2f; // 1 tau = 2 pi (about 6.28)
        float rawSinWave = Mathf.Sin(cycles * tau); // Returns the sine of angle f in radiants. Goes from -1 to 1

        movementFactor = rawSinWave / 2f + 0.5f;
        //print(rawSinWave);
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}

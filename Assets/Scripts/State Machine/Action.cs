using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Execute();
	}

    virtual public void Initialize()
    {

    }

    virtual public void Execute()
    {

    }

    virtual public void Stop()
    {

    }
}

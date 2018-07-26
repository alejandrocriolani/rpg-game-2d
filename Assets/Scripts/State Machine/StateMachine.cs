using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    Action currentAction;
    bool inTransition;

	// Use this for initialization
	void Start ()
    {
        inTransition = true;
        currentAction = null;
        inTransition = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!inTransition && (currentAction != null))
        {
            currentAction.Execute();
        }
	}

    public void ChangeAction(Action action)
    {
        inTransition = true;
        currentAction.Stop();
        currentAction = action;
        currentAction.Initialize();
        inTransition = false;
    }

}

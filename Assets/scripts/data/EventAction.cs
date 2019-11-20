using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventAction {

    private bool isRunning;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Invoke() {
        isRunning = true;

        StartActions();
    }

    protected abstract void StartActions();
}

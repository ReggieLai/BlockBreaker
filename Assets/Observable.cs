using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observable : MonoBehaviour {
	public List<Observer> observers;

	// Constructor creates an empty list of observers.
	public void Start () {
		observers = new List<Observer> ();
	}

	// Adds an observer to the list of observers.
	// @param o the observer to be added
	public void addObserver(Observer o) {
		observers.Add (o);
	}

	// Notifies the observer when there is a change in status of the Observable.
	public abstract void notifyObservers ();
}

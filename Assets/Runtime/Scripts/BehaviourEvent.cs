/**
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
**/

using UnityEngine;

public class BehaviourEvent : MonoBehaviour {
	public delegate void VoidDelegate (GameObject go);
	public delegate void BoolDelegate (bool v);

	public VoidDelegate onDestroy;
	public VoidDelegate onEnable;
	public VoidDelegate onDisable;
	public BoolDelegate onApplicationPause;
	public VoidDelegate onApplicationQuit;
	public VoidDelegate onTriggerEnter2D;

	void OnDestroy ()				{ if (onDestroy != null) onDestroy(gameObject); }
	void OnEnable ()				{ if (onEnable != null) onEnable(gameObject); }
	void OnDisable ()				{ if (onDisable != null) onDisable(gameObject); }
	void OnApplicationQuit()
	{
		if(onApplicationQuit != null) onApplicationQuit(null);
	}
	void OnApplicationPause(bool v)
	{
		if(onApplicationPause != null) onApplicationPause(v);
	}

	void OnTriggerEnter2D( Collider2D collision ) {
		if (onTriggerEnter2D != null) onTriggerEnter2D(collision.gameObject); 
	}
}

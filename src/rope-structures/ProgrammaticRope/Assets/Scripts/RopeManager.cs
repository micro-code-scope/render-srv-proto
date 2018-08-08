using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public Transform RopeModule;
    public int ModulesCount = 6;

    private IEnumerable<Transform> modules;

	void Start () {
        this.modules = new List<Transform>();

        for (int i = 0; i < this.ModulesCount; i++)
        {
            var module = Instantiate<Transform>(this.RopeModule, new Vector3(0, 0, 0), Quaternion.identity);
            var prev = this.modules.Count() > 0 ? this.modules.Last() : null;
            
            module.position = prev == null ? new Vector3(0, 0, 0) : (prev.position + new Vector3(0, -1.20f, 0));

            var joint = module.GetComponent<CharacterJoint>();
            joint.connectedBody = this.modules.Count() > 0 ? this.modules.Last().GetComponent<Rigidbody>() : null;

            (this.modules as List<Transform>).Add(module);
        }
	}
	
	void Update () {
		
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct Emitter : IComponentData {
	public float Radius;
	public float MaxVolume;
}
[UnityEngine.DisallowMultipleComponent]
public class EmitterComponent : ComponentDataWrapper<Emitter> { }
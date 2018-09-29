using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct Listener : IComponentData {

}

[UnityEngine.DisallowMultipleComponent]
public class ListenerComponent : ComponentDataWrapper<Listener> { }
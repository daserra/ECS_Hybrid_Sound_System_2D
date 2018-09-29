using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using System;
using Unity.Mathematics;

[Serializable]
  public struct PlayerInput : IComponentData
  {
     public Vector2 Move;
  }
  [UnityEngine.DisallowMultipleComponent]
  public class InputComponent : ComponentDataWrapper<PlayerInput> { }

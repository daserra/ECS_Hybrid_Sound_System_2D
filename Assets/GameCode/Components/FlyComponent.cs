using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using System;


  [Serializable]
  public struct FlyMove : IComponentData
  {
	  public float RotationSpeed;
	  public float CurrentAngle;
	  public float MovementRadius;
  }
  public class FlyComponent : ComponentDataWrapper<FlyMove> { }

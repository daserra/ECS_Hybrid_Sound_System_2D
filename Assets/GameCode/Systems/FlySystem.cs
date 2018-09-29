using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public class FlySystem : ComponentSystem {

	public struct Data {
		readonly public int Length;
		public ComponentDataArray<FlyMove> FlyMove;
		public TransformAccessArray Transform;
	}

	[Inject] private Data data;

	protected override void OnUpdate () {

		if (data.Length == 0)
			return;

		for (int i = 0; i < data.Length; i++) {

			var flyMove = data.FlyMove[i];
			var rotationSpeed = flyMove.RotationSpeed;
			var currentAngle = flyMove.CurrentAngle;
			var transform = data.Transform[i];

			currentAngle += rotationSpeed * Time.deltaTime;

			transform.position = new Vector2 (Mathf.Sin (currentAngle), Mathf.Cos (currentAngle)) * flyMove.MovementRadius;

			flyMove.CurrentAngle = currentAngle;

			data.FlyMove[i] = flyMove;
		}

	}
}
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public class ListenerMoveSystem : ComponentSystem {

    public struct Data {
        readonly public int Length;
        public ComponentDataArray<PlayerInput> PlayerInput;
        public TransformAccessArray Transform;
    }

    [Inject] private Data data;

    protected override void OnUpdate () {
        if (data.Length == 0)
            return;

        for (int i = 0; i < data.Length; i++) {

            var playerInput = data.PlayerInput[i];
            var transform = data.Transform[i];
            var move = new Vector3(playerInput.Move.x,playerInput.Move.y,0);
            transform.position += move * 0.2f;

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public class InputSystem : ComponentSystem {

    public struct Data {
        readonly public int Length;
        public ComponentDataArray<PlayerInput> PlayerInput;
    }

    [Inject] private Data data;

    protected override void OnUpdate () {

        if(data.Length == 0)
            return;

        for(int i = 0; i < data.Length; i++)
        {

            var newInput = new PlayerInput {
                Move = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"))
            };
 
            
            data.PlayerInput[i] = newInput;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public class EmitterSystem : ComponentSystem {

    public struct Data {
        readonly public int Length;
        public ComponentDataArray<Emitter> Emitter;
        public ComponentArray<AudioSource> AudioSource;
        public TransformAccessArray Transform;
    }
    public struct LData {
        readonly public int Length;
        public ComponentDataArray<Listener> Listener;
        public TransformAccessArray Transform;
    }

    [Inject] private Data data;
    [Inject] private LData ldata;

    protected override void OnUpdate () {
        
        if (data.Length == 0 || ldata.Length == 0)
            return;
 	 
        var listenerTransform = ldata.Transform[0];

        for (int i = 0; i < data.Length; i++) {

            var audioSrc = data.AudioSource[i];
            var emitter = data.Emitter[i];
            var listenerPos = listenerTransform.position;
            var emitterPos = data.Transform[i].position;

            var distanceToListener = Vector2.Distance (emitterPos, listenerPos);
            var distanceX = listenerPos.x - emitterPos.x;
            var volRelative = emitter.MaxVolume / emitter.Radius;
            volRelative = emitter.MaxVolume - (volRelative * distanceToListener);
            
            if(volRelative < 0)
                volRelative = 0;

            audioSrc.volume = volRelative;

            var directionRelative = 1 / emitter.Radius;

            directionRelative = directionRelative * distanceX;

            if(directionRelative > 1)
                directionRelative = 1;
            else if(directionRelative < -1)
                directionRelative = -1;

            audioSrc.panStereo = directionRelative *-1;

        }
    }
}
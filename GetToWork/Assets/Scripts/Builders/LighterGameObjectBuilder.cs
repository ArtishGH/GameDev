using System;
using UnityEngine;
using Object = System.Object;

namespace Builders
{
    public class LighterGameObjectBuilder
    {
        private int _lightStrength;
        private float _lightRange;
        
        public LighterGameObjectBuilder SetLightStrength(int lightStrength)
        {
            _lightStrength = lightStrength;
            return this;
        }

        public LighterGameObjectBuilder SetLightRange(float lightRange)
        {
            _lightRange = lightRange;
            return this;
        }

        public GameObject Build(GameObject forGameObject, GameObject lightSource)
        {
            lightSource.AddComponent<Light>();
            forGameObject.AddComponent<Rigidbody>();
            forGameObject.AddComponent<BoxCollider>();
            
            Light light = lightSource.GetComponent<Light>();
            
            light.type = LightType.Spot;
            light.intensity = _lightStrength;
            light.range = _lightRange;
            
            light.enabled = false;

            return forGameObject;
        }
    }
}
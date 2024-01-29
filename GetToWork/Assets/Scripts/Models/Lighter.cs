using Unity.VisualScripting;
using UnityEngine;

namespace Models
{
    public class Lighter : Item, Interactable
    {

        public bool LighterOn { get; private set; } = false;
        private int _lightStrength;
        private float _lightRange;
        
        public Lighter(Item item, int lightStrength, float lightRange) : base(item)
        {
            this._lightStrength = lightStrength;
            this._lightRange = lightRange;
        }
        
        public void Interact()
        {
            LighterOn = !LighterOn;
            Debug.Log("Lighter is on: " + LighterOn);
        }
    }
}
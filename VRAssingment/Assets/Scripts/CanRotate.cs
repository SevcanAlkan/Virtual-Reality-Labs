using UnityEngine;

namespace DefaultNamespace
{
    public class CanRotate : MonoBehaviour
    {
        public bool IsRotating { get; private set; }
        public int RotationSpeed { get; private set; } = 5;
        
        public void Toggle()
        {
            IsRotating = !IsRotating;
        }
        
        void Update()
        {
            if (IsRotating)
            {
                this.transform.Rotate(0, 0,RotationSpeed);
            }
        }
    }
}
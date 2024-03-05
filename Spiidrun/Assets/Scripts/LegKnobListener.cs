using UnityEngine;

namespace KnobsAsset
{
    /// <summary>
    /// Knob listener for assigning a knob value to change the transform values of an object.
    /// </summary>
    public class LegKnobListener : KnobListener
    {
        [System.Serializable]
        private enum LegIndex
        {
            Leg1,Leg2,Leg3,Leg4,Leg5,Leg6
        }

        [Tooltip("The transform of the object that the knob will affect")]
        [SerializeField] private LegLengthManager legManagerToManipulate = default;

        [Tooltip("The part of the transform to affect")]
        [SerializeField] private LegIndex legIndex = LegIndex.Leg1;

        [Tooltip("Minimum value to set the transform field to")]
        [SerializeField] private float MinValue = 0;

        [Tooltip("Maximum value to set the transform field to")]
        [SerializeField] private float MaxValue = 1;

        [Tooltip("Whether or not the min and max values are adding to the initial values of the transform")]
        [SerializeField] private bool RelativeToInitialValue = true;

        private float initialLength1;
        private float initialLength2;
        private float initialLength3;
        private float initialLength4;
        private float initialLength5;
        private float initialLength6;


        void Awake()
        {
            if (legManagerToManipulate == null)
            {
                Debug.LogException(new MissingReferenceException("A Transform to manipulate is required"), this);
                return;
            }

            initialLength1 = legManagerToManipulate.legLengths[0];
            initialLength2 = legManagerToManipulate.legLengths[1];
            initialLength3 = legManagerToManipulate.legLengths[2];
            initialLength4 = legManagerToManipulate.legLengths[3];
            initialLength5 = legManagerToManipulate.legLengths[4];
            initialLength6 = legManagerToManipulate.legLengths[5];
            
        }

        public override void OnKnobValueChange(float knobPercentValue)
        {
            float legValue = Mathf.Lerp(MinValue, MaxValue, knobPercentValue);
            
            switch (legIndex)
            
            {
                case LegIndex.Leg1:
                    legManagerToManipulate.legLengths[0] = legValue + (RelativeToInitialValue ? initialLength1 : 0);
                    break;
                case LegIndex.Leg2:
                    legManagerToManipulate.legLengths[1] = legValue + (RelativeToInitialValue ? initialLength2 : 0);
                    break;
                case LegIndex.Leg3:
                    legManagerToManipulate.legLengths[2] = legValue + (RelativeToInitialValue ? initialLength3 : 0);
                    break;
                case LegIndex.Leg4:
                    legManagerToManipulate.legLengths[3] = legValue + (RelativeToInitialValue ? initialLength4 : 0);
                    break;
                case LegIndex.Leg5:
                    legManagerToManipulate.legLengths[4] = legValue + (RelativeToInitialValue ? initialLength5 : 0);
                    break;
                case LegIndex.Leg6:
                    legManagerToManipulate.legLengths[5] = legValue + (RelativeToInitialValue ? initialLength6 : 0);
                    break;
                default:
                    Debug.LogException(new System.InvalidOperationException("Invalid TransformTypes value " + legIndex), this);
                    return;
            }
        }
    }
}

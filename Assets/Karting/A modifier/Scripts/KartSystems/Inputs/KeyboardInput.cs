using UnityEngine;

namespace KartGame.KartSystems
{

    public class KeyboardInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateAxisName = "Accelerate";
        public string BrakeAxisName = "Brake";
        public string BoostButtonName = "Boost";

        public override InputData GenerateInput()
        {
            return new InputData
            {
                Accelerate = Input.GetAxis(AccelerateAxisName) > 0.1f,
                Brake = Input.GetAxis(BrakeAxisName) < -0.1f,
                TurnInput = Input.GetAxis("Horizontal"),
                Boost = Input.GetButton(BoostButtonName),
            };
        }
    }
}

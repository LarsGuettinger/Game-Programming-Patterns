using System;
using UnityEngine;

namespace CommandPattern
{
    namespace Version001
    {
        internal interface ICommand
        {
            void Execute();
        }

        public class JumpCommand : ICommand
        {
            public void Execute()
            {
                Debug.Log("Jump");
            }
        }

        public class AttackCommand : ICommand
        {
            public void Execute()
            {
                Debug.Log("Attack");
            }
        }

        class InputHandler : MonoBehaviour
        {
            ICommand buttonX;
            ICommand buttonY;
            ICommand buttonA;
            ICommand buttonB;

            public InputHandler()
            {
                buttonX = new JumpCommand();
                buttonY = new JumpCommand();
                buttonA = new AttackCommand();
                buttonB = new AttackCommand();
            }

            public void HandleInput()
            {
                if (Input.GetKeyDown(KeyCode.X) && buttonX != null) buttonX.Execute();
                else if (Input.GetKeyDown(KeyCode.Y) && buttonY != null) buttonY.Execute();
                else if (Input.GetKeyDown(KeyCode.A) && buttonA != null) buttonA.Execute();
                else if (Input.GetKeyDown(KeyCode.B) && buttonB != null) buttonB.Execute();
            }

            private void Update()
            {
                HandleInput();
            }
        }
    }
}


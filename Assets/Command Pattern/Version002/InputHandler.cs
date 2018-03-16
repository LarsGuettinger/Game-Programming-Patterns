using UnityEngine;

namespace CommandPattern
{
    namespace Version002
    {
        internal interface ICommand
        {
            void Execute(GameActor actor);
        }

        public class GameActor
        {
            public void Jump()
            {
                Debug.Log("Jump");
            }

            public void Attack()
            {
                Debug.Log("Attack");
            }
        }

        public class JumpCommand : ICommand
        {
            public void Execute(GameActor actor)
            {
                actor.Jump();
            }
        }

        public class AttackCommand : ICommand
        {
            public void Execute(GameActor actor)
            {
                actor.Attack();
            }
        }

        internal class InputHandler : MonoBehaviour
        {
            private GameActor gameActor = new GameActor();
            private ICommand buttonX;
            private ICommand buttonY;
            private ICommand buttonA;
            private ICommand buttonB;

            public InputHandler()
            {
                buttonX = new JumpCommand();
                buttonY = new JumpCommand();
                buttonA = new AttackCommand();
                buttonB = new AttackCommand();
            }

            private ICommand HandleInput()
            {
                if (Input.GetKeyDown(KeyCode.X) && buttonX != null) return buttonX;
                if (Input.GetKeyDown(KeyCode.Y) && buttonX != null) return buttonY;
                if (Input.GetKeyDown(KeyCode.A) && buttonX != null) return buttonA;
                if (Input.GetKeyDown(KeyCode.B) && buttonX != null) return buttonB;

                return null;
            }

            private void Update()
            {
                ICommand command = HandleInput();
                if (command != null) command.Execute(gameActor);
            }
        }
    }
}
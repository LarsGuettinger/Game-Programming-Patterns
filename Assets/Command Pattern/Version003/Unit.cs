using UnityEngine;

namespace CommandPattern
{
    namespace Version003
    {
        internal interface ICommand
        {
            void Execute();
        }

        class MoveUnitCommand : ICommand
        {
            Unit unit;
            int x, y;

            public MoveUnitCommand(Unit unit, int x, int y)
            {
                this.unit = unit;
                this.x = x;
                this.y = y;
            }
            public void Execute()
            {
                unit.MoveTo(x, y);
            }
        }

        class Unit : MonoBehaviour
        {
            ICommand buttonA;
            ICommand buttonD;

            public void Start()
            {
                buttonA = new MoveUnitCommand(this, 0, 0);
                buttonD = new MoveUnitCommand(this, 1, 1);
            }

            private ICommand HandleInput()
            {
                if (Input.GetKey(KeyCode.A) && buttonA != null) return buttonA;
                if (Input.GetKey(KeyCode.D) && buttonD != null) return buttonD;
                return null;
            }

            private void Update()
            {
                ICommand command = HandleInput();
                if (command != null) command.Execute();
            }

            public void MoveTo(int x, int y)
            {
                transform.position = new Vector3(x, y);
            }
        }
    }
}

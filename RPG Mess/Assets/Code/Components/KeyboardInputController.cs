using UnityEngine;
using System.Collections;
using Assets.Code.Components;

namespace Assets.Scripts.GameControllers
{
    [RequireComponent(typeof(MovingController))]
    public class KeyboardInputController : MonoBehaviour
    {

        // private variables
        private MovingController movingController;

        // Use this for initialization
        void Awake()
        {
            movingController = this.GetComponent<MovingController>();
        }

        // Update is called once per frame
        void Update()
        {

            if (movingController == null) return;

            float dX = Input.GetAxis("Horizontal");
            float dY = Input.GetAxis("Vertical");

            var dV = new Vector2(dX, dY);

            movingController.Move(dV);
        }
    }
}
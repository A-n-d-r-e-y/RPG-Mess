﻿using UnityEngine;
using System.Collections;
using Assets.Code.Components;
using System;
using Assets.Code.Common;

namespace Assets.Code.Components
{
    public class KeyboardInputReceiver : BaseInputReceiver
    {
        public override event EventHandler<Vector3EventArgs> FireInputReceived;
        public override event EventHandler<Vector2EventArgs> MoveInputReceived;
        public override event EventHandler<Vector3EventArgs> ArrowInputReceived;

        private bool keyWasPressed = false;

        int delay = 10;
        int counter = 0;

        // Update is called once per frame
        public override void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (MoveInputReceived != null)
                {
                    //float dX = Input.GetAxis("Horizontal");
                    //float dY = Input.GetAxis("Vertical");

                    float dX = 0;
                    float dY = 0;

                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                    {
                        dY = Input.GetKey(KeyCode.W) ? 0.5f : -0.5f;
                    }

                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                    {
                        dX = Input.GetKey(KeyCode.D) ? 0.5f : -0.5f;
                    }

                    MoveInputReceived(this, new Vector2EventArgs(new Vector2(dX, dY)));

                    if (!keyWasPressed) keyWasPressed = true;
                }
            }
            else
            {
                if (keyWasPressed && MoveInputReceived != null)
                {
                    MoveInputReceived(this, new Vector2EventArgs(Vector2.zero));
                    keyWasPressed = false;
                }
            }


            if (Input.GetButtonDown("Fire1") && FireInputReceived != null)
            {
                FireInputReceived(this, new Vector3EventArgs(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            }



            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (counter++ < delay) return;

                counter = 0;

                if (ArrowInputReceived != null)
                {
                    float dX = 0;
                    float dY = 0;

                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                    {
                        dY = Input.GetKey(KeyCode.UpArrow) ? 1 : -1;
                    }

                    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                    {
                        dX = Input.GetKey(KeyCode.RightArrow) ? 1 : -1;
                    }

                    ArrowInputReceived(this, new Vector3EventArgs(new Vector2(dX, dY).normalized));

                    if (!keyWasPressed) keyWasPressed = true;
                }
            }
            else
            {
                if (keyWasPressed && ArrowInputReceived != null)
                {
                    ArrowInputReceived(this, new Vector3EventArgs(Vector3.zero));
                    keyWasPressed = false;
                }
            }
        }
    }
}
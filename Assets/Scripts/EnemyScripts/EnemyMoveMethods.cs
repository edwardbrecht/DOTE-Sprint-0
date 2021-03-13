using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DOTE_Sprint_0.Assets.Scripts.EnemyScripts
{
    public class EnemyMoveMethods
    {
        private Vector3 moveTo;
        private Space space;
        public float speed;

        /*
        Constructors
        */
        public EnemyMoveMethods() {
            this.moveTo = new Vector3(0,0,0);
            this.space = Space.Self;
            this.speed = 5f;
        }

        public EnemyMoveMethods(float x, float y, float z) {
            this.moveTo = new Vector3(x,y,z);
            this.space = Space.Self;
            this.speed = 5f;
        }

        public EnemyMoveMethods(Vector3 vector) {
            this.moveTo = new Vector3(vector.x, vector.y, vector.z);
            this.space = Space.Self;
            this.speed = 5f;
        }

        public EnemyMoveMethods(float x, float y, float z, Space space) {
            this.moveTo = new Vector3(x,y,z);
            this.space = space;
            this.speed = 5f;
        }

        public EnemyMoveMethods(Vector3 vector, Space space) {
            this.moveTo = new Vector3(vector.x, vector.y, vector.z);
            this.space = space;
            this.speed = 5f;
        }



        /*
        Sets the move target to x,y,z
        */
        public void UpdateMoveTarget(float x, float y, float z) {
            this.moveTo.x = x;
            this.moveTo.y = y;
            this.moveTo.z = z;
        }

        /*
        Sets the move target to vector
        */
        public void UpdateMoveTarget(Vector3 vector) {
            this.moveTo.x = vector.x;
            this.moveTo.y = vector.y;
            this.moveTo.z = vector.z;
        }

        /*
        Sets the space of movement to the specified space
        */
        public void SetSpace(Space space) {
            this.space = space;
        }

        /*
        Sets the speed of movement to the move target
        */
        public void SetSpeed(float speed) {
            this.speed = speed;
        }

        /*
        Returns the current move target.  Can set the returned value to change the move target
        */
        public Vector3 GetMoveTarget() {
            return this.moveTo;
        }

        /*
        Changes the position of moveObj towards the move target
        */
        public void MoveToTarget(Transform moveObj) {
            if (this.space == Space.Self) {
                moveObj.localPosition = Vector3.MoveTowards(moveObj.localPosition, this.moveTo, speed);
            } else {
                moveObj.position = Vector3.MoveTowards(moveObj.position, this.moveTo, speed);
            }
        }

        /*
        Checks if the position of moveObj is at the move target, returns true if so, false otherwise.  Rounrds to nearest whole number
        */
        public bool IsAtTarget(Transform moveObj) {
            bool atTarget = false;
            
            if (space == Space.Self) {
                Vector3 currPos = moveObj.localPosition;

                if (currPos.x == moveTo.x && currPos.y == moveTo.y && currPos.z == moveTo.z)
                    atTarget = true;
            } else {
                Vector3 currPos = moveObj.position;

                if (currPos.x == moveTo.x && currPos.y == moveTo.y && currPos.z == moveTo.z)
                    atTarget = true;
            }

            return atTarget;
        }
    }
}
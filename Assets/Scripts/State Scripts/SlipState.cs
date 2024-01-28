using UnityEngine;
using UnityEngine.AI;

namespace SolarStudios
{
    public class SlipState : MonoBehaviour, IState
    {
        public float animLength;
        public float animTimer;
        private StateMachine stateMachine;
        public NavMeshAgent agent;
        private int health;

        private RagdollToggle rag;

        public void Enter(StateMachine stateMachine) //Runs when we enter the state
        {
            this.stateMachine = stateMachine;
            agent = GetComponent<NavMeshAgent>();

            agent.isStopped = true;

            //Play Slip animation
            rag = GetComponent<RagdollToggle>();
            rag.ToggleRagdollOn();
        }
        public void Run() //Runs every frame
        {
            if (health < 1)
            {
                Destroy(gameObject, 4f);
            }
            else
            {
                
                //Run a timer that is the length of the animation
                if (animTimer > 0)
                {
                    animTimer -= Time.deltaTime;
                }
                else
                {
                    animTimer = animLength;
                    rag.ToggleRagdollOff();
                    stateMachine.SetState(stateMachine.GetComponent<WalkingState>());

                }
            }
        }
        public void Exit() //Runs when we exit
        {
            //Turn back on AI
            agent.isStopped = false;
        }

    }

}

using UnityEngine;
using UnityEngine.AI;

namespace SolarStudios
{
    public class SlipState : MonoBehaviour, IState
    {
        private StateMachine stateMachine;
        public NavMeshAgent agent;
        public void Enter(StateMachine stateMachine) //Runs when we enter the state
        {
            this.stateMachine = stateMachine;
            agent = GetComponent<NavMeshAgent>();

            agent.isStopped = true;

            //Play Slip animation

        }
        public void Run() //Runs every frame
        {
            //Run a timer that is the length of the animation
        }
        public void Exit() //Runs when we exit
        {
            //Turn back on AI
        }

    }

}
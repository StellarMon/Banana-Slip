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
        public int health;

        private Animator anim;

        private RagdollToggle rag;

        public ScoreManager scoreManager;
        private AudioManager audioManager;
        public void Enter(StateMachine stateMachine) //Runs when we enter the state
        {

            this.stateMachine = stateMachine;
            agent = GetComponent<NavMeshAgent>();

            agent.isStopped = true;
            anim = stateMachine.anim;
            //Play Slip animation
            rag = GetComponent<RagdollToggle>();
            rag.ToggleRagdollOn();

            //slip gives score
            scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
            scoreManager.scoreCount += 1;
            anim.enabled = false;
            audioManager = AudioManager.instance;
            PlayAudio();
            PlayFallAudio();
        }
        public void Run() //Runs every frame
        {
            if (health < 1)
            {
                Destroy(gameObject, 6f);
            }
            else
            {
                anim.enabled = true;
                anim.SetInteger("Stand", 1);
                rag.ToggleRagdollOff();

                if (animTimer > 0)
                {
                    animTimer -= Time.deltaTime;
                }
                else
                {
                    stateMachine.SetState(stateMachine.GetComponent<WalkingState>());
                }



            }
        }
        public void Exit() //Runs when we exit
        {
            anim.enabled = true;
            anim.SetInteger("Stand", 0);
            //Turn back on AI
            agent.isStopped = false;
        }

        void PlayAudio()
        {
            int rand = Random.Range(0, 7);
            switch (rand)
            {
                case 0:
                    audioManager.PlayAudioClip("Slipped", gameObject, true, false);
                    break;
                case 1:
                    audioManager.PlayAudioClip("Yeet", gameObject, true, false);
                    break;
                case 2:
                    audioManager.PlayAudioClip("Slip on my peel", gameObject, true, false);
                    break;
                case 3:
                    audioManager.PlayAudioClip("Reaching2", gameObject, true, false);
                    break;
                case 4:
                    audioManager.PlayAudioClip("Fell like a fruit", gameObject, true, false);
                    break;
                case 5:
                    audioManager.PlayAudioClip("Busting ass", gameObject, true, false);
                    break;
                case 6:
                    audioManager.PlayAudioClip("Bannana1Liner4", gameObject, true, false);
                    break;
                case 7:
                    audioManager.PlayAudioClip("Bannana1Liner reaching", gameObject, true, false);
                    break;
            }
        }

        void PlayFallAudio()
        {
            audioManager.PlayAudioClip("Fall", gameObject, true, false);
        }

    }

}

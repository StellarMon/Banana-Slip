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

        private GameManager gameManager;
        public void Enter(StateMachine stateMachine) //Runs when we enter the state
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            health--;
            this.stateMachine = stateMachine;
            agent = GetComponent<NavMeshAgent>();

            agent.isStopped = true;
            anim = stateMachine.anim;
            //Play Slip animation


            //slip gives score
            scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
            scoreManager.scoreCount += 1;
            anim.enabled = false;
            rag = GetComponent<RagdollToggle>();
            rag.ToggleRagdollOn();
            audioManager = AudioManager.instance;

            PlayAudio();
            PlayFallAudio();
        }
        public void Run() //Runs every frame
        {
            Invoke("Recover", 6f);

            if (health <= 0)
            {
                gameManager.NPCs.Remove(gameObject);
                Destroy(gameObject, 6f);
            }
            
               
            
        }
        public void Exit() //Runs when we exit
        {
            anim.enabled = true;
            anim.SetInteger("Stand", 0);
            //Turn back on AI

            Invoke("StartAI", 8.3f);
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

        void Recover()
        {
            anim.enabled = true;
            anim.SetInteger("Stand", 1);
            rag.ToggleRagdollOff();

            stateMachine.SetState(stateMachine.GetComponent<WalkingState>());
        }

        void StartAI()
        {
            agent.isStopped = false;
        }

    }

}

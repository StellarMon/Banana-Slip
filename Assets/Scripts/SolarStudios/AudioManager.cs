using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SolarStudios
{
    [System.Serializable]
    public class Sound
    {
        public string soundName;
        public AudioClip clip;
        public AudioMixerGroup mixer;
        public bool mute;
        public bool playOnAwake;
        public bool Loop;

        [Range(0f, 256f)]
        public int priority;
        [Range(0f, 1f)]
        public float volume;
        [Range(-3f, 3f)]
        public float pitch;
        [Range(-1f, 1f)]
        public float stereoPan;
        [Range(0f, 1f)]
        public float spatialBlend;
        [Range(0f, 1.1f)]
        public float reverbZoneMix;
    }

    public class AudioManager : MonoBehaviour
    {
        private bool canPool;
        private object objectPool; //Incase the user does not intend to add the object pools cript to the project.
        public static AudioManager instance;

        [SerializeField]
        private List<Sound> soundList = new List<Sound>();

        private void Awake()
        {

            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Type objectPoolType = Type.GetType("ObjectPool"); //Essentially checking if this is a thing in the project.

            if (objectPoolType != null)
            {
                canPool = true;
                objectPool = GetComponent<ObjectPool>();
            }
            else
            {
                canPool = false;
                Debug.Log("The SolarStudios Objectpool Script cannot be found in project. Objectpooling has been disabled.");
            }
        }


        public void PlayAudioClip(string soundName, GameObject callerObject = , bool useObjectPool = true)
        {
            Sound sound = soundList.Find(s => s.soundName == soundName);

            if (sound != null)
            {
                if (canPool && useObjectPool)
                {
                    ObjectPool objectPoolComponent = (ObjectPool)objectPool;
                    GameObject audioSource = objectPoolComponent.Spawn(callerObject.transform.position, callerObject.transform.rotation);
                    audioSource.name = sound.soundName + " Audio clip";

                    AudioSource source = audioSource.GetComponent<AudioSource>();
                    source.clip = sound.clip;
                    source.outputAudioMixerGroup = sound.mixer;
                    source.mute = sound.mute;
                    source.playOnAwake = sound.playOnAwake;
                    source.loop = sound.Loop;
                    source.priority = sound.priority;
                    source.volume = sound.volume;
                    source.pitch = sound.pitch;
                    source.panStereo = sound.stereoPan;
                    source.spatialBlend = sound.spatialBlend;
                    source.reverbZoneMix = sound.reverbZoneMix;

                    source.Play();
                    objectPoolComponent.Recycle(audioSource, sound.clip.length);

                }
                else
                {
                    GameObject audioSource = new GameObject("AudioSource");
                    audioSource.transform.position = callerObject.transform.position;
                    audioSource.transform.parent = callerObject.transform;
                    audioSource.name = sound.soundName + " Audio clip";

                    AudioSource source = audioSource.AddComponent<AudioSource>();
                    source.clip = sound.clip;
                    source.outputAudioMixerGroup = sound.mixer;
                    source.mute = sound.mute;
                    source.playOnAwake = sound.playOnAwake;
                    source.loop = sound.Loop;
                    source.priority = sound.priority;
                    source.volume = sound.volume;
                    source.pitch = sound.pitch;
                    source.panStereo = sound.stereoPan;
                    source.spatialBlend = sound.spatialBlend;
                    source.reverbZoneMix = sound.reverbZoneMix;
                    source.Play();
                    Destroy(audioSource, sound.clip.length);
                }
            }
            else
            {
                Debug.LogError($"Sound with name '{soundName}' not found in the sound list.");
            }
        }
    }
}

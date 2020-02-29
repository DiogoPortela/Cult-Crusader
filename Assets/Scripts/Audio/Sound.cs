using UnityEngine;
using UnityEngine.Audio;

namespace Utils.Audio
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public AudioMixerGroup group;
        public float volume = 1;
        public float pitch = 1;
        public bool loop = false;
        public string groupTag;
        [HideInInspector] public AudioSource source;
    }
}

using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Utils.Audio
{
    public class AudioManager : SingletonBehaviour<AudioManager>
    {
        public AudioMixerGroup audioMixerGroup;
        public Sound[] allSounds;

        protected override void Awake()
        {
            base.Awake();
            foreach (Sound sound in allSounds)
            {
                GameObject soundSource = new GameObject($"{sound.name} Source");
                soundSource.transform.parent = this.transform;
                sound.source = soundSource.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.outputAudioMixerGroup = audioMixerGroup;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
                if(sound.group != null)
                    sound.source.outputAudioMixerGroup = sound.group;
            }
        }

        public void Play(string soundName)
        {
            Sound currentSound = Array.Find(allSounds, sound => sound.name == soundName);
            if (currentSound == null)
                return;
            currentSound.source.Play();
        }
        public void Stop(string soundName)
        {
            Sound currentSound = Array.Find(allSounds, sound => sound.name == soundName);
            if (currentSound == null)
                return;
            currentSound.source.Stop();
        }

        public void PlayRandomSoundFromGroup(string groupTag){
            var possibleSounds = Array.FindAll(allSounds, x => x.groupTag == groupTag);
            int randomIndex = UnityEngine.Random.Range(0, possibleSounds.Length);

            possibleSounds[randomIndex].source.Play();
        }
    }
}

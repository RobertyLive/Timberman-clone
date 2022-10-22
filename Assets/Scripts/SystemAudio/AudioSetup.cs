using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioMusic
{

    public class AudioSetup : MonoBehaviour
    {


        public List<AudioClip> sons;

        public AudioSource audioSource;

        private void OnValidate()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }


        public void SwitchMusic(int i)
        {
            switch (i)
            {
                case 0:
                    PlayAudioBio(i);
                    break;
                case 1:
                    PlayAudioBio(i);

                    break;
                case 2:
                    PlayAudioBio(i);
                    break;


            }
        }

        private void PlayAudioBio(int i)
        {
            audioSource.clip = sons[i];
            audioSource.Play();
        }

    }
}

using UnityEngine;

namespace Illumate.Tools
{
    public static class AudioPool
    {
        private static AudioSource _audioSource;
        private static AudioSource audioSource
        {
            get
            {
                if (_audioSource == null)
                    _audioSource = ExistingObject.monoObject.AddComponent<AudioSource>();
                return _audioSource;
            }
        }

        /// <summary>
        /// Play audio clip one shot
        /// </summary>
        /// <param name="clip"></param>

        public static void Play(AudioClip clip) // TODO: add pitch option
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

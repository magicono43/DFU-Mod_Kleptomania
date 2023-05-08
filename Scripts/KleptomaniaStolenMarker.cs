using UnityEngine;
using DaggerfallWorkshop;

namespace Kleptomania
{
    [RequireComponent(typeof(DaggerfallAudioSource))] // Appears to automatically assign an audiosource to this class gameobject when it is created? Atleast that is what I think it's meant to do?
    public class KleptomaniaStolenMarker : MonoBehaviour
    {
        #region Fields

        ulong loadID = 0;

        int textureArchive = -1;
        int textureRecord = -1;

        DaggerfallAudioSource dfAudioSource;

        #endregion

        #region Properties

        public ulong LoadID
        {
            get { return loadID; }
            set { loadID = value; }
        }

        public int TextureArchive
        {
            get { return textureArchive; }
            set { textureArchive = value; }
        }

        public int TextureRecord
        {
            get { return textureRecord; }
            set { textureRecord = value; }
        }

        #endregion

        void Awake()
        {
            dfAudioSource = GetComponent<DaggerfallAudioSource>();
        }
    }
}

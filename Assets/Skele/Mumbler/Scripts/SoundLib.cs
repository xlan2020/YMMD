using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using ExtMethods;
using UnityEngine.Audio;

using Random = UnityEngine.Random;

namespace MH.Mumbler
{
    using DataDict = Dictionary<string, SpeakerData>;
    public class SoundLib
    {
        #region "conf data"

        private DataDict _speakers = new DataDict();
        private List<string> _speakerNames = new List<string>();

        #endregion "conf data"

        #region "data"
        public List<string> speakerNames { get { return _speakerNames; } }
        #endregion "data"

        #region "unity methods"
        #endregion "unity methods"

        #region "public methods"

        public SpeakerData GetSpeaker(string speakerName)
        {
            SpeakerData sdata = null;
            if (_speakers.TryGetValue(speakerName, out sdata))
                return sdata;

            SpeakerData sd = (SpeakerData)Resources.Load(PathUtil.Combine(SPEAKER_RESOURCE_PATH, speakerName), typeof(SpeakerData));
            if( null == sd )
            {
                Dbg.LogWarn("SoundLib.GetSpeaker: unexpected name: {0}", speakerName);
                return null;
            }
            else
            {
                _AddSpeaker(sd);
                return sd;
            }
        }

        public void CollectAllSpeaker()
        {
            var allSpeakers = Resources.LoadAll(SPEAKER_RESOURCE_PATH, typeof(SpeakerData));

            for(int i=0; i<allSpeakers.Length; ++i)
            {
                SpeakerData oneSpeaker = (SpeakerData)allSpeakers[i];
                _AddSpeaker(oneSpeaker);
            }
        }


        #endregion "public methods"

        #region "private methods"

        private void _AddSpeaker(SpeakerData sd)
        {
            _speakers[sd.name] = sd;
            _speakerNames.Add(sd.name);
        }

        #endregion "private methods"

        #region "constants"
        private const string SPEAKER_RESOURCE_PATH = "Speakers";
        #endregion "constants"
    }

    

    //[Serializable]
    //public class DataDict : BDict<string, SpeakerData> { }

}



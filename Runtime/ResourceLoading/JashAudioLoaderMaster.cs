﻿using NLayer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JashAudioLoaderMaster : MonoBehaviour
{

    public static AudioClip LoadMp3(string filePath)
    {
        string filename = System.IO.Path.GetFileNameWithoutExtension(filePath);

        MpegFile mpegFile = new MpegFile(filePath);

        // assign samples into AudioClip
        AudioClip ac = AudioClip.Create(filename,
                                        (int)(mpegFile.Length / sizeof(float) / mpegFile.Channels),
                                        mpegFile.Channels,
                                        mpegFile.SampleRate,
                                        true,
                                        data => { int actualReadCount = mpegFile.ReadSamples(data, 0, data.Length); },
                                        position => { mpegFile = new MpegFile(filePath); });

        return ac;
    }
}

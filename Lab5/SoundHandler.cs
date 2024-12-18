using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab5.Properties;
using NAudio;
using NAudio.Wave;

namespace Lab5
{
    internal static class SoundHandler
    {
        static private IWavePlayer musicOutput;
        static private IWavePlayer effectsOutput;
        static private byte[][] mp3Bytes = new byte[4][];
        static private byte[][] mp3EffectBytes = new byte[8][];

        static public void InitHandler()
        {
            mp3Bytes[0] = Resources.MainMenuTheme;
            mp3Bytes[1] = Resources.CorruptedMonk;
            mp3Bytes[2] = Resources.Rebellion;
            mp3Bytes[3] = Resources.Palace;

            mp3EffectBytes[0] = Resources.samurai_attack;
            mp3EffectBytes[1] = Resources.kobold_attack;
            mp3EffectBytes[2] = Resources.smith;
            mp3EffectBytes[3] = Resources.btnSelected1;
            mp3EffectBytes[4] = Resources.btnPressed;
            mp3EffectBytes[5] = Resources.itemObtained;
            mp3EffectBytes[6] = Resources.entitiysDeath;
            mp3EffectBytes[7] = Resources.death;
        }

        static public void PlayMusic(int soundTrackIndex)
        {
            musicOutput = StopPlaying(musicOutput);
            MemoryStream memoryStream = new MemoryStream(mp3Bytes[soundTrackIndex]);
            musicOutput = new WaveOutEvent();
            musicOutput.Init(new Mp3FileReader(memoryStream));
            musicOutput.Play();
        }

        static public void PlayEffect(int soundTrackIndex)
        {
            MemoryStream memoryStream = new MemoryStream(mp3EffectBytes[soundTrackIndex]);
            effectsOutput = new WaveOutEvent();
            effectsOutput.Init(new Mp3FileReader(memoryStream));
            effectsOutput.Play();
        }

        static public WaveOutEvent StopPlaying(IWavePlayer output)
        {
            if (output != null)
            {
                output.Stop();
                output.Dispose();
                return null;
            }
            return null;
        }

        static public void SetSoundTrackVolume(float newVolume)
        {
            musicOutput.Volume = newVolume;
        }
        static public int GetSoundTrackVolume()
        {
            return (int)(musicOutput.Volume * 100);
        }
    }
}

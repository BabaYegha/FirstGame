using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectWanderer.View
{
    public static class SoundsPlayer
    {
        static MediaPlayer mediaPlayer = new MediaPlayer();
        static MediaPlayer soundPlayer = new MediaPlayer();

        public static void MusicPlayer(string musicPath)
        {
            mediaPlayer.Open(new Uri(musicPath, UriKind.Relative));
            mediaPlayer.Play();

        }
        public static void EffectPlayer(string effectPath)
        {
            soundPlayer.Open(new Uri(effectPath, UriKind.Relative));
            soundPlayer.Play();

        }

    }
}

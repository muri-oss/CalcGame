using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcGame
{
    enum ESoundFile
    {
        START,
        SHOOT,
        SHOOTUFO,
        STRAY,
        INVADE
    }

    /// <summary>
    /// 効果音クラス（シングルトン）
    /// </summary>
    class CSound
    {
        private static CSound instance = new CSound();

        public static CSound Instance
        {
            get { return instance; }
        }

        // コンストラクタ
        private CSound() { }

        // デストラクタ
        ~CSound() { }

        private const string startWav = "sounds\\start.wav";
        private const string shootWav = "sounds\\shoot.wav";
        private const string shootUfoWav = "sounds\\shootUfo.wav";
        private const string strayWav = "sounds\\stray.wav";
        private const string invadeWav = "sounds\\invade.wav";

        /// <summary>
        /// 効果音再生
        /// </summary>
        /// <param name="a_soundFile">効果音種別</param>
        public void Play(ESoundFile a_soundFile)
        {
            string soundFile = "";

            switch (a_soundFile)
            {
                case ESoundFile.START:
                    soundFile = startWav;
                    break;
                case ESoundFile.SHOOT:
                    soundFile = shootWav;
                    break;
                case ESoundFile.SHOOTUFO:
                    soundFile = shootUfoWav;
                    break;
                case ESoundFile.STRAY:
                    soundFile = strayWav;
                    break;
                case ESoundFile.INVADE:
                    soundFile = invadeWav;
                    break;
                default:
                    return;
            }

            var player = new System.Media.SoundPlayer(soundFile);
            player.Play();
        }
    }
}

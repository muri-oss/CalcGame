using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcGame
{
    /// <summary>
    /// インベーダー管理クラス（シングルトン）
    /// </summary>
    public sealed class CInvader
    {
        private static readonly CInvader instance = new CInvader();

        public static CInvader Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private CInvader()
        {
            ResetInvader();
        }

        // 定数
        public const int InvaderNum = 25;
        public const int DispNum = 8;

        // メンバ変数
        private readonly Object invaderLock = new Object();
        private List<string> invaderList = new List<string>();
        private int dispPos;
        private int score;
        public int Score { get { return score; } set { score = value; } }
        private int stage;
        public int Stage { get { return stage; } set { stage = value; } }
        private int killSum;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            ResetInvader();
        }

        /// <summary>
        /// 侵略状況が進む
        /// </summary>
        /// <returns></returns>
        public (UInt16 ret, List<string> invader) Invade()
        {
            lock (invaderLock)
            {
                dispPos++;
                if (DispNum == dispPos)
                {
                    // 侵略された
                    var scoreStr = score.ToString();
                    List<string> retList = new List<string>();
                    foreach (var s in scoreStr)
                    {
                        retList.Add(s.ToString());
                    }
                    return (0, retList);
                }
                else
                {
                    // インベーダー有り
                    return (1, GetInvaderList());
                }
            }
        }

        /// <summary>
        /// 攻撃処理
        /// </summary>
        /// <param name="a_target"></param>
        /// <returns></returns>
        public (UInt16 ret, List<string> invader) Shoot(string a_target)
        {
            lock(invaderLock)
            {
                if (-1 == dispPos)
                {
                    // 表示しているインベーダーがない場合
                    return (0, null);
                }
                else { }

                // インベーダーを表示している場合は撃墜チェック
                var targetPos = invaderList.FindIndex(n => n.CompareTo(a_target) == 0);
                if ((0 <= targetPos) && (dispPos >= targetPos))
                {
                    // 撃墜
                    invaderList.RemoveAt(targetPos);
                    if (0 != a_target.CompareTo("u"))
                    {
                        // UFO以外
                        score += ((DispNum - (dispPos - targetPos)) * 10) + stage;
                        killSum += int.Parse(a_target);
                    }
                    else
                    {
                        // UFO
                        score += 300 + stage;
                    }
                    dispPos--;

                    var cnt = invaderList.Count();
                    if (0 < cnt)
                    {
                        // 残りインベーダー有り

                        // UFO出現チェック
                        if ((9<killSum)&&(0==killSum%10))
                        {
                            if (dispPos + 1 < cnt)
                            {
                                invaderList.Insert(dispPos + 1, "u");
                                invaderList.RemoveAt(cnt);
                                killSum = 0;
                            }
                        }

                        return (1, GetInvaderList());
                    }
                    else
                    {
                        // 残りインベーダー無し。ステージクリア！！
                        return (2, GetInvaderList());
                    }
                }
                else
                {
                    return (0, GetInvaderList());
                }
            }
        }

        /// <summary>
        /// 次のステージ
        /// </summary>
        public void NextStage()
        {
            var rand = new Random();

            lock (invaderLock)
            {
                invaderList.Clear();
                for (var i = 0; i < InvaderNum; i++)
                {
                    invaderList.Add((rand.Next() % 10).ToString());
                }

                dispPos = -1;
                stage++;
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void ResetInvader()
        {
            var rand = new Random();

            lock (invaderLock)
            {
                invaderList.Clear();
                for (var i = 0; i < InvaderNum; i++)
                {
                    invaderList.Add((rand.Next() % 10).ToString());
                }

                dispPos = -1;
                score = 0;
                stage = 0;
                killSum = 0;
            }
        }

        /// <summary>
        /// 表示用インベーダーのリスト取得
        /// </summary>
        /// <returns>null       表示インベーダー無し</returns>
        /// <returns>not null   表示するインベーダーのリスト</returns>
        private List<string> GetInvaderList()
        {
            if (0 > dispPos)
            {
                return null;
            }
            else if (dispPos+1 > invaderList.Count())
            {
                var retList = invaderList.GetRange(0, invaderList.Count());
                for (var i= invaderList.Count(); i<dispPos; i++)
                {
                    retList[i] = " ";   // インベーダーの右に空白を挿入
                }
                return retList;
            }
            else
            {
                var retList = invaderList.GetRange(0, dispPos+1);
                return retList;
            }
        }
    }
}

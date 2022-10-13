using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace RollBall
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> data;
        private const string folderName = "dataSave";
        private const string fileName = "data.bat";
        private readonly string path;
        public SaveDataRepository()
        {
            data = new BinaryData<SavedData>();
            path = Path.Combine(Application.dataPath, folderName);
        }
        public void Save(PlayerBall player, List<BonusSave> listBonus)
        {
            if (!Directory.Exists(Path.Combine(path)))
            {
                Directory.CreateDirectory(path);
            }

            var save = new SavedData
            {
                bonusTotal = player.BonusTotal,
                bonusCount = player.BonusCount,
                helth = player.Helth,
                invulnerability = player.Invulnerability,
                playerPos = player.transform.position,
                bonuses = listBonus
            };
            data.Save(save, Path.Combine(path, fileName));
        }

        public void Load(PlayerBall player, ref List<BonusSave> listBonus)
        {
            var file = Path.Combine(path, fileName);
            if (!File.Exists(file)) return;
            var load = data.Load(file);
            player.Init(load.bonusTotal, load.bonusCount, load.helth, load.invulnerability, load.playerPos);
            listBonus = load.bonuses;
        }
    }
}
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using SpongeBob.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeBob
{
    internal class BobMonarca : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => TowerType.DartMonkey;
        public override bool Use2DModel => true;
        public override int Cost => 1;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 1;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Ele é a porra do novo monarca!";
        public override string DisplayName => "Monarca Hadal";
        public override string Icon => "UltraBobCharacterSelado";
        public override string Portrait => Icon;

        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        //public override bool Use2DModel => true;





        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            //towerModel.RemoveBehavior<AttackModel>();
            var weaponModel = towerModel.GetWeapon();
            weaponModel.rate *= 15f;
            towerModel.displayScale = 5;

        }
        public override string Get2DTexture(int[] tiers)
        {
            if (tiers[1] == 1)
            {
                return "UltraBobCharacter010";
            }
            return "UltraBobCharacterSelado";
        }
    }

    internal class MonarcaDaZonaHadal : ModUpgrade<BobMonarca>
    {
        public override string Icon => "UltraBobCharacter010";
        public override string Portrait => Icon;
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 70000000;

        public override string Description => " O NOVO MONARCA EMERGIU! Os bloons serão reduzidos a NADA DIANTE AO PESO DE SUA IRA! Aquele que ousar desafiar o MONARCA estará CONDENADO ao ABISMO! Preparem-se, pois a CARNIFICINA COMEÇARÁ AGORA!";


        public override void ApplyUpgrade(TowerModel tower)
        {

            var Cataclismo = Game.instance.model.GetTowerFromId("BombShooter-520").GetAttackModel().Duplicate();
            var attackModel = tower.GetAttackModel();
            attackModel.weapons[0].projectile.GetDescendant<DamageModel>().damage = 90000000;
            Cataclismo.range = tower.range;
            Cataclismo.name = "Cataclismo";
            tower.AddBehavior(Cataclismo);
            Cataclismo.weapons[0].projectile.GetDescendant<DamageModel>().damage += 99999999;
            attackModel.weapons[0].rate *= .002f;
            Cataclismo.weapons[0].projectile.pierce = 9999999999999999999;

            attackModel.range += 9999999999;
            tower.range += 99999999999;
            attackModel.range += 999999999;
            attackModel.weapons[0].projectile.ApplyDisplay<SpongeBobProjectileDisplay>();
            var knockback = Game.instance.model.GetTower(TowerType.SuperMonkey, 0, 0, 5)
.GetDescendant<KnockbackModel>();
            attackModel.weapons[0].projectile.AddBehavior(knockback);

            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

            var Hadopelagica = Game.instance.model.GetTowerFromId("SuperMonkey-302").GetAttackModel().Duplicate();
            Hadopelagica.range = tower.range;
            Hadopelagica.name = "Hadopelagica";
            Hadopelagica.weapons[0].projectile.pierce = 99999999999969; 
            Hadopelagica.weapons[0].projectile.GetDamageModel().damage = 999999;
            tower.AddBehavior(Hadopelagica);
            tower.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 4855, false, true));
        }
    }
}
    
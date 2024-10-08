using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpongeBob
{
    internal class SandyTower : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.CaveMonkey;
        public override bool Use2DModel => true;
        public override int Cost => 700;
        public override string Portrait => "Sandy";
        public override string Icon => Portrait;

        public override string Description => "Uma cientista e lutadora veio da fenda do bikini para batalhar contra os bloons";
        public override string DisplayName => "Sandy";

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var weaponModel = towerModel.GetWeapon();
            var attackModel = towerModel.GetAttackModel();
            //var projectile = weaponModel.projectile;
            towerModel.radius += 3;
            attackModel.range += 3;
            towerModel.displayScale = 5;
        }
        public override string Get2DTexture(int[] tiers)
        {
            if (tiers[0] == 5)
            {
                return "Sandy500";
            }
            if (tiers[0] == 4)
            {
                return "Sandy400";
            }
            if (tiers[0] == 3)
            {
                return "Sandy300";
            }
            if (tiers[1] == 5)
            {
                return "Sandy050";
            }
            if (tiers[1] == 4)
            {
                return "Sandy040";
            }
            if (tiers[1] == 3)
            {
                return "Sandy030";
            }
            if (tiers[2] == 5)
            {
                return "Sandy005";
            }
            if (tiers[2] == 4)
            {
                return "Sandy004";
            }
            if (tiers[2] == 3)
            {
                return "Sandy003";
            }
            return "Sandy";
        }
    }
    internal class T1 : ModUpgrade<SandyTower>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 650;
        public override string Portrait => "Sandy";
        public override string Icon => Portrait;

        public override string DisplayName => "Força aprimorada";
        public override string Description => "Sandy agora dá mais dano contra os bloons.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.GetDescendant<DamageModel>().damage += 2;
        }
    }
    internal class T2 : ModUpgrade<SandyTower>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 750;
        public override string Portrait => "Sandy";
        public override string Icon => Portrait;

        public override string DisplayName => "Energético 8000";
        public override string Description => "Sandy ataca 20% mais rápido!";


        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetAttackModel().weapons[0].rate *= 0.8f;
        }
    }
    internal class T3 : ModUpgrade<SandyTower>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 2250;
        public override string Portrait => "Sandy300";
        public override string Icon => Portrait;

        public override string DisplayName => "Soco pesado";
        public override string Description => "Sandy agora cria uma pequena explosão ao atacar, podendo destruir chumbo.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
        }
    }
    internal class T4 : ModUpgrade<SandyTower>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 45150;
        public override string Portrait => "Sandy400";
        public override string Icon => Portrait;

        public override string DisplayName => "Forca bruta";
        public override string Description => "Sandy consegue stunnar MOABS...";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.RemoveBehavior<CreateProjectileOnContactModel>();
            projectile.RemoveBehavior<CreateEffectOnContactModel>();
            var explosionStun = Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
            projectile.GetDescendant<DamageModel>().damage += 10;
            projectile.AddBehavior(explosionStun);
        }
    }
    internal class T5 : ModUpgrade<SandyTower>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 545000;
        public override string Portrait => "Sandy500";
        public override string Icon => Portrait;

        public override string DisplayName => "O cataclismo absoluto";
        public override string Description => "SERÁ QUE VOCÊ AGUENTA ESSE NÍVEL DE DESTRUIÇÃO????";


        public override void ApplyUpgrade(TowerModel tower)
        {   
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.RemoveBehavior<CreateProjectileOnContactModel>();
            projectile.RemoveBehavior<CreateEffectOnContactModel>();
            var explosionStun = Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
            projectile.GetDescendant<DamageModel>().damage += 150;
            projectile.GetDescendant<DamageModel>().damage *= 400f;
            attackModel.weapons[0].rate *= 0.2f;
            projectile.AddBehavior(explosionStun);
            var knockback = Game.instance.model.GetTower(TowerType.SuperMonkey, 0, 0, 1)
.GetDescendant<KnockbackModel>();
            attackModel.weapons[0].projectile.AddBehavior(knockback);
        }
    }

    internal class M1 : ModUpgrade<SandyTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 700;
        public override string Portrait => "Sandy";
        public override string Icon => Portrait;

        public override string DisplayName => "Cirurgia Ocular";
        public override string Description => "Sandy agora concede visão de camuflado a todas as torres em seu alcance.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.AddBehavior(new VisibilitySupportModel("VisibilitySupportModel_", true, "MeerkatSpy:Visibility",false, null, "RadarScannerBuff", "BuffIconVillagex2x"));
        }
    }
    internal class M2 : ModUpgrade<SandyTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 1500;
        public override string Portrait => "Sandy";
        public override string Icon => Portrait;

        public override string DisplayName => "Treinamento texano";
        public override string Description => "Sandy concede um buff a todas as torres em seu alcance.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var Buff1 = new RangeSupportModel("RangeSupport", true, 0f, 5, "Range:Support", null, false, null, null);
            var Buff2 = new RateSupportModel("RateBuff", 0.9f, true, "Rate:Support", false, 1, null, "RadarScannerBuff", "BuffIconVillagex2x", false);
            var Buff3 = new DamageSupportModel("DamageAddaptive", true, 2, "Damage:Support", null, false, false, 0);
            tower.AddBehavior(Buff2);
            tower.AddBehavior(Buff3);
            tower.AddBehavior(Buff1);
        }
    }
    internal class M3 : ModUpgrade<SandyTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 6700;
        public override string Portrait => "Sandy030";
        public override string Icon => Portrait;

        public override string DisplayName => "Surto de Energia";
        public override string Description => "Aumenta significativamente a velocidade de ataque, fazendo as torres próximas dispararem a uma taxa surpreendente!";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var Buff = new RateSupportModel("RateBuff", 0.5f, true, "Rate:Support", false, 1, null, "RadarScannerBuff", "BuffIconVillagex2x", false);
            tower.AddBehavior(Buff);
        }
    }
    internal class M4 : ModUpgrade<SandyTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 4200;
        public override string Portrait => "Sandy040";
        public override string Icon => Portrait;
        public override string DisplayName => "Vínculo da agonia";
        public override string Description => "Uma cola sinistra que desacelera os bloons, causando um tormento agonizante.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            var glue = Game.instance.model.GetTower(TowerType.GlueGunner, 1, 0, 4).GetAttackModel().Duplicate();
            glue.range = tower.range;
            glue.name = "Glue";
            tower.AddBehavior(glue);
        }
    }
    internal class M5 : ModUpgrade<SandyTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost =>200000;
        public override string Portrait => "Sandy050";
        public override string Icon => Portrait;

        public override string DisplayName => "MONARQUIA ABSOLUTA";
        public override string Description => "A cola se torna ainda mais poderosa, condenando-os inevitavelmente a morte. Enquanto isso, torres próximas ganham poder com a agonia e desespero dos bloons.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            var glue = Game.instance.model.GetTower(TowerType.GlueGunner, 1, 0, 4).GetAttackModel().Duplicate();
            glue.range = tower.range;
            glue.name = "Glue";
            tower.AddBehavior(glue);
            var Buff1 = new RangeSupportModel("RangeSupport", true, 0f, 10, "Range:Support", null, false, null, null);
            var Buff2 = new RateSupportModel("RateBuff", 0.2f, true, "Rate:Support", false, 1, null, "RadarScannerBuff", "BuffIconVillagex2x", false);
            var Buff3 = new DamageSupportModel("DamageAddaptive", true, 20, "Damage:Support", null, false, false, 0);
            var Buff4 = new PierceSupportModel("PierceSupport", true, 40f, "Pierce:Support", null, false, "PierceBuff", "Zombey_Buff");
            tower.AddBehavior(Buff1);
            tower.AddBehavior(Buff2);
            tower.AddBehavior(Buff3);
            tower.AddBehavior(Buff4);
            
        }
    }
    internal class B1 : ModUpgrade<SandyTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 1250;
        public override string Portrait => "Sandy";
        public override string Icon => Portrait;

        public override string DisplayName => "Olhinhos maiores";
        public override string Description => "Aumenta o alcance de ataque e buffs da sandy c:";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            tower.range += 20;
            attackModel.range += 20;
        }
    }
    internal class B2 : ModUpgrade<SandyTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 980;
        public override string Portrait => "Sandy";
        public override string Icon => Portrait;

        public override string DisplayName => "Espinhos Texanos";
        public override string Description => "Sandy joga espinhos pelo campo, que furam bloons que passam.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var spikes = Game.instance.model.GetTowerFromId("NinjaMonkey-002").GetAttackModel(1).Duplicate();
            tower.AddBehavior(spikes);  
        }
    }

    internal class B3 : ModUpgrade<SandyTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 3600;
        public override string Portrait => "Sandy003";
        public override string Icon => Portrait;

        public override string DisplayName => "Armadilha do Texas";
        public override string Description => "Sandy joga uma armadilha no campo que captura todos os bloons pequenos.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var trap = Game.instance.model.GetTowerFromId("EngineerMonkey-024").behaviors.First(a => a.name.Contains("BloonTrap")).Cast<AttackModel>().Duplicate();
            trap.range = 40;
            tower.range = 40;
            trap.weapons[0].projectile.pierce = 300;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCapacity = 300;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCashMultiplier = 2.5f;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.pierce = 300;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().minimum = 600;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().maximum = 1000;
            trap.weapons[0].Rate = 5;
            tower.AddBehavior(trap);
        }
    }
    internal class B4 : ModUpgrade<SandyTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 5500;
        public override string Portrait => "Sandy004";
        public override string Icon => Portrait;

        public override string DisplayName => "Armadilha do Texas Titan";
        public override string Description => "Heh... Armadilha maior, mais bloons estorados, mais dinheiro ganho... Heh...";


        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.towerSelectionMenuThemeId = "SelectPointInput";
            var trap = Game.instance.model.GetTowerFromId("EngineerMonkey-024").behaviors.First(a => a.name.Contains("BloonTrap")).Cast<AttackModel>().Duplicate();
            trap.range = 40;
            tower.range = 40;
            trap.weapons[0].projectile.pierce = 1800;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCapacity = 1800;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCashMultiplier = 2.5f;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.pierce = 1800;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().minimum = 3200;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().maximum = 7000;
            trap.weapons[0].Rate = 10;
            tower.AddBehavior(trap);
        }
    }
    internal class B5 : ModUpgrade<SandyTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 155000;
        public override string Portrait => "Sandy005";
        public override string Icon => Portrait;

        public override string DisplayName => "Armadilha do Texas Hadopelágica";
        public override string Description => "TÁ VENDO O DESESPERO DOS BLOONS???????? VÃO TUDO SUCUMBIR AGORA, CARAMBOLAS AQUÁTICAS!";


        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.towerSelectionMenuThemeId = "SelectPointInput";
            var trap = Game.instance.model.GetTowerFromId("EngineerMonkey-025").behaviors.First(a => a.name.Contains("BloonTrap")).Cast<AttackModel>().Duplicate();
            trap.range = 40;
            tower.range = 40;
            trap.weapons[0].projectile.pierce = 900000;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCapacity = 900000;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCashMultiplier = 3f;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.pierce = 900000;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().minimum = 150000;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().maximum = 450000;   
            trap.weapons[0].Rate = 10;
            tower.AddBehavior(trap);
        }
    }
}
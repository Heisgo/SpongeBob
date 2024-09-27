using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Unity.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Stats;
using SpongeBob.Display;
using UnityEngine;
using MelonLoader;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using System;
using UnityEngine.UIElements;
using Il2CppAssets.Scripts.Unity.Towers.Projectiles;
using PathsPlusPlus;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace SpongeBob
{
    internal class SpongeBob : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => TowerType.DartMonkey;
        public override bool Use2DModel => true;
        public override int Cost => 400;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Atira bolhas de sabão nos bloons.";
        public override string DisplayName => "SpongeBob";
        public override string Icon => "BobCharacter";
        public override string Portrait => "bobesponjacomm";
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        //public override bool Use2DModel => true;





        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon();
            var projectileModel = weaponModel.projectile;
            attackModel.range += 8;
            towerModel.range += 8;


            var projectile = attackModel.weapons[0].projectile;
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            projectile.pierce += 1;
            towerModel.ApplyDisplay<SpongeBobDisplay>();
            towerModel.displayScale = 5;
            projectileModel.scale = 2;
        }
        public override string Get2DTexture(int[] tiers)
        {
            if (tiers[0] == 2 && tiers[1] <= 2 && tiers[2] <= 1)
            {
                return "BobCharacter200";
            }
            if (tiers[0] == 3)
            {
                return "BobCharacter300";
            }
            if (tiers[0] == 4)
            {
                return "BobCharacter400";
            }
            if (tiers[0] == 5)
            {
                return "BobCharacter500";
            }
            if (tiers[1] == 3)
            {
                return "BobCharacter030";
            }
            if (tiers[1] == 4)
            {
                return "BobCharacter040";
            }
            if (tiers[1] == 5)
            {
                return "BobCharacter050";
            }
            if (tiers[2] == 2 && tiers[1] <= 2 && tiers[0] <= 1)
            {
                return "BobCharacter002";
            }
            if (tiers[2] == 3)
            {
                return "BobCharacter003";
            }
            if (tiers[2] == 4)
            {
                return "BobCharacter004";
            }
            if (tiers[2] == 5)
            {
                return "BobCharacter005";
            }
            return "BobCharacter";
        }
    }
    internal class BolhaAprimorada : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter100";
        public override string Portrait => Icon;
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 200;

        public override string Description => " Agora as bolhas de Bob perfuram com fúria, atravessando de forma mais afiada. Também ganha a habilidade de estourar chumbo e congelados.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce += 1;
            projectile.GetDamageModel().damage += 1;
            //weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        }
    }
    internal class BolhasCortantes : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter200";
        public override string Portrait => Icon;
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 320;

        public override string Description => "A fúria das bolhas crescem. Nenhum bloon normal é poupado, são rasgados com uma facilidade brutal.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce += 5  ;
            projectile.GetDamageModel().damage += 1;
        }
    }
    internal class BolhasExplosivas : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter300";
        public override string Portrait => Icon;
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 3100;

        public override string Description => "As bolhas alcançam um novo nível de destruição. Agora, explodem ao contato, criando uma onda tão poderosa que é capaz de stunnar os bloons..";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectile = Game.instance.model.GetTower(TowerType.BombShooter, 4, 0, 0).GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.GetDescendant<DamageModel>().damage += 1;
            var projectileModel = weaponModel.projectile;
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            attackModel.weapons[0].projectile = projectile;
            tower.AddBehavior(attackModel);
        }
    }
    internal class FuriaDasMares : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter400";
        public override string Portrait => Icon;
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 58535;

        public override string Description => "As bolhas se transformam em verdadeiras aniquiladoras de bloons. Com o poder das marés, dão dano massivo e conseguem stunnar classe MOAB.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectile = Game.instance.model.GetTower(TowerType.BombShooter, 5, 0, 0).GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage *= 10;
            attackModel.weapons[0].projectile = projectile;
            var projectileModel = weaponModel.projectile;
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            tower.AddBehavior(attackModel);
            projectile.GetDescendant<DamageModel>().damage += 28;
        }
    }
    internal class AIraAbissal : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter500";
        public override string Portrait => Icon;
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 978246;

        public override string Description => "Bob se torna o próprio abismo. O portador da destruição absoluta. Invoca bolhas titãs que carregam o peso de toda a zona abissal. Detonam os bloons em uma velocidade hipersônica. O mapa se torna um grande cemitério de bloons erradicados.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectile = Game.instance.model.GetTower(TowerType.BombShooter, 5, 0, 0).GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage *= 10;
            attackModel.weapons[0].projectile = projectile;
            var projectileModel = weaponModel.projectile;
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            tower.AddBehavior(attackModel);
            projectile.GetDescendant<DamageModel>().damage += 2200;
            weaponModel.rate *= 0.1f;
            var knockback = Game.instance.model.GetTower(TowerType.SuperMonkey, 0, 0, 5)
    .GetDescendant<KnockbackModel>();
            projectileModel.AddBehavior(knockback);
        }
    }
    internal class ChuvaDeBolhas : ModUpgrade<SpongeBob>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 700;

        public override string Description => "Atira 5 bolhas de uma vez!";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);
        }
    }
    internal class BolhasExtras : ModUpgrade<SpongeBob>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 900;

        public override string Description => "As bolhas se multiplicam ao contato com os bloons!";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectile = Game.instance.model.GetTower(TowerType.BombShooter, 0, 0, 3).GetAttackModel().weapons[0].projectile.Duplicate();
            attackModel.weapons[0].projectile = projectile;
            var projectileModel = weaponModel.projectile;
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            tower.AddBehavior(attackModel);
            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);
        }
    }
    internal class BolhasRecursivas : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter030";
        public override string Portrait => Icon;
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 2790;

        public override string Description => "As bolhas se tornam bem mais fortes e se multiplicam ainda mais. A zona Batial começa a tomar conta de Bob.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectile = Game.instance.model.GetTower(TowerType.BombShooter, 0, 0, 4).GetAttackModel().weapons[0].projectile.Duplicate();
            attackModel.weapons[0].projectile = projectile;
            tower.AddBehavior(attackModel);
            projectile.GetDescendant<DamageModel>().damage += 4;
            var projectileModel = weaponModel.projectile;
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            weaponModel.rate *= 0.85f;
            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);
        }
    }
    internal class TsunamiDeBolhas : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter040";
        public override string Portrait => Icon;
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 17800;

        public override string Description => "O oceano responde ao comando de Bob. Uma onda colossal de bolhas assassinas varre o campo, deixando uma carnificina pela arena.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectileModel = weaponModel.projectile;
            var projectileDart = Game.instance.model.GetTower(TowerType.DartMonkey, 5, 0, 0).GetWeapon().projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
            projectileDart.projectile.display = weaponModel.projectile.display;
            weaponModel.projectile.AddBehavior(projectileDart);
            projectileDart.GetDescendant<DamageModel>().damage += 1;
            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0, 30, null, false, false);
            projectileDart.emission = new ArcEmissionModel("ArcEmissionModel", 10, 0, 360, null, false, false);
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            projectileModel.scale = 4;
            projectileDart.projectile.scale = 3;            
        }
    }
    internal class CataclismoAbissal : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter050";
        public override string Portrait => Icon;
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 850000;

        public override string Description => "Bob se torna a encarnação do terror da zona hadopelágica, evocando o cataclismo das profundezas." +
            "O campo se torna o próprio abismo, repleto de desespero. Qualquer um que ouse cruzar o caminho " +
            "de Bob, estará condenado a sucumbir diante às trevas. A morte é a única certeza presente.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var projectileModel = weaponModel.projectile;
            var oldprojectile = projectileModel.Duplicate();
            var projectileDart = Game.instance.model.GetTower(TowerType.DartMonkey, 5, 0, 0).GetAttackModel().weapons[0].projectile.Duplicate();
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            projectileDart.display = weaponModel.projectile.display;
            projectileModel.AddBehavior(projectileDart);
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            projectileModel.GetDescendant<DamageModel>().damage += 1000;
            projectileDart.GetDescendant<DamageModel>().damage += 800;
            var judgement = projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>();
            var Ability = Game.instance.model.GetTower(TowerType.Mermonkey, 0,5,0).GetAbilities()[0].Duplicate();
            Ability.maxActivationsPerRound = 9999999;
            Ability.canActivateBetweenRounds = true;
            Ability.resetCooldownOnTierUpgrade = true;
            Ability.cooldown = 3;
            Ability.icon = GetSpriteReference("BolhaDeSabao");
            tower.AddBehavior(Ability);
            weaponModel.rate *= 0.15f;
            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);
            judgement.emission = new ArcEmissionModel("ArcEmissionModel", 10, 0, 360, null, false, false);
            projectileModel.ApplyDisplay<SpongeBobProjectileDisplay>();
            projectileModel.scale = 0.01f;
            //projectileDart.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            //projectileDart.projectile.scale = 3;
        }
    }
    internal class VisaoPerfeita : ModUpgrade<SpongeBob>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 240;

        public override string Description => "Ganha a habilidade de detectar Camo Bloons. Seus ataques agora podem atingir Camo Bloons";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
    internal class FeiticoDoReiNetuno : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter002";
        public override string Portrait => Icon;
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 900;

        public override string Description => "Começa a produzir dinheiro extra e aumenta levemente o alcance.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var MoneyDee = Game.instance.model.GetTowerFromId("BananaFarm-220").GetAttackModel().Duplicate();
            MoneyDee.name = "BananaFarm_Dee";
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().maximum = 22;
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().minimum = 15;
            tower.AddBehavior(MoneyDee);
            attackModel.range += 1;
            tower.range += 1;
        }
    }

    internal class FeiticoDoReiNetunoMaisPoderoso : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter003";
        public override string Portrait => Icon;
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 4969;

        public override string Description => "Com o poder do Rei Netuno, Bob começa a produzir o **TRIPLO** de dinheiro e aumenta levemente o alcance. Ademais, ganha +2Perfuração, +2Dano e +10% de velocidade de ataque.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var MoneyDee = Game.instance.model.GetTowerFromId("BananaFarm-320").GetAttackModel().Duplicate();
            MoneyDee.name = "BananaFarm_Dee";
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().maximum = 66;
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().minimum = 45;
            tower.AddBehavior(MoneyDee);
            attackModel.range += 1;
            tower.range += 1;
            weaponModel.projectile.pierce += 2;
            weaponModel.GetDescendant<DamageModel>().damage += 2;
            weaponModel.rate *= 0.9f;
        }
    }
    internal class HamburguerDeSiriDourado : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter004";
        public override string Portrait => Icon;
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 17000;

        public override string Description => "Aumenta ainda mais os ganhos de dinheiro com a produção de hamburguers de siri dourados.";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var MoneyDee = Game.instance.model.GetTowerFromId("BananaFarm-024").GetAttackModel().Duplicate();
            MoneyDee.name = "BananaFarm_Dee";
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().maximum = 200;
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().minimum = 120;
            tower.AddBehavior(MoneyDee);
        }
    }
    
    internal class CondenacaoDivinaDoOuro : ModUpgrade<SpongeBob>
    {
        public override string Icon => "BobCharacter005";
        public override string Portrait => Icon;
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 816969;
        

        public override string Description => "CONTEMPLEM A CONDENAÇÃO DIVIDA!";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weaponModel = tower.GetWeapon();
            var MoneyDee = Game.instance.model.GetTowerFromId("BananaFarm-420").GetAttackModel().Duplicate();
            MoneyDee.name = "BananaFarm_Dee";
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().maximum = 9400;
            MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().minimum = 6300;
            tower.AddBehavior(MoneyDee);
            attackModel.range += 7;
            tower.range += 7;
            weaponModel.projectile.pierce += 1;
            weaponModel.GetDescendant<DamageModel>().damage += 5;
            weaponModel.rate *= 0.6f;

        }
    }
    internal class MonarcaDaZonaHadalParagon : PathPlusPlus
    {
        public override string Tower => TowerID<SpongeBob>();
        public override int ExtendVanillaPath => Middle;
    }
    /*
    internal class MonarcaDaZonaHadal : ModParagonUpgrade<SpongeBob>
    {
        public override int Cost => 400000;
        public override string Description => "O NOVO MONARCA EMERGIU! Os bloons serão reduzidos a NADA DIANTE AO PESO DE SUA IRA! Aquele que ousar desafiar o MONARCA estará CONDENADO ao ABISMO! Preparem-se, pois a CARNIFICINA COMEÇARÁ AGORA! ";
        public override string DisplayName => "Monarca Da Zona Hadopelágica";


        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 69696969;
            towerModel.GetAttackModel().weapons[0].rate *= .04f;
            towerModel.GetAttackModel().weapons[0].projectile.pierce = 69696969696969;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
            // ELE É A PORRA DO NOVO MONARCA!
        }
    }
    */
}

using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class SniperBot : Bot {

    int turnCounter;

    static void Main(string[] args)
    {
        new SniperBot().Start();
    }

    SniperBot() : base(BotInfo.FromFile("SniperBot.json")) { }

    public override void Run()
    {
        BodyColor   = Color.FromArgb(0x1E, 0x46, 0x1E); // hijau tua
        TurretColor = Color.FromArgb(0x50, 0x8C, 0x28); // hijau olive
        RadarColor  = Color.FromArgb(0xA0, 0xD2, 0x3C); // hijau terang
        turnCounter = 0;
        GunTurnRate = 5; // Lambat tapi presisi

        while (IsRunning) {
            // Gerak pelan melingkar biar susah ditembak
            if (turnCounter % 100 == 0) {
                TurnRate = 2;
                TargetSpeed = 2;
            }
            if (turnCounter % 100 == 50) {
                TurnRate = -2;
                TargetSpeed = 2;
            }
            turnCounter++;
            Go();
        }
    }

    public override void OnScannedBot(ScannedBotEvent e) {
        double distance = DistanceTo(e.X, e.Y);
        double angleToEnemy = BearingTo(e.X, e.Y);
        GunTurnRate = NormalizeRelativeAngle(angleToEnemy - GunDirection);

        // Sniper: tembak keras dari jauh
        if (distance > 300) {
            Fire(3);
        } else if (distance > 150) {
            Fire(2);
        } else {
            Fire(1); // Terlalu dekat, hemat energi
        }
    }

    public override void OnHitByBullet(HitByBulletEvent e) {
        // Kabur menjauh
        TurnRate = 5;
        TargetSpeed = 4;
    }

    public override void OnHitWall(HitWallEvent e) {
        TargetSpeed = -1 * TargetSpeed;
        TurnRate = 5;
    }

    public override void OnHitBot(HitBotEvent e) {
        TargetSpeed = -4;
        TurnRate = 8;
    }
}
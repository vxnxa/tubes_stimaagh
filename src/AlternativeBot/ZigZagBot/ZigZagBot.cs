using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class ZigZagBot : Bot {

    int turnCounter;

    static void Main(string[] args)
    {
        new ZigZagBot().Start();
    }

    ZigZagBot() : base(BotInfo.FromFile("ZigZagBot.json")) { }

    public override void Run()
    {
        BodyColor   = Color.FromArgb(0x64, 0x00, 0x8C); // ungu tua
        TurretColor = Color.FromArgb(0xC8, 0x00, 0xB4); // magenta
        RadarColor  = Color.FromArgb(0xFF, 0x50, 0xDC); // pink-ungu
        turnCounter = 0;
        GunTurnRate = 15;

        while (IsRunning) {
            // Zigzag cepat biar susah di-aim
            if (turnCounter % 20 == 0) {
                TurnRate = 7;
                TargetSpeed = 7;
            }
            if (turnCounter % 20 == 10) {
                TurnRate = -7;
                TargetSpeed = 7;
            }
            turnCounter++;
            Go();
        }
    }

    public override void OnScannedBot(ScannedBotEvent e) {
        double distance = DistanceTo(e.X, e.Y);
        double angleToEnemy = BearingTo(e.X, e.Y);
        GunTurnRate = NormalizeRelativeAngle(angleToEnemy - GunDirection);

        // Tembak sambil zigzag
        if (distance < 200) {
            Fire(2);
        } else {
            Fire(1);
        }
    }

    public override void OnHitByBullet(HitByBulletEvent e) {
        // Balik arah zigzag
        TurnRate = -TurnRate;
        TargetSpeed = -TargetSpeed;
    }

    public override void OnHitWall(HitWallEvent e) {
        TargetSpeed = -1 * TargetSpeed;
        TurnRate = -TurnRate;
    }

    public override void OnHitBot(HitBotEvent e) {
        TargetSpeed = -5;
        TurnRate = 10;
    }
}
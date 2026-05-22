using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class StimaaghBot : Bot {

    int turnCounter;

    static void Main(string[] args)
    {
        new StimaaghBot().Start();
    }

    StimaaghBot() : base(BotInfo.FromFile("StimaaghBot.json")) { }

    public override void Run()
    {
        BodyColor   = Color.FromArgb(0xDC, 0x1E, 0x1E); // merah tua
        TurretColor = Color.FromArgb(0xFF, 0x64, 0x00); // oranye
        RadarColor  = Color.FromArgb(0xFF, 0xDC, 0x00); // kuning
        turnCounter = 0;
        GunTurnRate = 20;

        while (IsRunning) {
            if (turnCounter % 50 == 0) {
                TurnRate = 0;
                TargetSpeed = 8;
            }
            if (turnCounter % 50 == 25) {
                TurnRate = 0;
                TargetSpeed = -8;
            }
            turnCounter++;
            Go();
        }
    }

    public override void OnScannedBot(ScannedBotEvent e) {
        double distance = DistanceTo(e.X, e.Y);
        double angleToEnemy = BearingTo(e.X, e.Y);
        GunTurnRate = NormalizeRelativeAngle(angleToEnemy - GunDirection);

        if (distance < 100) {
            Fire(3);
        } else {
            Fire(2);
        }
    }

    public override void OnHitByBullet(HitByBulletEvent e) {
        TurnRate = 0;
        TargetSpeed = -TargetSpeed;
    }

    public override void OnHitWall(HitWallEvent e) {
        TargetSpeed = -1 * TargetSpeed;
    }

    public override void OnHitBot(HitBotEvent e) {
        TargetSpeed = -6;
    }
}
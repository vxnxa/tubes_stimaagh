using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class CounterBot : Bot {

    int turnCounter;
    double lastEnemyX;
    double lastEnemyY;
    double enemyBearing;

    static void Main(string[] args)
    {
        new CounterBot().Start();
    }

    CounterBot() : base(BotInfo.FromFile("CounterBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.FromArgb(0x99, 0x99, 0x99);   // lighter gray
        TurretColor = Color.FromArgb(0x88, 0x88, 0x88); // gray
        RadarColor = Color.FromArgb(0x66, 0x66, 0x66);  // dark gray
        turnCounter = 0;

        // Putar gun lebih lambat biar lebih akurat saat scan
        GunTurnRate = 10;

        while (IsRunning) {
            if (turnCounter % 80 == 0) {
                TurnRate = 3; // Gerak melingkar biar susah ditembak
                TargetSpeed = 6; // Lebih cepat dari VelocityBot
            }
            if (turnCounter % 80 == 40) {
                TurnRate = -3; // Balik arah putaran
                TargetSpeed = 5;
            }
            turnCounter++;
            Go();
        }
    }

    // Saat scan musuh -> tembak dengan power lebih besar
    public override void OnScannedBot(ScannedBotEvent e) {
        enemyBearing = e.Direction;

        // Hitung jarak musuh
        double distance = DistanceTo(e.X, e.Y);

        // Tembak lebih keras kalau musuh dekat, hemat peluru kalau jauh
        if (distance < 150) {
            Fire(3);
        } else if (distance < 300) {
            Fire(2);
        } else {
            Fire(1);
        }

        // Arahkan gun ke posisi musuh
        double angleToEnemy = BearingTo(e.X, e.Y);
        GunTurnRate = NormalizeRelativeAngle(angleToEnemy - GunDirection);
    }

    // Kena peluru -> zigzag lebih agresif
    public override void OnHitByBullet(HitByBulletEvent e) {
        // Balik arah dan percepat untuk kabur
        TurnRate = 8;
        TargetSpeed = -TargetSpeed;
    }

    // Kena tembok -> balik arah
    public override void OnHitWall(HitWallEvent e) {
        TargetSpeed = -1 * TargetSpeed;
        TurnRate = 10; // Belok tajam menjauhi tembok
    }

    // Kalau nabrak bot lain -> mundur
    public override void OnHitBot(HitBotEvent e) {
        TargetSpeed = -4;
        TurnRate = 6;
    }
}
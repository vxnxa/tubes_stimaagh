# Custom Bots for Robocode Tank Royale (C# / .NET)

Direktori ini berisi kumpulan bot kustom untuk "Robocode Tank Royale" yang dikembangkan menggunakan bahasa pemrograman C# pada platform .NET. Proyek ini disusun untuk memenuhi Tugas Besar Strategi Algoritma 2026/2027 Program Studi Teknik Informatika ITERA.

## Daftar Bot

Proyek ini mencakup empat bot dengan strategi dan karakteristik yang berbeda-beda:

Counter Bot: Bot yang dirancang secara spesifik untuk meng-counter (melawan) pergerakan dan strategi dari Velocity Bot yang ada di sample bawaan Robocode.
Stimaagh Bot: Bot dengan tipe penyerang agresif. Bot ini akan terus mendekat dan menembak musuh secara acak dan intens, memberikan tekanan terus-menerus di arena.
Sniper Bot: Bot penembak jitu yang dinamis. Mekanik utamanya bergantung pada jarak: semakin dekat jarak bot ini dengan target, semakin cepat fire rate (kecepatan menembak) yang dihasilkan.
Zigzag Bot: Bot yang mengandalkan pergerakan tidak tertebak dengan pola lintasan zigzag untuk menyulitkan musuh saat membidik.

## Persyaratan Sistem

Untuk menjalankan dan memodifikasi bot ini, pastikan sistem Anda memiliki:

1. Robocode Tank Royale: Menggunakan game engine modifikasi (file `robocode-tankroyale-gui-0.30.0.jar`).
2. .NET SDK: Versi .NET yang terinstal harus sesuai dengan versi yang tertera pada tag `<TargetFramework>` di dalam file `.csproj` masing-masing bot.
3. Visual Studio Code (Opsional, untuk proses pengembangan).

## Cara Menjalankan Bot via GUI

Untuk memainkan bot ini di arena pertempuran melalui antarmuka grafis, ikuti langkah-langkah berikut:

1.  Jalankan file `.jar` aplikasi GUI Robocode.
2.  Konfigurasi direktori bot dengan mengklik menu "Config", lalu pilih.
3.  Masukkan dan "add" direktori/folder utama yang berisi folder bot C# ini, lalu klik OK.
4.  Klik menu "Battle", lalu pilih "Start Battle". 
5.  Pada jendela yang muncul, bot akan otomatis terdeteksi di kotak kiri-atas. Pilih bot yang ingin dimainkan, lalu klik tombol "Boot".
6.  Setelah bot berhasil di-"boot" dan muncul di kotak kiri-bawah, pilih bot tersebut dan klik tombol "Add" untuk memasukkannya ke arena pertempuran.
7.  Mulai permainan dengan menekan tombol "Start Battle".

## Pemecahan Masalah (Troubleshooting)

Apabila bot tidak muncul di panel "Joined Bots" atau gagal melakukan *boot*, coba langkah perbaikan berikut:

Pemeriksaan Direktori: Pastikan path direktori folder penyimpanan bot tidak memiliki spasi.
Pemeriksaan Versi .NET: Cek versi .NET di terminal dengan `dotnet --version`. 
Buka file `.csproj` bot, dan pastikan tag `<TargetFramework>` sesuai dengan versi sistem Anda (misal: `<TargetFramework>net6.0</TargetFramework>`).
Clean Build: Hapus folder `bin` dan `obj` yang ada di dalam direktori bot, lalu coba boot ulang.
Eksekusi Terminal (Server Lokal): Jika menggunakan terminal, pastikan local server berjalan dan atur konfigurasi `SERVER_SECRET` pada terminal menggunakan secret key yang didapat dari file `server.properties` sebelum menjalankan perintah `dotnet run`.
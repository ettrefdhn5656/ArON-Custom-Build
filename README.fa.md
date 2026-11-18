<p align="center">
  <img src="v2rayN/v2rayN.Desktop/Assets/ArON-logo.png" width="160" height="160" alt="ArON" />
</p>

<h1 align="center">ArON</h1>

<p align="center">
  کلاینت VPN دسکتاپ با رابط شیشه‌ای (Liquid Glass) —<br/>
  بومی روی مک، راحت روی ویندوز.
</p>

<p align="center">
  <a href="https://github.com/ArasTey/ArON/releases/latest"><img src="https://img.shields.io/badge/دانلود-v7.25.58-green" alt="دانلود" /></a>
  <img src="https://img.shields.io/badge/پلتفرم-macOS%20arm64%20%7C%20Windows%20x64-blue" alt="پلتفرم" />
  <img src="https://img.shields.io/badge/.NET-10.0-512bd4" alt=".NET 10" />
  <a href="LICENSE"><img src="https://img.shields.io/badge/لایسنس-GPL--3.0-green" alt="لایسنس" /></a>
</p>

---

## دانلود

آخرین نسخه از [Releases](https://github.com/ArasTey/ArON/releases):

| پلتفرم | فایل |
|---|---|
| مک (Apple Silicon) | `MehrON-macos-arm64.dmg` — نصب با کشیدن و رها کردن، یا فایل `.zip` |
| ویندوز ۶۴ بیتی | `MehrON-windows-64.zip` — پرتابل، همراه با هسته‌ها |

## ویژگی‌ها

- **رابط شیشه‌ای** — ظاهر دسکتاپ مدرن با سه تم: روشن، تاریک و ایران باستان
- **حالت TUN که واقعاً کار می‌کند** — روتینگ کامل سیستم با محافظت از نشت DNS: در حین اتصال همهٔ DNSهای سیستم از داخل تونل می‌گذرد و با قطع اتصال تنظیمات قبلی برمی‌گردد؛ سایت‌های فیلترشده مستقیم در مرورگر باز می‌شوند
- **موتور چند‌هسته‌ای** — Xray، sing-box، mihomo و aether (با Psiphon داخلی) همراه برنامه؛ بدون نیاز به دانلود در اجرای اول
- **حس بومی مک** — منوی واقعی اپلیکیشن با میانبرهای ⌘، حضور در Dock و ⌘-Tab، فونت سیستم و آیکون اختصاصی
- **پشتیبانی از لینک اشتراک** — ورود لینک‌های `vless://`، `vmess://`، `trojan://` و `ss://`، سابسکریپشن، اسکن QR و کارت‌های تنظیمات رمزنگاری‌شده

## ساخت

```bash
dotnet publish v2rayN/v2rayN.Desktop -c Release -r osx-arm64 --self-contained true \
  -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

برای ویندوز از `-r win-x64` استفاده کنید. برنامه تنظیماتش را کنار فایل اجرایی ذخیره می‌کند (چیدمان پرتابل).

## لایسنس

GPL-3.0 — [LICENSE](LICENSE).

<p align="center"><a href="README.md">English</a></p>

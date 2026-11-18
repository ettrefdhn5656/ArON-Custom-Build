<p align="center">
  <img src="v2rayN/v2rayN.Desktop/Assets/ArON-logo.png" width="160" height="160" alt="ArON" />
</p>

<h1 align="center">ArON</h1>

<p align="center">
  A desktop VPN client with a liquid-glass UI —<br/>
  native on macOS, at home on Windows.
</p>

<p align="center">
  <a href="https://github.com/ArasTey/ArON/releases/latest"><img src="https://img.shields.io/badge/download-v7.25.58-green" alt="Download" /></a>
  <img src="https://img.shields.io/badge/platform-macOS%20arm64%20%7C%20Windows%20x64-blue" alt="Platform" />
  <img src="https://img.shields.io/badge/.NET-10.0-512bd4" alt=".NET 10" />
  <img src="https://img.shields.io/badge/Avalonia-12-glass" alt="Avalonia" />
  <a href="LICENSE"><img src="https://img.shields.io/badge/license-GPL--3.0-green" alt="License" /></a>
</p>

---

## Downloads

Grab the latest build from [Releases](https://github.com/ArasTey/ArON/releases):

| Platform | File |
|---|---|
| macOS (Apple Silicon) | `MehrON-macos-arm64.dmg` — drag-to-install, or the `.zip` |
| Windows 64-bit | `MehrON-windows-64.zip` — portable, cores included |

## Highlights

- **Liquid-glass UI** — frosted desktop visuals in three themes: Light, Dark, and Ancient Iran
- **TUN mode that actually works** — full system routing with DNS-leak protection: while connected, all system DNS goes through the tunnel, and your original settings are restored on disconnect, so censored sites open right in the browser
- **Multi-core engine** — Xray, sing-box, mihomo, and aether (with embedded Psiphon) bundled; no downloads needed on first run
- **Native macOS feel** — real app menu with ⌘ shortcuts, Dock and ⌘-Tab presence, system font, and its own icon
- **Share-link ready** — `vless://`, `vmess://`, `trojan://`, `ss://` imports, subscriptions, QR scanning, and encrypted config cards

## Build

```bash
dotnet publish v2rayN/v2rayN.Desktop -c Release -r osx-arm64 --self-contained true \
  -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

For Windows use `-r win-x64`. The app stores its configs next to the binary (portable layout).

## License

GPL-3.0 — see [LICENSE](LICENSE).

<p align="center" dir="rtl"><a href="README.fa.md">فارسی 🇮🇷</a></p>

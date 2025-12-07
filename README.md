<h1 align="center">Jellyfin Google Books Plugin</h1>
<h3 align="center">Part of the <a href="https://jellyfin.org/">Jellyfin Project</a></h3>

<p align="center">

<img alt="Logo Banner" src="https://raw.githubusercontent.com/jellyfin/jellyfin-ux/master/branding/SVG/banner-logo-solid.svg?sanitize=true"/>
<br/>
<br/>
<a href="https://github.com/jellyfin/jellyfin-plugin-bookshelf/actions/workflows/build.yaml">
<img alt="GitHub Workflow Status" src="https://img.shields.io/github/actions/workflow/status/jellyfin/jellyfin-plugin-bookshelf/build.yaml">
</a>
<a href="https://github.com/jellyfin/jellyfin-plugin-bookshelf">
<img alt="MIT License" src="https://img.shields.io/github/license/jellyfin/jellyfin-plugin-bookshelf.svg"/>
</a>
<a href="https://github.com/jellyfin/jellyfin-plugin-bookshelf/releases">
<img alt="Current Release" src="https://img.shields.io/github/release/jellyfin/jellyfin-plugin-bookshelf.svg"/>
</a>
</p>

## About

This plugin adds metadata and image providers for Google Books.

## Build & Installation Process

1. Clone this repository

2. Ensure you have .NET Core SDK setup and installed

3. Build the plugin with following command:

```bash
dotnet publish --configuration Release --output bin
```

4. Place the resulting `Jellyfin.Plugin.GoogleBooks.dll` file in a folder called `plugins/` inside your Jellyfin installation / data directory.

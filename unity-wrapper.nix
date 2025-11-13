{
  pkgs ? import <nixpkgs> { },
}:
let
  unityFHS = pkgs.buildFHSEnv {
    name = "unity-editor-fhs";
    targetPkgs =
      pkgs: with pkgs; [
        openssl
        openssl_1_1
        xorg.libXrandr # <-- This was missing!
        xdg-utils
        gsettings-desktop-schemas
        hicolor-icon-theme
        fontconfig
        freetype
        lsb-release
      ];
    multiPkgs =
      pkgs: with pkgs; [
        # From unityhub package
        cups
        gtk3
        expat
        libxkbcommon
        lttng-ust_2_12
        krb5
        alsa-lib
        nss
        libdrm
        libgbm
        nspr
        atk
        dbus
        at-spi2-core
        pango
        xorg.libXcomposite
        xorg.libXext
        xorg.libXdamage
        xorg.libXfixes
        xorg.libxcb
        xorg.libxshmfence
        xorg.libXScrnSaver
        xorg.libXtst
        libva
        openssl
        cairo
        libnotify
        libuuid
        libsecret
        udev
        libappindicator
        wayland
        cpio
        icu
        libpulseaudio
        libglvnd
        xorg.libX11
        xorg.libXcursor
        glib
        gdk-pixbuf
        libxml2
        zlib
        clang
        git
        xorg.libXi
        xorg.libXrender
        gnome2.GConf
        libcap
        harfbuzz
        vulkan-loader
        xorg.libXrandr # Add here too for good measure
      ];
    runScript = "${pkgs.bash}/bin/bash";
  };
in
pkgs.writeShellScriptBin "unity-2021.3.5f1" ''
  exec ${unityFHS}/bin/unity-editor-fhs -c "$HOME/BigData/UnityEditor/2021.3.5f1/Editor/Unity $@"
''

$path = (Resolve-Path -Path ".\thirdparty\tracy-0.13.1").Path
scons platform=windows production=yes target=template_release arch=x86_64 debug_symbols=yes profiler=tracy profiler_path="$path" module_mono_enabled=yes module_bmp_enabled=no module_camera_enabled=no module_cvtt_enabled=no module_dds_enabled=no module_fbx_enabled=no module_ktx_enabled=no module_vhacd_enabled=no module_webrtc_enabled=no module_mobile_vr_enabled=no module_webxr_enabled=no module_gridmap_enabled=no module_jolt_physics_enabled=no

Rename-Item -Path ./bin/godot.windows.template_release.x86_64.mono.console.exe -NewName windows_tracy_x86_64_console.exe
Rename-Item -Path ./bin/godot.windows.template_release.x86_64.mono.exe -NewName windows_tracy_x86_64.exe

Remove-Item bin/* -Include *.exp,*.lib,*.pdb -Force

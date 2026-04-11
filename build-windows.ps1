Remove-Item bin/bin -Recurse -ErrorAction SilentlyContinue
Remove-Item bin/GodotSharp -Recurse -ErrorAction SilentlyContinue
Remove-Item bin/obj -Recurse -ErrorAction SilentlyContinue
Remove-Item bin/* -Include *.exe -ErrorAction SilentlyContinue

scons platform=windows production=yes no_editor_splash=yes engine_update_check=no module_mono_enabled=yes module_bmp_enabled=no module_camera_enabled=no module_cvtt_enabled=no module_dds_enabled=no module_fbx_enabled=no module_ktx_enabled=no module_vhacd_enabled=no module_webrtc_enabled=no module_mobile_vr_enabled=no module_webxr_enabled=no module_gridmap_enabled=no module_jolt_physics_enabled=no

$exe = './bin/godot.windows.editor.x86_64.mono.exe'
$process = Start-Process -FilePath $exe -ArgumentList "--headless --generate-mono-glue ./modules/mono/glue" -PassThru
Start-Sleep -Seconds 30
Stop-Process -Id $process.Id

./modules/mono/build_scripts/build_assemblies.py --godot-output-dir=./bin --push-nupkgs-local J:\Godot\LocalNugetSource

scons platform=windows production=yes target=template_release arch=x86_64 module_mono_enabled=yes module_bmp_enabled=no module_camera_enabled=no module_cvtt_enabled=no module_dds_enabled=no module_fbx_enabled=no module_ktx_enabled=no module_vhacd_enabled=no module_webrtc_enabled=no module_mobile_vr_enabled=no module_webxr_enabled=no module_gridmap_enabled=no module_jolt_physics_enabled=no

scons platform=windows production=yes target=template_debug arch=x86_64 module_mono_enabled=yes module_bmp_enabled=no module_camera_enabled=no module_cvtt_enabled=no module_dds_enabled=no module_fbx_enabled=no module_ktx_enabled=no module_vhacd_enabled=no module_webrtc_enabled=no module_mobile_vr_enabled=no module_webxr_enabled=no module_gridmap_enabled=no module_jolt_physics_enabled=no

Rename-Item -Path ./bin/godot.windows.template_debug.x86_64.mono.console.exe -NewName windows_debug_x86_64_console.exe
Rename-Item -Path ./bin/godot.windows.template_debug.x86_64.mono.exe -NewName windows_debug_x86_64.exe
Rename-Item -Path ./bin/godot.windows.template_release.x86_64.mono.console.exe -NewName windows_release_x86_64_console.exe
Rename-Item -Path ./bin/godot.windows.template_release.x86_64.mono.exe -NewName windows_release_x86_64.exe

Remove-Item bin/* -Include *.exp,*.lib,*.pdb -Force

#!/bin/bash
rm -f ./bin/linux_release.x86_64
rm -f ./bin/linux_debug.x86_64
scons platform=linuxbsd arch=x86_64 production=yes target=template_release arch=x86_64 module_mono_enabled=yes module_bmp_enabled=no module_camera_enabled=no module_cvtt_enabled=no module_dds_enabled=no module_fbx_enabled=no module_ktx_enabled=no module_vhacd_enabled=no module_webrtc_enabled=no module_mobile_vr_enabled=no module_webxr_enabled=no module_gridmap_enabled=no module_jolt_physics_enabled=no
scons platform=linuxbsd arch=x86_64 production=yes target=template_debug arch=x86_64 module_mono_enabled=yes module_bmp_enabled=no module_camera_enabled=no module_cvtt_enabled=no module_dds_enabled=no module_fbx_enabled=no module_ktx_enabled=no module_vhacd_enabled=no module_webrtc_enabled=no module_mobile_vr_enabled=no module_webxr_enabled=no module_gridmap_enabled=no module_jolt_physics_enabled=no

mv ./bin/godot.linuxbsd.template_release.x86_64.mono ./bin/linux_release.x86_64
mv ./bin/godot.linuxbsd.template_debug.x86_64.mono ./bin/linux_debug.x86_64

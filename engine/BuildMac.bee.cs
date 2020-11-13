using Bee.Toolchain.Xcode;
using System;
using System.Linq;
using Bee.Core;
using Bee.DotNet;
using Bee.ProjectGeneration.VisualStudio;
using Bee.VisualStudioSolution;
using static Bee.NativeProgramSupport.NativeProgramConfiguration;
using Bee.NativeProgramSupport;
using Bee.Tools;
using NiceIO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class BuildMac
{
    private static string skiaRoot;
    private static string flutterRoot;

    public static NativeProgram Build(string skiaRootPath, string flutterRootPath)
    {
        skiaRoot = skiaRootPath;
        flutterRoot = flutterRootPath;

        var np = new NativeProgram("libUIWidgets")
        {
            Sources =
            {
                "src/assets/asset_manager.cc",
                "src/assets/asset_manager.h",
                "src/assets/asset_resolver.h",
                "src/assets/directory_asset_bundle.cc",
                "src/assets/directory_asset_bundle.h",

                "src/common/settings.cc",
                "src/common/settings.h",
                "src/common/task_runners.cc",
                "src/common/task_runners.h",

                "src/flow/layers/backdrop_filter_layer.cc",
                "src/flow/layers/backdrop_filter_layer.h",
                "src/flow/layers/clip_path_layer.cc",
                "src/flow/layers/clip_path_layer.h",
                "src/flow/layers/clip_rect_layer.cc",
                "src/flow/layers/clip_rect_layer.h",
                "src/flow/layers/clip_rrect_layer.cc",
                "src/flow/layers/clip_rrect_layer.h",
                "src/flow/layers/color_filter_layer.cc",
                "src/flow/layers/color_filter_layer.h",
                "src/flow/layers/container_layer.cc",
                "src/flow/layers/container_layer.h",
                "src/flow/layers/image_filter_layer.cc",
                "src/flow/layers/image_filter_layer.h",
                "src/flow/layers/layer.cc",
                "src/flow/layers/layer.h",
                "src/flow/layers/layer_tree.cc",
                "src/flow/layers/layer_tree.h",
                "src/flow/layers/opacity_layer.cc",
                "src/flow/layers/opacity_layer.h",
                "src/flow/layers/performance_overlay_layer.cc",
                "src/flow/layers/performance_overlay_layer.h",
                "src/flow/layers/physical_shape_layer.cc",
                "src/flow/layers/physical_shape_layer.h",
                "src/flow/layers/picture_layer.cc",
                "src/flow/layers/picture_layer.h",
                "src/flow/layers/platform_view_layer.cc",
                "src/flow/layers/platform_view_layer.h",
                "src/flow/layers/shader_mask_layer.cc",
                "src/flow/layers/shader_mask_layer.h",
                "src/flow/layers/texture_layer.cc",
                "src/flow/layers/texture_layer.h",
                "src/flow/layers/transform_layer.cc",
                "src/flow/layers/transform_layer.h",
                "src/flow/compositor_context.cc",
                "src/flow/compositor_context.h",
                "src/flow/embedded_views.cc",
                "src/flow/embedded_views.h",
                "src/flow/instrumentation.cc",
                "src/flow/instrumentation.h",
                "src/flow/matrix_decomposition.cc",
                "src/flow/matrix_decomposition.h",
                "src/flow/paint_utils.cc",
                "src/flow/paint_utils.h",
                "src/flow/raster_cache.cc",
                "src/flow/raster_cache.h",
                "src/flow/raster_cache_key.cc",
                "src/flow/raster_cache_key.h",
                "src/flow/rtree.cc",
                "src/flow/rtree.h",
                "src/flow/skia_gpu_object.cc",
                "src/flow/skia_gpu_object.h",
                "src/flow/texture.cc",
                "src/flow/texture.h",

                "src/lib/ui/compositing/scene.cc",
                "src/lib/ui/compositing/scene.h",
                "src/lib/ui/compositing/scene_builder.cc",
                "src/lib/ui/compositing/scene_builder.h",


                "src/lib/ui/text/icu_util.h",
                "src/lib/ui/text/icu_util.cc",
                "src/lib/ui/text/asset_manager_font_provider.cc",
                "src/lib/ui/text/asset_manager_font_provider.h",
                "src/lib/ui/text/paragraph_builder.cc",
                "src/lib/ui/text/paragraph_builder.h",
                "src/lib/ui/text/font_collection.cc",
                "src/lib/ui/text/font_collection.h",
                "src/lib/ui/text/paragraph.cc",
                "src/lib/ui/text/paragraph.h",

                "src/lib/ui/painting/canvas.cc",
                "src/lib/ui/painting/canvas.h",
                "src/lib/ui/painting/codec.cc",
                "src/lib/ui/painting/codec.h",
                "src/lib/ui/painting/color_filter.cc",
                "src/lib/ui/painting/color_filter.h",
                "src/lib/ui/painting/engine_layer.cc",
                "src/lib/ui/painting/engine_layer.h",
                "src/lib/ui/painting/frame_info.cc",
                "src/lib/ui/painting/frame_info.h",
                "src/lib/ui/painting/gradient.cc",
                "src/lib/ui/painting/gradient.h",
                "src/lib/ui/painting/image.cc",
                "src/lib/ui/painting/image.h",
                "src/lib/ui/painting/image_decoder.cc",
                "src/lib/ui/painting/image_decoder.h",
                "src/lib/ui/painting/image_encoding.cc",
                "src/lib/ui/painting/image_encoding.h",
                "src/lib/ui/painting/image_filter.cc",
                "src/lib/ui/painting/image_filter.h",
                "src/lib/ui/painting/image_shader.cc",
                "src/lib/ui/painting/image_shader.h",
                "src/lib/ui/painting/matrix.cc",
                "src/lib/ui/painting/matrix.h",
                "src/lib/ui/painting/multi_frame_codec.cc",
                "src/lib/ui/painting/multi_frame_codec.h",
                "src/lib/ui/painting/path.cc",
                "src/lib/ui/painting/path.h",
                "src/lib/ui/painting/path_measure.cc",
                "src/lib/ui/painting/path_measure.h",
                "src/lib/ui/painting/paint.cc",
                "src/lib/ui/painting/paint.h",
                "src/lib/ui/painting/picture.cc",
                "src/lib/ui/painting/picture.h",
                "src/lib/ui/painting/picture_recorder.cc",
                "src/lib/ui/painting/picture_recorder.h",
                "src/lib/ui/painting/rrect.cc",
                "src/lib/ui/painting/rrect.h",
                "src/lib/ui/painting/shader.cc",
                "src/lib/ui/painting/shader.h",
                "src/lib/ui/painting/single_frame_codec.cc",
                "src/lib/ui/painting/single_frame_codec.h",
                "src/lib/ui/painting/vertices.cc",
                "src/lib/ui/painting/vertices.h",

                "src/lib/ui/window/platform_message_response_mono.cc",
                "src/lib/ui/window/platform_message_response_mono.h",
                "src/lib/ui/window/platform_message_response.cc",
                "src/lib/ui/window/platform_message_response.h",
                "src/lib/ui/window/platform_message.cc",
                "src/lib/ui/window/platform_message.h",
                "src/lib/ui/window/pointer_data.cc",
                "src/lib/ui/window/pointer_data.h",
                "src/lib/ui/window/pointer_data_packet.cc",
                "src/lib/ui/window/pointer_data_packet.h",
                "src/lib/ui/window/pointer_data_packet_converter.cc",
                "src/lib/ui/window/pointer_data_packet_converter.h",
                "src/lib/ui/window/viewport_metrics.cc",
                "src/lib/ui/window/viewport_metrics.h",
                "src/lib/ui/window/window.cc",
                "src/lib/ui/window/window.h",

                "src/lib/ui/io_manager.h",
                "src/lib/ui/snapshot_delegate.h",
                "src/lib/ui/ui_mono_state.cc",
                "src/lib/ui/ui_mono_state.h",

                "src/runtime/mono_api.cc",
                "src/runtime/mono_api.h",
                "src/runtime/mono_isolate.cc",
                "src/runtime/mono_isolate.h",
                "src/runtime/mono_isolate_scope.cc",
                "src/runtime/mono_isolate_scope.h",
                "src/runtime/mono_microtask_queue.cc",
                "src/runtime/mono_microtask_queue.h",
                "src/runtime/mono_state.cc",
                "src/runtime/mono_state.h",
                "src/runtime/runtime_controller.cc",
                "src/runtime/runtime_controller.h",
                "src/runtime/runtime_delegate.cc",
                "src/runtime/runtime_delegate.h",
                "src/runtime/start_up.cc",
                "src/runtime/start_up.h",
                "src/runtime/window_data.cc",
                "src/runtime/window_data.h",
            },
            OutputName = { c => $"libUIWidgets{(c.CodeGen == CodeGen.Debug ? "_d" : "")}" },
        };

        var customFlags = new string[] {
            "-Wno-c++11-narrowing"
        };
        
        np.CompilerSettings().Add(c => c.WithCppLanguageVersion(CppLanguageVersion.Cpp17));
        np.CompilerSettings().Add(c => c.WithCustomFlags(customFlags));

        np.DynamicLinkerSettingsForMac().Add(c => c.CodeGen == CodeGen.Debug, l => l.WithInstallName("@executable_path/mydll_d.dylib"));
        np.DynamicLinkerSettingsForMac().Add(c => c.CodeGen != CodeGen.Debug, l => l.WithInstallName("@executable_path/mydll.dylib"));

        np.IncludeDirectories.Add("third_party");
        np.IncludeDirectories.Add("src");

        np.Defines.Add("UIWIDGETS_ENGINE_VERSION=\\\"0.0\\\"", "SKIA_VERSION=\\\"0.0\\\"");

        np.Defines.Add("UIWIDGETS_FORCE_ALIGNAS_8=\\\"1\\\"");

        np.Defines.Add("UIWIDGETS_OS_MAC=\\\"1\\\"");

        np.Defines.Add(c => c.CodeGen == CodeGen.Debug,
            new[] { "_ITERATOR_DEBUG_LEVEL=2", "_HAS_ITERATOR_DEBUGGING=1", "_SECURE_SCL=1" });

        np.Defines.Add(c => c.CodeGen == CodeGen.Release,
            new[] { "UIWidgets_RELEASE=1" });

        //np.LinkerSettings().Add(l => l.WithCustomFlags_workaround(new[] { "/DEBUG:FULL" }));

        SetupFml(np);
        SetupRadidJson(np);
        SetupSkia(np);
        SetupTxt(np);

        var toolchain = ToolChain.Store.Host();

        var codegens = new[] { CodeGen.Debug };
        foreach (var codegen in codegens)
        {
            var config = new NativeProgramConfiguration(codegen, toolchain, lump: true);

            np.SetupSpecificConfiguration(config, toolchain.DynamicLibraryFormat).DeployTo("build");
        }

        return np;
    }

    static void SetupSkia(NativeProgram np)
    {
        np.Defines.Add(new[]
        {
            // bin\gn desc out\Debug\ //:skia defines
            "SK_ENABLE_SPIRV_VALIDATION",
            "SK_ASSUME_GL=1",
            "SK_ENABLE_API_AVAILABLE",
            "SK_GAMMA_APPLY_TO_A8",
            "GR_OP_ALLOCATE_USE_NEW",
            "SK_ALLOW_STATIC_GLOBAL_INITIALIZERS=1",
            "GR_TEST_UTILS=1",
            "SKIA_IMPLEMENTATION=1",
            "SK_GL",
            "SK_ENABLE_DUMP_GPU",
            "SK_SUPPORT_PDF",
            "SK_CODEC_DECODES_JPEG",
            "SK_ENCODE_JPEG",
            "SK_ENABLE_ANDROID_UTILS",
            "SK_USE_LIBGIFCODEC",
            "SK_HAS_HEIF_LIBRARY",
            "SK_CODEC_DECODES_PNG",
            "SK_ENCODE_PNG",
            "SK_CODEC_DECODES_RAW",
            "SK_ENABLE_SKSL_INTERPRETER",
            "SKVM_JIT_WHEN_POSSIBLE",
            "SK_CODEC_DECODES_WEBP",
            "SK_ENCODE_WEBP",
            "SK_XML"
            // bin\gn desc out\Debug\ //third_party/angle2:libEGL defines
            
        });

        np.IncludeDirectories.Add(skiaRoot);
        //np.IncludeDirectories.Add(skiaRoot + "/include");
        //np.IncludeDirectories.Add(skiaRoot + "/third_party/externals/angle2/include");
        // np.IncludeDirectories.Add(skiaRoot + "/include/third_party/vulkan");

        np.Libraries.Add(IsMac, c =>
        {
            var basePath = skiaRoot + "/out/Debug";
            return new PrecompiledLibrary[]
            {
                new StaticLibrary(basePath + "/libskia.a"),
                new StaticLibrary(basePath + "/libskottie.a"),
                new StaticLibrary(basePath + "/libsksg.a"),
                new StaticLibrary(basePath + "/libskshaper.a"),
                new SystemFramework("ApplicationServices"),
                new SystemFramework("OpenGL"),
                new SystemFramework("AppKit"),
                //new StaticLibrary(basePath + "/libharfbuzz.lib"),
                //new StaticLibrary(basePath + "/libEGL.dll.lib"),
                //new StaticLibrary(basePath + "/libGLESv2.dll.lib"),
                // new SystemLibrary("Opengl32.lib"), 
                //new SystemLibrary("User32.lib"),
                //new SystemLibrary("D3D12.lib"), 
                //new SystemLibrary("DXGI.lib"), 
                //new SystemLibrary("d3dcompiler.lib"),
                // new SystemLibrary(basePath + "/obj/tools/trace/trace.ChromeTracingTracer.obj"),
                // new SystemLibrary(basePath + "/obj/tools/trace/trace.EventTracingPriv.obj"),
                // new SystemLibrary(basePath + "/obj/tools/trace/trace.SkDebugfTracer.obj"),
                // new SystemLibrary(basePath + "/obj/tools/flags/flags.CommandLineFlags.obj"),
            };
        });

        var basePath = skiaRoot + "/out/Debug";
        np.SupportFiles.Add(
            //new DeployableFile(basePath + "/libEGL.dll"),
            //new DeployableFile(basePath + "/libEGL.dll.pdb"),
            //new DeployableFile(basePath + "/libGLESv2.dll"),
            //new DeployableFile(basePath + "/libGLESv2.dll.pdb")
        );
    }

    static void SetupFml(NativeProgram np)
    {
        np.Defines.Add(new []
        {
            "USE_OPENSSL=1",
            "__STDC_CONSTANT_MACROS",
            "__STDC_FORMAT_MACROS",
            "_FORTIFY_SOURCE=2",
            "_LIBCPP_DISABLE_AVAILABILITY=1",
            "_LIBCPP_DISABLE_VISIBILITY_ANNOTATIONS",
            "_LIBCPP_ENABLE_THREAD_SAFETY_ANNOTATIONS",
            "_DEBUG",
            "FLUTTER_RUNTIME_MODE_DEBUG=1",
            "FLUTTER_RUNTIME_MODE_PROFILE=2",
            "FLUTTER_RUNTIME_MODE_RELEASE=3",
            "FLUTTER_RUNTIME_MODE_JIT_RELEASE=4",
            "FLUTTER_RUNTIME_MODE=1",
            "FLUTTER_JIT_RUNTIME=1"
        });

        np.IncludeDirectories.Add(flutterRoot);

        np.Libraries.Add(c =>
        {
            var basePath = flutterRoot + "/out/host_debug_unopt";
            return new PrecompiledLibrary[]
            {
                new StaticLibrary(basePath + "/obj/flutter/fml/libfml_lib.a"),
                new SystemFramework("Foundation")
            };
        });
    }

    static void SetupRadidJson(NativeProgram np)
    {
        // gn desc .\out\host_debug_unopt\ //third_party/rapidjson:rapidjson
        np.Defines.Add(new[]
        {
            "USE_OPENSSL=1",
            "__STDC_CONSTANT_MACROS",
            "__STDC_FORMAT_MACROS",
            "_FORTIFY_SOURCE=2",
            "_LIBCPP_DISABLE_AVAILABILITY=1",
            "_LIBCPP_DISABLE_VISIBILITY_ANNOTATIONS",
            "_LIBCPP_ENABLE_THREAD_SAFETY_ANNOTATIONS",
            "_DEBUG",
            "RAPIDJSON_HAS_STDSTRING",
            "RAPIDJSON_HAS_CXX11_RANGE_FOR",
            "RAPIDJSON_HAS_CXX11_RVALUE_REFS",
            "RAPIDJSON_HAS_CXX11_TYPETRAITS",
            "RAPIDJSON_HAS_CXX11_NOEXCEPT"
        });

        np.IncludeDirectories.Add(flutterRoot + "/third_party/rapidjson/include");
    }

    static void SetupTxtDependency(NativeProgram np)
    {
        np.Defines.Add(new[] { "SK_USING_THIRD_PARTY_ICU", "U_USING_ICU_NAMESPACE=0", "U_DISABLE_RENAMING",
            "U_ENABLE_DYLOAD=0", "USE_CHROMIUM_ICU=1", "U_STATIC_IMPLEMENTATION",
            "ICU_UTIL_DATA_IMPL=ICU_UTIL_DATA_STATIC"
        });
        np.IncludeDirectories.Add(flutterRoot + "/flutter/third_party/txt/src");
        np.IncludeDirectories.Add(skiaRoot + "/third_party/externals/harfbuzz/src");
        np.IncludeDirectories.Add(skiaRoot + "/third_party/externals/icu/source/common");
    }

    static void SetupTxt(NativeProgram np)
    {
        // gn desc .\out\host_debug_unopt\ //flutter/third_party/txt:txt
        IEnumerable<NPath> sources = new List<NPath> {
            "src/log/log.cc",
            "src/log/log.h",
            "src/minikin/CmapCoverage.cpp",
            "src/minikin/CmapCoverage.h",
            "src/minikin/Emoji.cpp",
            "src/minikin/Emoji.h",
            "src/minikin/FontCollection.cpp",
            "src/minikin/FontCollection.h",
            "src/minikin/FontFamily.cpp",
            "src/minikin/FontFamily.h",
            "src/minikin/FontLanguage.cpp",
            "src/minikin/FontLanguage.h",
            "src/minikin/FontLanguageListCache.cpp",
            "src/minikin/FontLanguageListCache.h",
            "src/minikin/FontUtils.cpp",
            "src/minikin/FontUtils.h",
            "src/minikin/GraphemeBreak.cpp",
            "src/minikin/GraphemeBreak.h",
            "src/minikin/HbFontCache.cpp",
            "src/minikin/HbFontCache.h",
            "src/minikin/Hyphenator.cpp",
            "src/minikin/Hyphenator.h",
            "src/minikin/Layout.cpp",
            "src/minikin/Layout.h",
            "src/minikin/LayoutUtils.cpp",
            "src/minikin/LayoutUtils.h",
            "src/minikin/LineBreaker.cpp",
            "src/minikin/LineBreaker.h",
            "src/minikin/Measurement.cpp",
            "src/minikin/Measurement.h",
            "src/minikin/MinikinFont.cpp",
            "src/minikin/MinikinFont.h",
            "src/minikin/MinikinInternal.cpp",
            "src/minikin/MinikinInternal.h",
            "src/minikin/SparseBitSet.cpp",
            "src/minikin/SparseBitSet.h",
            "src/minikin/WordBreaker.cpp",
            "src/minikin/WordBreaker.h",
            "src/txt/asset_font_manager.cc",
            "src/txt/asset_font_manager.h",
            "src/txt/font_asset_provider.cc",
            "src/txt/font_asset_provider.h",
            "src/txt/font_collection.cc",
            "src/txt/font_collection.h",
            "src/txt/font_features.cc",
            "src/txt/font_features.h",
            "src/txt/font_skia.cc",
            "src/txt/font_skia.h",
            "src/txt/font_style.h",
            "src/txt/font_weight.h",
            "src/txt/line_metrics.h",
            "src/txt/paint_record.cc",
            "src/txt/paint_record.h",
            "src/txt/paragraph.h",
            "src/txt/paragraph_builder.cc",
            "src/txt/paragraph_builder.h",
            "src/txt/paragraph_builder_txt.cc",
            "src/txt/paragraph_builder_txt.h",
            "src/txt/paragraph_style.cc",
            "src/txt/paragraph_style.h",
            "src/txt/paragraph_txt.cc",
            "src/txt/paragraph_txt.h",
            "src/txt/placeholder_run.cc",
            "src/txt/placeholder_run.h",
            "src/txt/platform.h",
            "src/txt/run_metrics.h",
            "src/txt/styled_runs.cc",
            "src/txt/styled_runs.h",
            "src/txt/test_font_manager.cc",
            "src/txt/test_font_manager.h",
            "src/txt/text_baseline.h",
            "src/txt/text_decoration.cc",
            "src/txt/text_decoration.h",
            "src/txt/text_shadow.cc",
            "src/txt/text_shadow.h",
            "src/txt/text_style.cc",
            "src/txt/text_style.h",
            "src/txt/typeface_font_asset_provider.cc",
            "src/txt/typeface_font_asset_provider.h",
            "src/utils/JenkinsHash.cpp",
            "src/utils/JenkinsHash.h",
            "src/utils/LinuxUtils.h",
            "src/utils/LruCache.h",
            "src/utils/MacUtils.h",
            "src/utils/TypeHelpers.h",
            "src/utils/WindowsUtils.h"
        };

        var txtLib = new NativeProgram("txt_lib")
        {
            IncludeDirectories = {
                "third_party",
                flutterRoot,
                skiaRoot,
            },
        };

        var customFlags = new string[] {
            "-Wno-c++11-narrowing"
        };

        SetupTxtDependency(txtLib);

        var ignoreWarnigs = new string[] { "4091", "4722", "4312", "4838", "4172", "4005", "4311", "4477" }; // todo comparing the list with engine

        txtLib.CompilerSettings().Add(c => c.WithCppLanguageVersion(CppLanguageVersion.Cpp17));
        txtLib.CompilerSettings().Add(s => s.WithWarningPolicies(ignoreWarnigs.Select((code) => new WarningAndPolicy(code, WarningPolicy.Silent)).ToArray()));
        txtLib.CompilerSettings().Add(c => c.WithCustomFlags(customFlags));

        txtLib.Defines.Add(c => c.CodeGen == CodeGen.Debug,
            new[] { "_ITERATOR_DEBUG_LEVEL=2", "_HAS_ITERATOR_DEBUGGING=1", "_SECURE_SCL=1" });
        txtLib.Defines.Add(c => IsWindows(c),
            new[] { "UCHAR_TYPE=wchar_t" });
        txtLib.Defines.Add(c => !IsWindows(c),
                    new[] { "UCHAR_TYPE=uint16_t" });
        txtLib.Defines.Add(c => c.CodeGen == CodeGen.Release,
            new[] { "UIWidgets_RELEASE=1" });


        var txtPath = new NPath(flutterRoot + "/flutter/third_party/txt");
        sources = sources.Select(p => txtPath.Combine(p));
        txtLib.Sources.Add(sources);
        txtLib.Sources.Add(c => IsMac(c), txtPath.Combine(new NPath("src/txt/platform_mac.mm")));
        txtLib.NonLumpableFiles.Add(sources);

        np.Libraries.Add(txtLib);
        SetupTxtDependency(np);

    }
}
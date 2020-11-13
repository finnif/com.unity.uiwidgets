# UIWidgets Engine

## Introduction

This is the engine code of UIWidgets.

## How to Build Depedencies (Windows)

### Build Skia

1. Install depot_tools
```
git clone 'https://chromium.googlesource.com/chromium/tools/depot_tools.git'
```
Add ${PWD}/depot_tools to PATH

2. Clone the skia Repo

git clone https://skia.googlesource.com/skia.git
cd skia
git checkout chrome/m85
python2 tools/git-sync-deps

3. Install LLVM

https://clang.llvm.org/get_started.html

4. Build skia

```
bin/gn gen out/Debug
```
Update out/Debug/args.gn with the following content:
```
clang_win = "C:\Program Files\LLVM"
win_vc = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC"
cc = "clang"
cxx = "clang++"
is_debug = true
skia_use_angle = true
skia_use_egl = true
extra_cflags = [
  "/MTd",
  "-I../../third_party/externals/angle2/include",
]
```
```
ninja -C out/Debug -k 0
```
Ignore this error: "lld-link: error: could not open 'EGL': no such file or directory"

convert icudtl.dat to object file in skia
```
cd SkiaRoot/third_party/externals/icu/flutter/
ld -r -b binary -o icudtl.o icudtl.dat
```
### Build flutter fml

1. Setting up the Engine development environment

Follow https://github.com/flutter/flutter/wiki/Setting-up-the-Engine-development-environment

2. Compiling for Windows

Follow https://github.com/flutter/flutter/wiki/Compiling-the-engine#compiling-for-windows

3. Checkout flutter-1.17-candidate.5

```
cd engine/src/flutter
git checkout flutter-1.17-candidate.5
gclient sync -D
```

Apply the following diff:
```
diff --git a/fml/BUILD.gn b/fml/BUILD.gn
index 9b5626e78..da1322ce5 100644
--- a/fml/BUILD.gn
+++ b/fml/BUILD.gn
@@ -295,3 +295,10 @@ executable("fml_benchmarks") {
     "//flutter/runtime:libdart",
   ]
 }
+
+static_library("fml_lib") {
+  complete_static_lib = true
+  deps = [
+    "//flutter/fml",
+  ]
+}
```
cmd
```
set GYP_MSVS_OVERRIDE_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community
cd engine/src
python ./flutter/tools/gn --unoptimized
ninja -C .\out\host_debug_unopt\ flutter/fml:fml_lib
```

### Create symbolic

cmd
```
cd <uiwidigets_dir>\engine
cd third_party   \\ create the directory if not exists
mklink /D skia <SKIA_ROOT>
```
Flutter engine txt include skia header in this pattern 'third_party/skia/*', so without symbolic, the txt lib will include skia
header file in flutter engine, instead of headers in skia repo.

### How to Build Engine
```
bee
```

## How to Build Depedencies (Mac)

### Build Skia
```
git clone 'https://chromium.googlesource.com/chromium/tools/depot_tools.git'

export PATH="${PWD}/depot_tools:${PATH}"

git clone https://skia.googlesource.com/skia.git

git checkout chrome/m85

bin/gn gen out/Debug

python2 tools/git-sync-deps (确保是python2)

ninja -C out/Debug -k 0
```

如果遇到找不到sdk的问题，则一定是ninja用了python3。最好能够暂时删掉你本地的python3，或者让python对应python2。注意处理一下“path environment variable in .zshrc was giving precedence to python3”的情况。


### Build Flutter Engine

Setting up the Engine development environment

Must Follow https://github.com/flutter/flutter/wiki/Setting-up-the-Engine-development-environment. To prepare stuffs

Compile Flutter Engine:

Check out and update dependencies:

```
git checkout flutter-1.17-candidate.5
gclient sync -D
```

Apply changes to BUILD.gn (src/flutter/fml/BUILD.gn)

```
diff --git a/fml/BUILD.gn b/fml/BUILD.gn
index 9b5626e78..da1322ce5 100644
--- a/fml/BUILD.gn
+++ b/fml/BUILD.gn
@@ -295,3 +295,10 @@ executable("fml_benchmarks") {
     "//flutter/runtime:libdart",
   ]
 }
+
+static_library("fml_lib") {
+  complete_static_lib = true
+  deps = [
+    "//flutter/fml",
+  ]
+}
```

最后编译：
```
cd engine/src

./flutter/tools/gn --unoptimized

ninja -C ./out/host_debug_unopt/ flutter/fml:fml_lib
```


### Build Lib

set SKIA_ROOT and FLUTTER_ROOT to your $PATH. SKIA_ROOT is the root folder of your skia repository. FLUTTER_ROOT is the root folder of your flutter engine repository. 


Create symbolic as follows. Flutter engine txt include skia header in this pattern 'third_party/skia/*', so without symbolic, the txt lib will include skia
header file in flutter engine, instead of headers in skia repo.

cmd
```
cd <uiwidigets_dir>\engine
cd third_party   \\ create the directory if not exists
ln -s <SKIA_ROOT> skia
```




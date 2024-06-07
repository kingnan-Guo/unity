# 文件夹 功能
Editor
文件夹 是用来扩充编辑器的，然后每个文件下 ，还可以携带Editor子文件夹；
如果 需要放置 资源文件： Editor Default Resources （中间有空格），他必须放在 project 视图的根目录下；
Editor Default Resources ： 把编辑器用到的 一些资源放在这里， 比如 图片、 文本文件，
Editor Default Resources 不会打到发布包里 ，仅用于 开发使用

EditorGUIUtility.Load 来读取资源
TextAsset text = EditorGUIUtility.Load("text.txt") as TextAsset;


plugins
可以把 sdk 依赖库 放到这里， .so , .jar, .a
该目录下的 资源会全都打包再 .apk 或 .ipa 里； 安卓的 .apk 是 zip

StreamingAssets
    这个文件夹下的 资源都会打包在 .apk .ipa 
    不会压缩打包
    并且他是一个 只读的文件夹，就是程序运行时 只能读 不能写
    
    Application.streamingAssetsPath  返回路径  它会根据当前的平台选择对应的路径




Resources 目录
用来 存放 当前代码里要加载的资源， 一定要放到 Resources 目录下
图片
文本
预制体




# 打包会打包那些文件
Editor 不会被打包
Resources 会被打包到 安装包
StreamingAssets 会被打包到 安装包（不压缩）

其他的 会根据 依赖 来判定是否打包




# 资源动态加载
类型：
Texture Sprite （纹理）
文本
声音
预制体


    Resource 类 来使用代码加载我们的资源，并使用
        再加载资源的时候 路径不能携带 Resources 和资源后缀名


# unity

shader


# shader 的形式 
表面着色器 （可控性较低）
顶点/ 片元 着色器（重点）



1、 表面着色器
代码少 性能差 不用 自己处理光照
直接书写逻辑 不需要换新pass
放在 
CGPROGRAM
ENDCG
之间

2、 顶点/ 片元 着色器
灵活性 性能  更多细节
需要在pass 渲染通道中写着色器 逻辑
可以使用 CG 和 HLSL两种 shader 语言区编写 shader
适用于 光照 较少 ，自定义渲染效果较多时


3、 固定函数着色器、




# CG 语句写在哪里
对于顶点、 片元 着色器来说
CG 写在 Pass 渲染通道语句中
我们需要写在 Pass 中的指令加入
CGPROGRAM
    我们书写 CG 代码
ENDCG




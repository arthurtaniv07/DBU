using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Globalization;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

/// <summary>
/// 包含一组动态编译的方法
/// </summary>
namespace St.Dynamic
{
    /// <summary>
    /// 编译类
    /// </summary>
    public class StCompile
    {
        /// <summary>
        /// 编译cs文件为dll文件集合到指定目录  返回错误信息集合
        /// </summary>
        /// <param name="outPath">dll输出目录</param>
        /// <param name="files">要编译到dll文件的路径集合</param>
        /// <returns>错误信息集合</returns>
        public static List<string> CompileFromFiles(string outPath , params string[] files) 
        {

            // 1.CSharpCodePrivoder
            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();
            
            // 2.ICodeComplier
            ICodeCompiler objICodeCompiler = objCSharpCodePrivoder.CreateCompiler();

            // 3.CompilerParameters
            CompilerParameters objCompilerParameters = new CompilerParameters();
            objCompilerParameters.ReferencedAssemblies.Add("System.dll");
            objCompilerParameters.GenerateExecutable = true;
            objCompilerParameters.GenerateInMemory = false;
            objCompilerParameters.OutputAssembly = outPath;
            objCompilerParameters.TreatWarningsAsErrors = false;

            CompilerResults cr = objICodeCompiler.CompileAssemblyFromFileBatch(objCompilerParameters, files);
            // 4.CompilerResults
            //CompilerResults cr = objICodeCompiler.CompileAssemblyFromSource(objCompilerParameters, "code");
            //CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromFile(objCompilerParameters, files);


            List<string> erros = null;

            if (cr.Errors.HasErrors)
            {
                erros = new List<string>();
                foreach (CompilerError err in cr.Errors)
                {
                    erros.Add(err.ErrorText);
                }
            }
            return erros;
        }
    }
}
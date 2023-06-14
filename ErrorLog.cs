using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.IO;
namespace ClassLibrary2
{
    public static class ErrorLog
    {
        /// <summary>
        /// エラー情報を文字列として取得します
        /// </summary>
        public static string  ErrorLogText(
                                    Exception ex ,
                                    [CallerMemberName] string methodname="",
                                    [CallerFilePath] string className=""
                                   )
        {
            
            string rtn = string.Concat( "FileName: " , className,"\n",
                                        "MethodName :", methodname,"\n",
                                        "ErrorMessage:", ex.Message, "\n",
                                        ex.StackTrace);
            return rtn;
        }
        /// <summary>
        /// エラーログをファイル出力します。
        /// <para>ファイル名はyyyyMMdd_hhmmss_fff.txtで保存されます</para>
        /// </summary>
        public static void ErrorLogText(
                            DirectoryInfo WriteOutLogDirName,
                            Exception ex,
                            [CallerMemberName] string methodname = "",
                            [CallerFilePath] string className = ""
                           )
        {
            if (!WriteOutLogDirName.Exists) throw new DirectoryNotFoundException("保存先フォルダにアクセス出来ませんでした");
            string writeOutFileName =WriteOutLogDirName.FullName+@"\"+ DateTime.Now.ToString("yyyyMMdd_hhmmss_fff.txt");
            
            string rtn = string.Concat("FileName: ", className, "\n",
                                        "MethodName :", methodname, "\n",
                                        "ErrorMessage:", ex.Message, "\n",
                                        ex.StackTrace);
            File.WriteAllText(writeOutFileName, rtn);
            
        }
    }

}

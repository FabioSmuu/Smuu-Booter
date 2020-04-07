using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Booter
{
    class ArquivoINI
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string categoria, string chave, string valor, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string categoria, string chave, string Default, StringBuilder RetVal, int Size, string FilePath);

        public ArquivoINI(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }
        public string Ler(string chave, string categoria = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(categoria ?? EXE, chave, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public void Escrever(string chave, string valor, string categoria = null)
        {
            WritePrivateProfileString(categoria ?? EXE, chave, valor, Path);
        }
        public void DeletarChave(string chave, string categoria = null)
        {
            Escrever(chave, null, categoria ?? EXE);
        }
        public void DeletarCategoria(string categoria = null)
        {
            Escrever(null, null, categoria ?? EXE);
        }
        public bool Existe(string chave, string categoria = null)
        {
            return Ler(chave, categoria).Length > 0;
        }
    }
}
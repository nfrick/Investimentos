using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Testes {
    class Program {
        static void Main(string[] args) {
            string zipPath = @"D:\Users\nfric\Desktop\COTAHIST_M112017.ZIP";

            using (ZipArchive archive = ZipFile.OpenRead(zipPath)) {
                foreach (ZipArchiveEntry entry in archive.Entries) {
                    if (!entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase)) continue;
                    //var txtFile = Path.Combine(
                    //    Path.GetDirectoryName(zipPath), entry.FullName);
                    //entry.ExtractToFile(txtFile);
                    //var linhas = File.ReadLines(txtFile);
                    //foreach (var linha in linhas) {
                    //    Console.WriteLine(linha);
                    //}

                    var lines = InternalReadAllLines(entry.Open());
                }
            }
        }

        private static String[] InternalReadAllLines(Stream stream) {
            String line;
            List<String> lines = new List<String>();

            using (StreamReader sr = new StreamReader(stream))
                while ((line = sr.ReadLine()) != null)
                    lines.Add(line);
            stream.Close();
            return lines.ToArray();
        }
    }
}
